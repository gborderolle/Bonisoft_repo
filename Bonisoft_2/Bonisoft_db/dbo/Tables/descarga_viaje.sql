CREATE TABLE [dbo].[descarga_viaje] (
    [Descarga_viaje_ID] INT           NOT NULL,
    [Viaje_ID]          INT           NOT NULL,
    [Cuadrilla_ID]      INT           NOT NULL,
    [Fecha]             DATE          NOT NULL,
    [Demora]            INT           NOT NULL,
    [Comentarios]       VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_descarga_viaje_Descarga_viaje_ID] PRIMARY KEY CLUSTERED ([Descarga_viaje_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.descarga_viaje', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'descarga_viaje';

