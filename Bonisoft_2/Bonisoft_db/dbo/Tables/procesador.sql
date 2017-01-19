CREATE TABLE [dbo].[procesador] (
    [Procesador_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (100) NOT NULL,
    [Direccion]     VARCHAR (100) NOT NULL,
    [Telefono]      VARCHAR (100) NOT NULL,
    [Comentarios]   VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_procesador_Procesador_ID] PRIMARY KEY CLUSTERED ([Procesador_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.procesador', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'procesador';

