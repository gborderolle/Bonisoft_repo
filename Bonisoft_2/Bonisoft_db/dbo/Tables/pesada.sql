CREATE TABLE [dbo].[pesada] (
    [pesada_ID]              INT           IDENTITY (97, 1) NOT NULL,
    [Origen_lugar]           VARCHAR (100) DEFAULT (NULL) NULL,
    [Origen_fecha]           DATE          NOT NULL,
    [Origen_nombre_balanza]  VARCHAR (100) DEFAULT (NULL) NULL,
    [Origen_peso_bruto]      DECIMAL (10)  NOT NULL,
    [Origen_peso_neto]       DECIMAL (10)  NOT NULL,
    [Destino_lugar]          VARCHAR (100) DEFAULT (NULL) NULL,
    [Destino_fecha]          DATE          NOT NULL,
    [Destino_nombre_balanza] VARCHAR (100) DEFAULT (NULL) NULL,
    [Destino_peso_bruto]     DECIMAL (10)  NOT NULL,
    [Destino_peso_neto]      DECIMAL (10)  NOT NULL,
    [Comentarios]            VARCHAR (200) DEFAULT (NULL) NULL,
    CONSTRAINT [PK_pesada_pesada_ID] PRIMARY KEY CLUSTERED ([pesada_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.pesada', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'pesada';

