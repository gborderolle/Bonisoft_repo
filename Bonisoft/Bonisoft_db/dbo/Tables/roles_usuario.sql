CREATE TABLE [dbo].[roles_usuario] (
    [Roles_usuario_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]           VARCHAR (100) NOT NULL,
    [Nivel]            INT           NOT NULL,
    [Comentarios]      VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_roles_usuario_Roles_usuario_ID] PRIMARY KEY CLUSTERED ([Roles_usuario_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'bonisoft_db.roles_usuario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'roles_usuario';

