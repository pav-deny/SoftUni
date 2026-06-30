---------------------
-- Table Relations --
---------------------
CREATE DATABASE [Lab]
GO

USE [Lab]
GO

-- One-to-many / Many-to-one relation
CREATE TABLE [Mountains] 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Peaks]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[MountainId] INT, 
	CONSTRAINT [FK_Peaks_Mountains]
	FOREIGN KEY ([MountainId])
	REFERENCES [Mountains]([Id])
)

-- Many-to-many relation

CREATE TABLE [Employees] 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[MiddleName] VARCHAR(50),
	[LastName] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

CREATE TABLE [Projects]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(100),
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME
)

CREATE TABLE [EmployeesProjects]
(
	[EmployeeId] INT,
	[ProjectId] INT,

	CONSTRAINT [PK_EmployeesProjects]
	PRIMARY KEY ([EmployeeId], [ProjectId]),

	CONSTRAINT [FK_EmployeesProjects_Employees]
	FOREIGN KEY ([EmployeeId])
	REFERENCES [Employees]([Id]),

	CONSTRAINT [FK_EmployeesProjects_Projects]
	FOREIGN KEY ([ProjectId])
	REFERENCES [Projects]([Id])
)

-- One-to-one relation
CREATE TABLE [Drivers]
(
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY,
	[Model] VARCHAR(100) NOT NULL,
	[DriverId] INT UNIQUE,

	CONSTRAINT [FK_Cars_Drivers]
	FOREIGN KEY ([DriverId])
	REFERENCES [Drivers]([Id])
)

-- Problem: Peaks In Rila
USE [Geography]
GO

SELECT 
		m.[MountainRange],
		p.[PeakName],
		p.[Elevation]
FROM [Mountains] AS m JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
WHERE m.[MountainRange] = 'Rila'
ORDER BY p.[Elevation] DESC


---------------
-- Cascading --
---------------
USE [Lab]
GO

DROP TABLE [Cars]
DROP TABLE [Drivers]

GO

-- Cascade delete
CREATE TABLE [Drivers]
(
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY,
	[Model] VARCHAR(100) NOT NULL,
	[DriverId] INT UNIQUE,

	CONSTRAINT [FK_Cars_Drivers]
	FOREIGN KEY ([DriverId])
	REFERENCES [Drivers]([Id]) ON DELETE CASCADE
)

INSERT INTO [Drivers] ([Id], [Name])
VALUES
(1, 'John Smith'),
(2, 'Emma Johnson'),
(3, 'Michael Brown'),
(4, 'Sophia Davis'),
(5, 'William Wilson');

INSERT INTO [Cars] ([Id], [Model], [DriverId])
VALUES
(1, 'Toyota Corolla', 1),
(2, 'Honda Civic', 2),
(3, 'Ford Focus', 3),
(4, 'BMW 320i', 4),
(5, 'Audi A4', 5);

DELETE FROM [Drivers]
WHERE [Id] = 3

SELECT * FROM [Drivers]
SELECT * FROM [Cars]

-- Cascade update
CREATE TABLE [Products]
(
 [BarcodeId] INT PRIMARY KEY,
 Name VARCHAR(50)
)

CREATE TABLE Stock(
 [Id] INT PRIMARY KEY,
 [Barcode] INT,
 [BarcodeId] INT,
 CONSTRAINT [FK_Stock_Products] FOREIGN KEY(BarcodeId)
 REFERENCES [Products]([BarcodeId]) ON UPDATE CASCADE
)

INSERT INTO [Products] ([BarcodeId], [Name])
VALUES
(1001, 'Laptop'),
(1002, 'Keyboard'),
(1003, 'Mouse'),
(1004, 'Monitor'),
(1005, 'Printer');

INSERT INTO [Stock] ([Id], [Barcode], [BarcodeId])
VALUES
(1, 50001, 1001),
(2, 50002, 1002),
(3, 50003, 1003),
(4, 50004, 1004),
(5, 50005, 1005);

UPDATE [Products]
SET [BarcodeId] = 2001
WHERE [BarcodeId] = 1001

SELECT * FROM [Products]
SELECT * FROM [Stock]