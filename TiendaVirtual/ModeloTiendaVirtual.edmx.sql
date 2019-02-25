
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2019 21:51:25
-- Generated from EDMX file: C:\Users\alexp\Documents\miw\net\workspace\TiendaVirtual\TiendaVirtual\ModeloTiendaVirtual.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TiendaVirtualDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PedidoProducto_Pedidos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoProducto] DROP CONSTRAINT [FK_PedidoProducto_Pedidos];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoProducto_Productos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoProducto] DROP CONSTRAINT [FK_PedidoProducto_Productos];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO
IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[PedidoProducto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoProducto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cliente] varchar(50)  NULL,
    [Direccion] varchar(200)  NULL,
    [Fecha] datetime  NULL,
    [Factura] float  NULL
);
GO

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Descripcion] varchar(200)  NULL,
    [Precio] float  NULL,
    [Cantidad] nvarchar(max)  NULL,
    [Imagen] nvarchar(max)  NULL
);
GO

-- Creating table 'PedidoProducto'
CREATE TABLE [dbo].[PedidoProducto] (
    [Pedidos_Id] int  NOT NULL,
    [Productos_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Pedidos_Id], [Productos_Id] in table 'PedidoProducto'
ALTER TABLE [dbo].[PedidoProducto]
ADD CONSTRAINT [PK_PedidoProducto]
    PRIMARY KEY CLUSTERED ([Pedidos_Id], [Productos_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Pedidos_Id] in table 'PedidoProducto'
ALTER TABLE [dbo].[PedidoProducto]
ADD CONSTRAINT [FK_PedidoProducto_Pedidos]
    FOREIGN KEY ([Pedidos_Id])
    REFERENCES [dbo].[Pedidos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Productos_Id] in table 'PedidoProducto'
ALTER TABLE [dbo].[PedidoProducto]
ADD CONSTRAINT [FK_PedidoProducto_Productos]
    FOREIGN KEY ([Productos_Id])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoProducto_Productos'
CREATE INDEX [IX_FK_PedidoProducto_Productos]
ON [dbo].[PedidoProducto]
    ([Productos_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------