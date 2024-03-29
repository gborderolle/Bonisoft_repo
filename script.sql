USE [bonisoftdb]
GO
/****** Object:  User [boniadmin]    Script Date: 04-Mar-17 02:52:30 ******/
CREATE USER [boniadmin] FOR LOGIN [boniadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [boniadmin1]    Script Date: 04-Mar-17 02:52:30 ******/
CREATE USER [boniadmin1] FOR LOGIN [boniadmin1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [boniuser]    Script Date: 04-Mar-17 02:52:30 ******/
CREATE USER [boniuser] FOR LOGIN [boniuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [boniadmin]
GO
ALTER ROLE [db_owner] ADD MEMBER [boniadmin1]
GO
ALTER ROLE [db_owner] ADD MEMBER [boniuser]
GO
/****** Object:  Table [dbo].[camion]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[camion](
	[Camion_ID] [int] IDENTITY(2,1) NOT NULL,
	[Ejes_ID] [int] NOT NULL,
	[Matricula_camion] [varchar](100) NOT NULL,
	[Matricula_zorra] [varchar](100) NOT NULL,
	[Marca] [varchar](100) NOT NULL,
	[Tara] [decimal](10, 0) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_camion_Camion_ID] PRIMARY KEY CLUSTERED 
(
	[Camion_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[camion_ejes]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[camion_ejes](
	[Camion_ejes_ID] [int] IDENTITY(1,1) NOT NULL,
	[Ejes] [varchar](30) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_camion_ejes_Camion_ejes_ID] PRIMARY KEY CLUSTERED 
(
	[Camion_ejes_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cargador]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cargador](
	[Cargador_ID] [int] IDENTITY(7,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_cargador_Cargador_ID] PRIMARY KEY CLUSTERED 
(
	[Cargador_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chofer]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chofer](
	[Chofer_ID] [int] IDENTITY(44,1) NOT NULL,
	[Nombre_completo] [varchar](100) NOT NULL,
	[Empresa] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_chofer_Chofer_ID] PRIMARY KEY CLUSTERED 
(
	[Chofer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cliente]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[cliente_ID] [int] IDENTITY(55,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Dueno_nombre] [varchar](100) NOT NULL,
	[Dueno_contacto] [varchar](100) NOT NULL,
	[Encargado_lena_nombre] [varchar](100) NOT NULL,
	[Encargado_lena_contacto] [varchar](100) NOT NULL,
	[Encargado_pagos_nombre] [varchar](100) NOT NULL,
	[Encargado_pagos_contacto] [varchar](100) NOT NULL,
	[Supervisor_lena_nombre] [varchar](100) NOT NULL,
	[Supervisor_lena_contacto] [varchar](100) NOT NULL,
	[Forma_de_pago_ID] [int] NOT NULL,
	[Periodos_liquidacion] [varchar](100) NOT NULL,
	[Fechas_pago] [varchar](100) NOT NULL,
	[RUT] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Nro_cuenta] [varchar](30) NOT NULL,
 CONSTRAINT [PK_cliente_cliente_ID] PRIMARY KEY CLUSTERED 
(
	[cliente_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cliente_pagos]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente_pagos](
	[Cliente_pagos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Cliente_ID] [int] NOT NULL,
	[Fecha_registro] [date] NOT NULL,
	[Fecha_pago] [date] NOT NULL,
	[Forma_de_pago_ID] [int] NOT NULL,
	[Monto] [decimal](10, 0) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_cliente_pagos_Cliente_pagos_ID] PRIMARY KEY CLUSTERED 
(
	[Cliente_pagos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cuadrilla_descarga]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuadrilla_descarga](
	[Cuadrilla_descarga_ID] [int] IDENTITY(23,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_cuadrilla_descarga_Cuadrilla_descarga_ID] PRIMARY KEY CLUSTERED 
(
	[Cuadrilla_descarga_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[descarga_viaje]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[descarga_viaje](
	[Descarga_viaje_ID] [int] NOT NULL,
	[Viaje_ID] [int] NOT NULL,
	[Cuadrilla_ID] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Demora] [int] NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_descarga_viaje_Descarga_viaje_ID] PRIMARY KEY CLUSTERED 
(
	[Descarga_viaje_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fletero]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fletero](
	[Fletero_ID] [int] IDENTITY(48,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Nro_cuenta] [varchar](30) NOT NULL,
 CONSTRAINT [PK_fletero_Fletero_ID] PRIMARY KEY CLUSTERED 
(
	[Fletero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[forma_de_pago]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[forma_de_pago](
	[Forma_de_pago_ID] [int] IDENTITY(1,1) NOT NULL,
	[Forma] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_forma_de_pago_Forma_de_pago_ID] PRIMARY KEY CLUSTERED 
(
	[Forma_de_pago_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[lena_tipo]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lena_tipo](
	[Lena_tipo_ID] [int] IDENTITY(15,1) NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_lena_tipo_Lena_tipo_ID] PRIMARY KEY CLUSTERED 
(
	[Lena_tipo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[log]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log](
	[Log_ID] [int] IDENTITY(145,1) NOT NULL,
	[Fecha] [datetime2](0) NOT NULL,
	[Usuario_ID] [int] NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Dato] [varchar](100) NOT NULL,
 CONSTRAINT [PK_log_Log_ID] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[procesador]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[procesador](
	[Procesador_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_procesador_Procesador_ID] PRIMARY KEY CLUSTERED 
(
	[Procesador_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[Proveedor_ID] [int] IDENTITY(64,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[RUT] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Nro_cuenta] [varchar](30) NOT NULL,
 CONSTRAINT [PK_proveedor_Proveedor_ID] PRIMARY KEY CLUSTERED 
(
	[Proveedor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[proveedor_carga]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor_carga](
	[Proveedor_ID] [int] NOT NULL,
	[Carga_ID] [int] NOT NULL,
 CONSTRAINT [PK_proveedor_carga_Proveedor_ID] PRIMARY KEY CLUSTERED 
(
	[Proveedor_ID] ASC,
	[Carga_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[roles_usuario]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles_usuario](
	[Roles_usuario_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Nivel] [int] NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_roles_usuario_Roles_usuario_ID] PRIMARY KEY CLUSTERED 
(
	[Roles_usuario_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usuario]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[Usuario_ID] [int] IDENTITY(2,1) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Rol_usuario_ID] [int] NOT NULL,
	[EsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_usuario_Usuario_ID] PRIMARY KEY CLUSTERED 
(
	[Usuario_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[viaje]    Script Date: 04-Mar-17 02:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[viaje](
	[Viaje_ID] [int] IDENTITY(126,1) NOT NULL,
	[Cliente_ID] [int] NOT NULL,
	[Proveedor_ID] [int] NOT NULL,
	[Precio_compra_por_tonelada] [decimal](10, 2) NOT NULL,
	[Precio_valor_total] [decimal](10, 2) NOT NULL,
	[Importe_viaje] [decimal](10, 2) NOT NULL,
	[Saldo] [decimal](10, 2) NOT NULL,
	[Empresa_de_carga_ID] [int] NOT NULL,
	[Fecha_partida] [date] NOT NULL,
	[Fecha_llegada] [date] NOT NULL,
	[Camion_ID] [int] NOT NULL,
	[Chofer_ID] [int] NOT NULL,
	[Carga] [varchar](200) NOT NULL,
	[Descarga] [varchar](200) NOT NULL,
	[Fletero_ID] [int] NOT NULL,
	[precio_compra] [decimal](10, 2) NOT NULL,
	[precio_venta] [decimal](10, 2) NOT NULL,
	[precio_flete] [decimal](10, 2) NOT NULL,
	[precio_descarga] [decimal](10, 2) NOT NULL,
	[GananciaXTon] [decimal](10, 2) NOT NULL,
	[IVA] [int] NOT NULL,
	[Comentarios] [varchar](200) NOT NULL,
	[EnViaje] [bit] NOT NULL,
	[Fecha_registro] [date] NULL,
	[isFicticio] [bit] NOT NULL,
	[Mercaderia_Lena_tipo_ID] [int] NOT NULL,
	[Mercaderia_Procesador_ID] [int] NOT NULL,
	[Mercaderia_Fecha_corte] [date] NOT NULL,
	[Mercaderia_Precio_xTonelada_compra] [decimal](10, 2) NOT NULL,
	[Mercaderia_Precio_xTonelada_venta] [decimal](10, 2) NOT NULL,
	[Mercaderia_Comentarios] [varchar](200) NOT NULL,
	[Pesada_Origen_lugar] [varchar](100) NULL,
	[Pesada_Origen_fecha] [date] NOT NULL,
	[Pesada_Origen_peso_bruto] [decimal](10, 0) NOT NULL,
	[Pesada_Origen_peso_neto] [decimal](10, 0) NOT NULL,
	[Pesada_Destino_lugar] [varchar](100) NULL,
	[Pesada_Destino_fecha] [date] NOT NULL,
	[Pesada_Destino_peso_bruto] [decimal](10, 0) NOT NULL,
	[Pesada_Destino_peso_neto] [decimal](10, 0) NOT NULL,
	[Pesada_Comentarios] [varchar](200) NOT NULL,
 CONSTRAINT [PK_viaje_Viaje_ID] PRIMARY KEY CLUSTERED 
(
	[Viaje_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (0x00) FOR [EsAdmin]
GO
ALTER TABLE [dbo].[viaje] ADD  DEFAULT (0x01) FOR [EnViaje]
GO
ALTER TABLE [dbo].[viaje] ADD  DEFAULT (NULL) FOR [Fecha_registro]
GO
ALTER TABLE [dbo].[viaje] ADD  DEFAULT (0x00) FOR [isFicticio]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.camion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'camion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.camion_ejes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'camion_ejes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.cargador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cargador'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.chofer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'chofer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.cliente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.cliente_pagos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cliente_pagos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.cuadrilla_descarga' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cuadrilla_descarga'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.descarga_viaje' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'descarga_viaje'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.fletero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fletero'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.forma_de_pago' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'forma_de_pago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.lena_tipo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'lena_tipo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.`log`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.procesador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'procesador'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.proveedor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'proveedor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.proveedor_carga' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'proveedor_carga'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.roles_usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'roles_usuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'usuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'bonisoft_db.viaje' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'viaje'
GO
