Create database TestXabierSanMartin

USE [TestXabierSanMartin]

CREATE TABLE [dbo].[Categorias](
			[IdCategoria] [int] NOT NULL,
			[Descripcion] [nvarchar](100) NOT NULL,

CONSTRAINT [PK_TCategorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Test](
			[IdTest] [int] NOT NULL,
			[Descripcion] [nvarchar](100) NOT NULL,

CONSTRAINT [PK_TTest] PRIMARY KEY CLUSTERED 
(
	[IdTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Preguntas](
			[Npregunta] [int] NOT NULL,
			[Enunciado] [nvarchar](100) NOT NULL,
			[RespV] [bit] NOT NULL,
			[IdTest] [int] NOT NULL
)


CREATE TABLE [dbo].[CategoriasTests](
			[IdCategoria] [int] NOT NULL,
			[IdTest] [int] NOT NULL,

CONSTRAINT [PK_TCategoriasTests] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC,
	[IdTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[CategoriasTests]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasTests_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[CategoriasTests] CHECK CONSTRAINT [FK_CategoriasTests_Categorias]

ALTER TABLE [dbo].[CategoriasTests]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasTests_Test] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([IdTest])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[CategoriasTests] CHECK CONSTRAINT [FK_CategoriasTests_Test]



ALTER TABLE [dbo].[Preguntas] WITH CHECK ADD CONSTRAINT [FK_TPreguntas_TTest] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([IdTest])





