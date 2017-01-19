CREATE TABLE [dbo].[cliente] (
    [cliente_ID]               INT           IDENTITY (55, 1) NOT NULL,
    [Nombre]                   VARCHAR (100) NOT NULL,
    [Dueno_nombre]             VARCHAR (100) NOT NULL,
    [Dueno_contacto]           VARCHAR (100) NOT NULL,
    [Encargado_lena_nombre]    VARCHAR (100) NOT NULL,
    [Encargado_lena_contacto]  VARCHAR (100) NOT NULL,
    [Encargado_pagos_nombre]   VARCHAR (100) NOT NULL,
    [Encargado_pagos_contacto] VARCHAR (100) NOT NULL,
    [Supervisor_lena_nombre]   VARCHAR (100) NOT NULL,
    [Supervisor_lena_contacto] VARCHAR (100) NOT NULL,
    [Forma_de_pago_ID]         INT           NOT NULL,
    [Periodos_liquidacion]     VARCHAR (100) NOT NULL,
    [Fechas_pago]              VARCHAR (100) NOT NULL,
    [RUT]                      VARCHAR (100) NOT NULL,
    [Direccion]                VARCHAR (200) NOT NULL,
    [Telefono]                 VARCHAR (100) NOT NULL,
    [Comentarios]              VARCHAR (200) NOT NULL,
    [Email]                    VARCHAR (30)  NOT NULL,
    [Nro_cuenta]               VARCHAR (30)  NOT NULL,
    CONSTRAINT [PK_cliente_cliente_ID] PRIMARY KEY CLUSTERED ([cliente_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.cliente', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'cliente';

