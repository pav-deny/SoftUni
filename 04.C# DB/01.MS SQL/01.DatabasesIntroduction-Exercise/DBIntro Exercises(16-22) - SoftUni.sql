--01.Database Introduction - Exercise (16-22)
--Exercise 16: Create SoftUni Database
USE [master]
CREATE DATABASE [SoftUni]

GO
USE[SoftUni]

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Addresses] (
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] VARCHAR(max) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [Departments] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[MiddleName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[JobTitle] VARCHAR(100) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL,
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL(8,2) NOT NULL,
	[AdressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)
GO
--Exercise 17: Backup Database
USE [SoftUni]
GO
--Done with GUI

GO
--Exercise 18: Basic Insert
INSERT INTO [Towns]([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

GO

INSERT INTO [Departments]([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Asurance')

GO
INSERT INTO [Addresses]([AddressText], [TownId])
VALUES
('Hristo Botev 1', 1),
('Vasil Levski 25', 3),
('Ivan Vazov 3', 2),
('Aleksandur Stambloiiski 20', 4)

GO

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.Net Developer', 4, '2013-02-01', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);

GO
--Exercise 19: Basic Select All Fields
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

GO
--Exercise 20: Basic Select All Fields And Order Them
SELECT * FROM [Towns]
ORDER BY [Name]

SELECT * FROM [Departments]
ORDER BY [Name]

SELECT * FROM [Employees]
ORDER BY [Salary]
DESC

GO
--Exercise 21: Basic Select Some Fields
SELECT [Name] 
FROM [Towns]
ORDER BY [Name]

SELECT [Name] 
FROM [Departments]
ORDER BY [Name]

SELECT [FirstName], 
		[LastName], 
		[JobTitle], 
		[Salary] 
FROM [Employees]
ORDER BY [Salary]
DESC

GO
--Exercise 21: Increase Employee Salary
UPDATE [Employees]
SET [Salary] *= 1.10

SELECT [Salary] FROM [Employees]