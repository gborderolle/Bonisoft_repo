CREATE TABLE [dbo].[cuadrilla_descarga] (
    [Cuadrilla_descarga_ID] INT           IDENTITY (23, 1) NOT NULL,
    [Nombre]                VARCHAR (100) NOT NULL,
    [Direccion]             VARCHAR (100) NOT NULL,
    [Telefono]              VARCHAR (100) NOT NULL,
    [Comentarios]           VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_cuadrilla_descarga_Cuadrilla_descarga_ID] PRIMARY KEY CLUSTERED ([Cuadrilla_descarga_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.cuadrilla_descarga', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'cuadrilla_descarga';

