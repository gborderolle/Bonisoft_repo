CREATE TABLE [dbo].[fletero] (
    [Fletero_ID]  INT           IDENTITY (48, 1) NOT NULL,
    [Nombre]      VARCHAR (100) NOT NULL,
    [Direccion]   VARCHAR (100) NOT NULL,
    [Telefono]    VARCHAR (100) NOT NULL,
    [Comentarios] VARCHAR (200) NOT NULL,
    [Email]       VARCHAR (30)  NOT NULL,
    [Nro_cuenta]  VARCHAR (30)  NOT NULL,
    CONSTRAINT [PK_fletero_Fletero_ID] PRIMARY KEY CLUSTERED ([Fletero_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.fletero', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'fletero';

