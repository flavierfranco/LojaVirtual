
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Telefone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImagensProdutos]    Script Date: 18/02/2021 15:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagensProdutos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Caminho] [varchar](max) NOT NULL,
	[ProdutoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 18/02/2021 15:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[Descricao] [varchar](max) NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Quantidade] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ImagensProdutos] ON 
GO
INSERT [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (7004, N'\uploads\1004\calca-jeans.jpg', 1004)
GO
INSERT [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (8002, N'\uploads\6004\camiseta-preta.jpg', 6004)
GO
INSERT [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9003, N'\uploads\8004\Bermuda.jpg', 8004)
GO
INSERT [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9006, N'\uploads\1\camiseta-branca.jpg', 1)
GO
INSERT [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9007, N'\uploads\9004\vestido-verde-curto.jpg', 9004)
GO
INSERT [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9008, N'\uploads\9009\Vestido-azul.jpg', 9009)
GO
SET IDENTITY_INSERT [dbo].[ImagensProdutos] OFF
GO
SET IDENTITY_INSERT [dbo].[Produtos] ON 
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade]) VALUES (1, N'Camiseta Branca', N'', CAST(30.00 AS Decimal(18, 2)), 100)
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade]) VALUES (1004, N'Calça Jeans', N'', CAST(100.00 AS Decimal(18, 2)), 100)
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade]) VALUES (6004, N'Camiseta Preta', N'', CAST(35.00 AS Decimal(18, 2)), 100)
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade]) VALUES (8004, N'Bermuda', N'', CAST(112.00 AS Decimal(18, 2)), 100)
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade]) VALUES (9004, N'Vestido verde', N'', CAST(100.00 AS Decimal(18, 2)), 100)
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade]) VALUES (9009, N'Vestido Azul', N'', CAST(125.00 AS Decimal(18, 2)), 100)
GO
SET IDENTITY_INSERT [dbo].[Produtos] OFF
GO
ALTER TABLE [dbo].[ImagensProdutos]  WITH CHECK ADD FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produtos] ([Id])
GO
