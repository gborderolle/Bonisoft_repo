CREATE TABLE [dbo].[cliente_pagos] (
    [Cliente_pagos_ID] INT           IDENTITY (2, 1) NOT NULL,
    [Cliente_ID]       INT           NOT NULL,
    [Fecha_registro]   DATE          NOT NULL,
    [Fecha_pago]       DATE          NOT NULL,
    [Forma_de_pago_ID] INT           NOT NULL,
    [Monto]            DECIMAL (10)  NOT NULL,
    [Comentarios]      VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_cliente_pagos_Cliente_pagos_ID] PRIMARY KEY CLUSTERED ([Cliente_pagos_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.cliente_pagos', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'cliente_pagos';

