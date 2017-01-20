CREATE TABLE [dbo].[proveedor_mercaderia] (
    [Proveedor_ID]  INT NOT NULL,
    [Mercaderia_ID] INT NOT NULL,
    CONSTRAINT [PK_proveedor_mercaderia_Proveedor_ID] PRIMARY KEY CLUSTERED ([Proveedor_ID] ASC, [Mercaderia_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.proveedor_mercaderia', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'proveedor_mercaderia';

