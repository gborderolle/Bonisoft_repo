CREATE TABLE [dbo].[proveedor_carga] (
    [Proveedor_ID] INT NOT NULL,
    [Carga_ID]     INT NOT NULL,
    CONSTRAINT [PK_proveedor_carga_Proveedor_ID] PRIMARY KEY CLUSTERED ([Proveedor_ID] ASC, [Carga_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.proveedor_carga', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'proveedor_carga';

