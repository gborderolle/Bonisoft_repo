CREATE TABLE [dbo].[chofer] (
    [Chofer_ID]       INT           IDENTITY (44, 1) NOT NULL,
    [Nombre_completo] VARCHAR (100) NOT NULL,
    [Empresa]         VARCHAR (100) NOT NULL,
    [Comentarios]     VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_chofer_Chofer_ID] PRIMARY KEY CLUSTERED ([Chofer_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.chofer', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'chofer';

