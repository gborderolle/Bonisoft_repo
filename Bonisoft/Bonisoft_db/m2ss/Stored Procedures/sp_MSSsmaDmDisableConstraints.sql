

/*
Summary: This procedure is used to drop/disable constraints and indexes before BCP data migration.
Based on key_type,parallel_load and minimal logging flags, 
	it inserts the constraint info into tracking tables and drop/disable the constraints.
*/
CREATE PROCEDURE [m2ss].[sp_MSSsmaDmDisableConstraints]
	@key_type char(2), @mode int ,@parallel_load int ,@minimal_logging int, @error_log nvarchar(4000) OUTPUT
AS
declare 
@schema_id				   int,
@table_id				   int,
@constraint				   sysname,
@column_id				   int,
@index_column_id		   int,
@column					   sysname,
@columns				   nvarchar(4000),
@ref_table                 sysname,
@ref_column				   sysname,
@ref_columns               nvarchar(4000), 
@constraint_type           sysname,
@cmd                       nvarchar(4000),
@is_disabled               bit,
@mode_action               sysname,
@parent_column_id          int,
@constraint_column_id      int,
@referenced_object_id      int,
@delete_referential_action int,
@update_referential_action int,
@referenced_column_id      int,
@index_name                sysname,
@index_id                  int,
@index_type                varchar(2),
@temp_key_type             varchar(2)

BEGIN
	SET @error_log = N''
	SET @mode_action = 
		CASE (@mode) 
			WHEN 0 THEN N' NOCHECK ' 
			WHEN 1 THEN N' CHECK ' 
			WHEN 2 THEN N' DROP ' 
			WHEN 3 THEN N' ADD ' 
			WHEN 4 THEN N' DISABLE ' 
			WHEN 5 THEN N' REBUILD ' 
		END
	IF(@key_type = N'PK' or @key_type = N'UQ' )
	BEGIN
		--DROP PRIMARY AND UNIQUE KEYS
		DECLARE #keycol_cur CURSOR STATIC FOR
		SELECT pk_un.parent_object_id, pk_un.name, pk_un.type, ic.column_id, ic.index_column_id, pk_un.schema_id
			FROM sys.key_constraints pk_un 
				JOIN sys.index_columns ic ON pk_un.unique_index_id = ic.index_id AND pk_un.parent_object_id = ic.object_id
				JOIN sys.indexes idx ON idx.object_id = pk_un.parent_object_id AND idx.index_id = ic.index_id
				JOIN  [m2ss].[MSSsmaDmTables] t ON t.object_id = pk_un.parent_object_id
			WHERE (@minimal_logging = 1) AND (idx.index_id <> 1) AND pk_un.type = @key_type
			ORDER BY object_name(ic.object_id), ic.index_column_id 
		OPEN #keycol_cur
		FETCH #keycol_cur INTO @table_id, @constraint, @constraint_type, @column_id, @index_column_id, @schema_id
		WHILE (@@FETCH_STATUS <> -1)
		BEGIN
			INSERT [m2ss].[MSSsmaDmNCKeyColumns] (
				object_id
				, key_name
				, key_type
				, key_column_id
				, index_column_id
			) VALUES (@table_id, @constraint, @constraint_type, @column_id, @index_column_id)
		
			IF EXISTS (SELECT * FROM sys.key_constraints WHERE name = @constraint AND schema_id = @schema_id) 
			BEGIN
				SET @cmd = N'ALTER TABLE ' + quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id)) + @mode_action + N' CONSTRAINT ' + quotename(@constraint)		
				BEGIN TRY
					EXEC(@cmd)
				END TRY
				BEGIN CATCH
					SET @error_log = @error_log + 'Unable to drop key '+quotename(@constraint)+' to the table '+	quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id))+ char(10) + char(13)
					SET @error_log = @error_log + @cmd + char(10) + char(13)
					SET @error_log = @error_log + ' SQL Error Number:'+ cast(ERROR_NUMBER() as varchar(10))+' SQL ErrorMessage:'+ERROR_MESSAGE()+ char(10) + char(13)
				END CATCH
			END
				
			FETCH #keycol_cur INTO @table_id, @constraint, @constraint_type, @column_id, @index_column_id, @schema_id
		END
		CLOSE #keycol_cur
		DEALLOCATE #keycol_cur
	END
	ELSE IF(@key_type = 'NF')
	BEGIN
		-- DROP FOREIGNKEY REFERENCES ON NON CLUSTERED PK OR UK
		SET @temp_key_type= 'NF'
		DECLARE #fk_col_cur CURSOR STATIC FOR
		SELECT 
			fk.parent_object_id, fk.schema_id, fk.name, fk.type, fkc.parent_column_id, fkc.constraint_column_id, fk.is_disabled,
			fk.referenced_object_id, fk.delete_referential_action, fk.update_referential_action, fkc.referenced_column_id
		FROM sys.foreign_keys fk 
			JOIN sys.foreign_key_columns fkc ON 
					fk.object_id = fkc.constraint_object_id 
				AND fk.parent_object_id = fkc.parent_object_id 
				AND fk.referenced_object_id = fkc.referenced_object_id
			JOIN sys.key_constraints pk ON pk.parent_object_id = fk.referenced_object_id
			JOIN  [m2ss].[MSSsmaDmTables] t ON t.object_id = pk.parent_object_id
		WHERE (pk.type IN (N'PK', N'UQ') AND ((@minimal_logging = 1) AND (fk.key_index_id <> 1)))
		ORDER BY object_name(fkc.constraint_object_id), fkc.constraint_column_id 
		
		OPEN #fk_col_cur
		FETCH #fk_col_cur INTO 
			@table_id, @schema_id, @constraint, @constraint_type, @column_id, @constraint_column_id, @is_disabled, 
			@referenced_object_id, @delete_referential_action, @update_referential_action, @referenced_column_id
		WHILE(@@FETCH_STATUS <> -1)
		BEGIN
			INSERT [m2ss].[MSSsmaDmNCKeyColumns] (
				object_id
				,key_name
				,key_type
				,key_column_id
				,index_column_id
				,is_disabled
				,referenced_object_id
				,delete_referential_action
				,update_referential_action
				,referenced_column_id
			) 
			values (
				@table_id, @constraint, @temp_key_type, @column_id, @constraint_column_id, @is_disabled,@referenced_object_id,
				@delete_referential_action, @update_referential_action, @referenced_column_id
			)
			
			IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = @constraint AND schema_id = @schema_id)
			BEGIN		
				SET @cmd = N'ALTER TABLE ' + quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id)) + @mode_action + N' CONSTRAINT ' + quotename(@constraint)
				BEGIN TRY
					EXEC(@cmd)
				END TRY
				BEGIN CATCH
					SET @error_log = @error_log + 'Unable to drop foreign key '+quotename(@constraint)+' to the table '+	quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id))+ char(10) + char(13)
					SET @error_log = @error_log + @cmd + char(10) + char(13)
					SET @error_log = @error_log + ' SQL Error Number:'+ cast(ERROR_NUMBER() as varchar(10))+' SQL ErrorMessage:'+ERROR_MESSAGE()+ char(10) + char(13)
				END CATCH
			END
			FETCH #fk_col_cur INTO 
				@table_id, @schema_id, @constraint, @constraint_type, @column_id, @constraint_column_id, @is_disabled,@referenced_object_id,
				@delete_referential_action, @update_referential_action,@referenced_column_id
			END
			CLOSE #fk_col_cur
			DEALLOCATE #fk_col_cur
		END
	ELSE IF(@key_type = N'FK' AND @parallel_load = 1)
	BEGIN
		-- DROP FOREIGNKEY REFERENCES ON CLUSTERED PK OR UK WITH PARALLEL DM
		SET @temp_key_type = 'FK'
		DECLARE #fk_col_cur CURSOR STATIC FOR
		SELECT 
			fk.parent_object_id, fk.schema_id, fk.name, fk.type, fkc.parent_column_id, fkc.constraint_column_id, fk.is_disabled,
			fk.referenced_object_id, fk.delete_referential_action, fk.update_referential_action, fkc.referenced_column_id
		FROM sys.foreign_keys fk 
			JOIN sys.foreign_key_columns fkc ON 
					fk.object_id = fkc.constraint_object_id 
				AND fk.parent_object_id = fkc.parent_object_id 
				AND fk.referenced_object_id = fkc.referenced_object_id
			JOIN  [m2ss].[MSSsmaDmTables] t ON t.object_id = fk.referenced_object_id
		ORDER BY object_name(fkc.constraint_object_id), fkc.constraint_column_id 
	
		OPEN #fk_col_cur
		FETCH #fk_col_cur INTO 
			@table_id, @schema_id, @constraint, @constraint_type, @column_id, @constraint_column_id, 
			@is_disabled,@referenced_object_id, @delete_referential_action,@update_referential_action,@referenced_column_id
		WHILE(@@FETCH_STATUS <> -1)
		BEGIN
			INSERT [m2ss].[MSSsmaDmNCKeyColumns] (
				object_id
				,key_name
				,key_type
				,key_column_id
				,index_column_id
				,is_disabled
				,referenced_object_id
				,delete_referential_action
				,update_referential_action
				,referenced_column_id
			) 
			values (
				@table_id, @constraint, @temp_key_type, @column_id, @constraint_column_id, @is_disabled,@referenced_object_id,
				@delete_referential_action, @update_referential_action, @referenced_column_id
			)
			
			IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = @constraint AND schema_id = @schema_id)
			BEGIN
				SET @cmd = N'ALTER TABLE ' + quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id)) + @mode_action + N' CONSTRAINT ' + quotename(@constraint)
				BEGIN TRY
						EXEC(@cmd)
				END TRY
				BEGIN CATCH
					SET @error_log = @error_log + 'Unable to drop foreign key '+quotename(@constraint)+' to the table '+	quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id))+ char(10) + char(13)
					SET @error_log = @error_log + @cmd + char(10) + char(13)
					SET @error_log = @error_log + ' SQL Error Number:'+ cast(ERROR_NUMBER() as varchar(10))+' SQL ErrorMessage:'+ERROR_MESSAGE()+ char(10) + char(13)
				END CATCH
			END
			FETCH #fk_col_cur INTO 
				@table_id, @schema_id, @constraint, @constraint_type, @column_id, @constraint_column_id, @is_disabled, 
				@referenced_object_id, @delete_referential_action, @update_referential_action, @referenced_column_id
		END
		CLOSE #fk_col_cur
		DEALLOCATE #fk_col_cur			
	END
	ELSE IF (@key_type = N'NC')
	BEGIN
		-- DISABLE NON CLUSTERED INDEXES WITH BULK LOAD OPTIMIZATION
		DECLARE #index_col_cur CURSOR FORWARD_ONLY FOR
		SELECT t.object_id AS TableID, t.schema_id,Idxs.[name],Idxs.object_id,'NC',Idxs.index_id 
			FROM  [sys].[indexes] Idxs JOIN [m2ss].[MSSsmaDmTables] t on t.object_id = Idxs.object_id
			WHERE Idxs.[type] = 2 AND Idxs.[is_disabled] = 0 
			
		OPEN #index_col_cur
		FETCH #index_col_cur INTO @table_id, @schema_id, @index_name, @index_id, @index_type,@index_id
		WHILE(@@FETCH_STATUS <> -1)
		BEGIN
			INSERT [m2ss].[MSSsmaDmNCKeyColumns] (
				object_id,
				key_name,
				key_type,
				key_column_id
			) VALUES (@table_id, @index_name, @index_type,@index_id)			
			
			SET @cmd = N'ALTER INDEX ' +quotename(@index_name)+ ' ON '+ quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id)) + @mode_action
			BEGIN TRY
					EXEC(@cmd)
			END TRY
			BEGIN CATCH
				SET @error_log = @error_log + 'Unable to disable non-clustered index '+quotename(@index_name)+' to the table '+	quotename(schema_name(@schema_id)) + N'.' + quotename(object_name(@table_id))+ char(10) + char(13)
				SET @error_log = @error_log + @cmd + char(10) + char(13)
				SET @error_log = @error_log + ' SQL Error Number:'+ cast(ERROR_NUMBER() as varchar(10))+' SQL ErrorMessage:'+ERROR_MESSAGE()+ char(10) + char(13)	
			END CATCH
			
			FETCH #index_col_cur INTO @table_id, @schema_id, @index_name, @index_id, @index_type,@index_id
		END
	END
END
