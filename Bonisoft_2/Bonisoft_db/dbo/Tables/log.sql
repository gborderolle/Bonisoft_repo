CREATE TABLE [dbo].[log] (
    [Log_ID]      INT           IDENTITY (145, 1) NOT NULL,
    [Fecha]       DATETIME2 (0) NOT NULL,
    [Usuario_ID]  INT           NOT NULL,
    [Usuario]     VARCHAR (100) NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [Dato]        VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_log_Log_ID] PRIMARY KEY CLUSTERED ([Log_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.`log`', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'log';

