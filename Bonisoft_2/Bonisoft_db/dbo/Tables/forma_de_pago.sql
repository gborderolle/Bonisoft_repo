CREATE TABLE [dbo].[forma_de_pago] (
    [Forma_de_pago_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Forma]            VARCHAR (100) NOT NULL,
    [Comentarios]      VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_forma_de_pago_Forma_de_pago_ID] PRIMARY KEY CLUSTERED ([Forma_de_pago_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.forma_de_pago', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'forma_de_pago';

