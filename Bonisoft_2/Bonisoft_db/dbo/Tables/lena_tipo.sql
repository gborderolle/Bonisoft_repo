CREATE TABLE [dbo].[lena_tipo] (
    [Lena_tipo_ID] INT           IDENTITY (15, 1) NOT NULL,
    [Tipo]         VARCHAR (100) NOT NULL,
    [Comentarios]  VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_lena_tipo_Lena_tipo_ID] PRIMARY KEY CLUSTERED ([Lena_tipo_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.lena_tipo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'lena_tipo';

