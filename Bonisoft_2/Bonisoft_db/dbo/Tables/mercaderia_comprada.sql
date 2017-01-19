CREATE TABLE [dbo].[mercaderia_comprada] (
    [Mercaderia_ID]           INT             IDENTITY (70, 1) NOT NULL,
    [Viaje_ID]                INT             NOT NULL,
    [Variedad_ID]             INT             NOT NULL,
    [Procesador_ID]           INT             NOT NULL,
    [Fecha_corte]             DATE            NOT NULL,
    [Precio_xTonelada_compra] DECIMAL (10, 2) NOT NULL,
    [Precio_xTonelada_venta]  DECIMAL (10)    NOT NULL,
    [Comentarios]             VARCHAR (200)   NOT NULL,
    CONSTRAINT [PK_mercaderia_comprada_Mercaderia_ID] PRIMARY KEY CLUSTERED ([Mercaderia_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.mercaderia_comprada', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'mercaderia_comprada';

