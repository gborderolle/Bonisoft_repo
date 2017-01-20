CREATE TABLE [dbo].[cargador] (
    [Cargador_ID] INT           IDENTITY (7, 1) NOT NULL,
    [Nombre]      VARCHAR (100) NOT NULL,
    [Direccion]   VARCHAR (100) NOT NULL,
    [Telefono]    VARCHAR (100) NOT NULL,
    [Comentarios] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_cargador_Cargador_ID] PRIMARY KEY CLUSTERED ([Cargador_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.cargador', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'cargador';

