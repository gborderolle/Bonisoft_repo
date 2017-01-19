CREATE TABLE [dbo].[usuario] (
    [Usuario_ID]     INT           IDENTITY (2, 1) NOT NULL,
    [Usuario]        VARCHAR (100) NOT NULL,
    [Clave]          VARCHAR (100) NOT NULL,
    [Rol_usuario_ID] INT           NOT NULL,
    [EsAdmin]        BIT           DEFAULT (0x00) NOT NULL,
    CONSTRAINT [PK_usuario_Usuario_ID] PRIMARY KEY CLUSTERED ([Usuario_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.usuario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'usuario';

