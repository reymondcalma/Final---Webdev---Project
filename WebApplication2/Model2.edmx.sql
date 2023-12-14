
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2023 13:40:34
-- Generated from EDMX file: C:\Users\User\Downloads\WebApplication2\WebApplication2\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [friends];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_user_role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user] DROP CONSTRAINT [FK_user_role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[role];
GO
IF OBJECT_ID(N'[dbo].[user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'roles'
CREATE TABLE [dbo].[roles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [role_name] varchar(50)  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [firstname] varchar(50)  NULL,
    [lastname] varchar(50)  NULL,
    [email] varchar(50)  NULL,
    [password] varchar(50)  NULL,
    [role_id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'roles'
ALTER TABLE [dbo].[roles]
ADD CONSTRAINT [PK_roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [role_id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [FK_user_role]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_user_role'
CREATE INDEX [IX_FK_user_role]
ON [dbo].[users]
    ([role_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------