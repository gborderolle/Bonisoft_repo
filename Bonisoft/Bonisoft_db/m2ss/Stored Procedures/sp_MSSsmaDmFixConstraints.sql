

/*
Summary: This procedure is used to create/enable constraints after BCP data migration.
Based on key_type,parallel_load and minimal logging flags, 
	it reads the constraint info from tracking tables and create/enable the constraint.
*/
CREATE PROCEDURE [m2ss].[sp_MSSsmaDmFixConstraints] 
	@key_type char(2), @mode int ,@parallel_load int ,@minimal_logging int, @error_log nvarchar(4000) OUTPUT
AS 
DECLARE 
@table						sysname, 
@object_id					int,
@constraint					sysname,
@column						sysname,
@columns					nvarchar(4000),
@ref_table					sysname,
@ref_column					sysname,
@ref_columns				nvarchar(4000), 
@mode_action				sysname,
@constraint_type			sysname,
@cmd						nvarchar(4000),
@is_disabled			    bit,
@schema						sysname,
@fkschema					sysname,
@cascade_update_clause		nvarchar(100),
@cascade_delete_clause		nvarchar(100),
@delete_referential_action  int,
@update_referential_action  int

SET @error_log = N''
SET @key_type = UPPER(@key_type)
SET @mode_action = 
	CASE (@mode) 
		WHEN 0 THEN N' NOCHECK ' 
		WHEN 1 THEN N' CHECK ' 
		WHEN 2 THEN N' DROP ' 
		WHEN 3 THEN N' ADD ' 
		WHEN 4 THEN N' DISABLE ' 
		WHEN 5 THEN N' REBUILD ' 
	END
SET @constraint_type = 
	CASE (@key_type) 
		WHEN 'PK' THEN N' PRIMARY KEY NONCLUSTERED '
		WHEN 'UQ' THEN N' UNIQUE NONCLUSTERED ' 
		WHEN 'NF' THEN N' FOREIGN KEY ' 
		WHEN 'FK' THEN N' FOREIGN KEY ' 
	END
	
DECLARE #key_cur CURSOR FORWARD_ONLY FOR
	SELECT DISTINCT object_name(k.object_id), k.object_id, schema_name(o.schema_id), key_name, object_name(referenced_object_id), OBJECT_SCHEMA_NAME(referenced_object_id), is_disabled, update_referential_action, delete_referential_action  
		FROM [m2ss].[MSSsmaDmNCKeyColumns] k JOIN sys.objects o on k.object_id = o.object_id 
		WHERE key_type = @key_type
OPEN #key_cur
FETCH #key_cur INTO @table, @object_id, @schema, @constraint, @ref_table, @fkschema, @is_disabled, @update_referential_action, @delete_referential_action
WHILE (@@FETCH_STATUS <> -1)
BEGIN
	IF (@key_type = 'NC')
	BEGIN
		SET @cmd = N'ALTER INDEX ' + quotename(@constraint) + ' ON ' + quotename(@schema) + N'.' + quotename(@table) + ' REBUILD WITH (MAXDOP=0)'
	END
	ELSE IF (@mode <> 3) -- anything other than add is simple
	BEGIN
		SET @cmd = N'ALTER TABLE ' + quotename(@schema) + N'.' + quotename(@table) + @mode_action + N' CONSTRAINT ' + quotename(@constraint)
	END
	ELSE
	BEGIN 
		SET @columns  = N''
		SET @ref_columns = N''
		SET @cmd 
			= N'ALTER TABLE ' + quotename(@schema) + N'.' + quotename(@table)
			+ N' WITH NOCHECK' -- adding constriant with NOCHECK always as CHECK constraints is set to false in project settings.
			+ N' ADD CONSTRAINT ' +  quotename(@constraint) + @constraint_type
		DECLARE #keycol_cur CURSOR FORWARD_ONLY FOR
		SELECT c.name, rc.name 
			FROM [m2ss].[MSSsmaDmNCKeyColumns] k 
				JOIN sys.columns c ON k.object_id = c.object_id and k.key_column_id = c.column_id 
				LEFT JOIN sys.columns rc ON k.referenced_object_id = rc.object_id and k.referenced_column_id = rc.column_id 
			WHERE k.object_id = @object_id and key_name = @constraint and k.key_type=@key_type
			ORDER BY k.index_column_id

		OPEN #keycol_cur
		FETCH #keycol_cur INTO @column, @ref_column
		WHILE (@@FETCH_STATUS <> -1)
		BEGIN
			SET @columns = @columns + @column + N',' 
			SET @ref_columns = @ref_columns + @ref_column + N',' 
			FETCH #keycol_cur INTO @column, @ref_column
		END	
		CLOSE #keycol_cur
		DEALLOCATE #keycol_cur
		IF (@key_type = 'NF' or @key_type = 'FK')
		BEGIN
			SET @cascade_update_clause  = N''
			SET @cascade_delete_clause = N''
			SET @cascade_update_clause = 
				CASE (@update_referential_action) 
					WHEN 0 THEN N' ON UPDATE NO ACTION ' 
					WHEN 1 THEN N' ON UPDATE CASCADE ' 
					WHEN 2 THEN N' ON UPDATE SET NULL ' 
					WHEN 3 THEN N' ON UPDATE SET DEFAULT ' 
				END
			SET @cascade_delete_clause = 
				CASE (@delete_referential_action) 
					WHEN 0 THEN N' ON DELETE NO ACTION ' 
					WHEN 1 THEN N' ON DELETE CASCADE ' 
					WHEN 2 THEN N' ON DELETE SET NULL ' 
					WHEN 3 THEN N' ON DELETE SET DEFAULT ' 
				END

			SET @cmd = @cmd + N'(' + LEFT(@columns, LEN(@columns) - 1 ) + N') REFERENCES ' + quotename(@fkschema) + '.' + quotename(@ref_table) + N'(' + LEFT(@ref_columns, LEN(@ref_columns) - 1 ) + N')' + @cascade_update_clause+ @cascade_delete_clause
			IF (@is_disabled = 1)
				SET @cmd = @cmd + N' ALTER TABLE ' + quotename(@schema) + N'.' + quotename(@table) + N' NOCHECK' + N' CONSTRAINT ' + quotename(@constraint)
		END
		ELSE
		BEGIN
			SET @cmd = @cmd + N'(' + LEFT(@columns, LEN(@columns) - 1 ) + N')'
		END
		
	END
		BEGIN TRY
				EXEC(@cmd)
		END TRY
		BEGIN CATCH
			SET @error_log = @error_log + 'Unable to add constraint '+quotename(@constraint)+' to the table '+	quotename(@schema) + N'.' + quotename(@table)+ char(10) + char(13)
			SET @error_log = @error_log + @cmd + char(10) + char(13)
			SET @error_log = @error_log + ' SQL Error Number:'+ cast(ERROR_NUMBER() as varchar(10))+' SQL Error Message:'+ERROR_MESSAGE()+ char(10) + char(13)
		END CATCH
	FETCH #key_cur INTO @table, @object_id, @schema, @constraint, @ref_table, @fkschema, @is_disabled, @update_referential_action, @delete_referential_action
END
CLOSE #key_cur
DEALLOCATE #key_cur
