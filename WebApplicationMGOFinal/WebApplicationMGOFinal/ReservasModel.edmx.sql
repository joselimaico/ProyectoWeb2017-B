
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/31/2018 10:42:49
-- Generated from EDMX file: C:\Users\Jose\source\repos\WebApplicationMGOFinal\WebApplicationMGOFinal\ReservasModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DatabaseReservas];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ReservaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReservaSet];
GO
IF OBJECT_ID(N'[dbo].[DiaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiaSet];
GO
IF OBJECT_ID(N'[dbo].[AdministradorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdministradorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ReservaSet'
CREATE TABLE [dbo].[ReservaSet] (
    [IdReserva] int IDENTITY(1,1) NOT NULL,
    [NombreCliente] nvarchar(max)  NOT NULL,
    [TelefonoCliente] nvarchar(max)  NOT NULL,
    [CorreoCliente] nvarchar(max)  NOT NULL,
    [NumeroPersonas] int  NOT NULL,
    [InstitucionCliente] nvarchar(max)  NULL,
    [ApellidoCliente] nvarchar(max)  NOT NULL,
    [EstadoReserva] nvarchar(max)  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [Color] nvarchar(max)  NOT NULL,
    [IsFullDay] tinyint  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DiaSet'
CREATE TABLE [dbo].[DiaSet] (
    [IdDia] int IDENTITY(1,1) NOT NULL,
    [año] nvarchar(max)  NOT NULL,
    [mes] nvarchar(max)  NOT NULL,
    [dia] nvarchar(max)  NOT NULL,
    [estadoDia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdministradorSet'
CREATE TABLE [dbo].[AdministradorSet] (
    [IdAdmin] int IDENTITY(1,1) NOT NULL,
    [NombreUsuario] nvarchar(max)  NOT NULL,
    [ContraseñaUsuario] nvarchar(max)  NOT NULL,
    [CargoAdmin] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdReserva] in table 'ReservaSet'
ALTER TABLE [dbo].[ReservaSet]
ADD CONSTRAINT [PK_ReservaSet]
    PRIMARY KEY CLUSTERED ([IdReserva] ASC);
GO

-- Creating primary key on [IdDia] in table 'DiaSet'
ALTER TABLE [dbo].[DiaSet]
ADD CONSTRAINT [PK_DiaSet]
    PRIMARY KEY CLUSTERED ([IdDia] ASC);
GO

-- Creating primary key on [IdAdmin] in table 'AdministradorSet'
ALTER TABLE [dbo].[AdministradorSet]
ADD CONSTRAINT [PK_AdministradorSet]
    PRIMARY KEY CLUSTERED ([IdAdmin] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------