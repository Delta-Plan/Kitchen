﻿CREATE DATABASE KitchenDb
GO
USE KitchenDb
GO

CREATE TABLE dbo.Users
(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
RoleId INT NOT NULL,
Name VARCHAR(32) )

CREATE TABLE dbo.Roles(
Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(32),
"Description" VARCHAR(64))

CREATE TABLE dbo.Recipes(
Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
OwnerId int NOT NULL,
Name VARCHAR(32),
"Description" VARCHAR(256),
IsPublic BIT NOT NULL,
IngridientsJson VARCHAR(512))
GO
