--01.Database Introduction - Exercise (1-6)
--Exercise 01: Create Database
CREATE DATABASE [Minions]

GO 
--Exercise 02: Create Tables
USE [Minions]

GO

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT,
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(80) NOT NULL
)

GO
--Exercise 03: Alter Minions Table
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])

--Add a new collumn "TownId" which is a foreign key that references the "Id" (PK) collumn from the "Towns" table
--NOTE: Unlike PK, FK allows null element and duplicates!

GO
--Exercise 04: Insert Records In Both Tables
INSERT INTO [Towns]([Id], [Name])
VALUES 
(1, 'Sofia'),
(2, 'Plovidiv'),
(3, 'Varna')

GO

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

GO
--Exercise 05: Truncate Table Minions
TRUNCATE TABLE [Minions]
--Alternatelly
DELETE FROM [Minions]

GO
--Exercise 06: Drop All Tables
DROP TABLE [Minions]
DROP TABLE [Towns]