CREATE TABLE [dbo].[camion] (
    [Camion_ID]        INT           IDENTITY (2, 1) NOT NULL,
    [Ejes_ID]          INT           NOT NULL,
    [Matricula_camion] VARCHAR (100) NOT NULL,
    [Matricula_zorra]  VARCHAR (100) NOT NULL,
    [Marca]            VARCHAR (100) NOT NULL,
    [Tara]             DECIMAL (10)  NOT NULL,
    [Comentarios]      VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_camion_Camion_ID] PRIMARY KEY CLUSTERED ([Camion_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.camion', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'camion';

