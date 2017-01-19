CREATE TABLE [dbo].[viaje] (
    [Viaje_ID]                   INT             IDENTITY (126, 1) NOT NULL,
    [Cliente_ID]                 INT             NOT NULL,
    [Proveedor_ID]               INT             NOT NULL,
    [Precio_compra_por_tonelada] DECIMAL (10, 2) NOT NULL,
    [Precio_valor_total]         DECIMAL (10, 2) NOT NULL,
    [Importe_viaje]              DECIMAL (10, 2) NOT NULL,
    [Saldo]                      DECIMAL (10, 2) NOT NULL,
    [Pesada_ID]                  INT             NOT NULL,
    [Empresa_de_carga_ID]        INT             NOT NULL,
    [Fecha_partida]              DATE            NOT NULL,
    [Fecha_llegada]              DATE            NOT NULL,
    [Camion_ID]                  INT             NOT NULL,
    [Chofer_ID]                  INT             NOT NULL,
    [Carga]                      VARCHAR (200)   NOT NULL,
    [Descarga]                   VARCHAR (200)   NOT NULL,
    [Fletero_ID]                 INT             NOT NULL,
    [precio_compra]              DECIMAL (10, 2) NOT NULL,
    [precio_venta]               DECIMAL (10, 2) NOT NULL,
    [precio_flete]               DECIMAL (10, 2) NOT NULL,
    [precio_descarga]            DECIMAL (10, 2) NOT NULL,
    [GananciaXTon]               DECIMAL (10, 2) NOT NULL,
    [IVA]                        INT             NOT NULL,
    [Comentarios]                VARCHAR (200)   NOT NULL,
    [EnViaje]                    BIT             DEFAULT (0x01) NOT NULL,
    [Fecha_registro]             DATE            DEFAULT (NULL) NULL,
    [isFicticio]                 BIT             DEFAULT (0x00) NOT NULL,
    CONSTRAINT [PK_viaje_Viaje_ID] PRIMARY KEY CLUSTERED ([Viaje_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.viaje', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'viaje';

