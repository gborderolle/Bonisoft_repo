CREATE TABLE [dbo].[camion_ejes] (
    [Camion_ejes_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Ejes]           VARCHAR (30)  NOT NULL,
    [Comentarios]    VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_camion_ejes_Camion_ejes_ID] PRIMARY KEY CLUSTERED ([Camion_ejes_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.camion_ejes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'camion_ejes';

