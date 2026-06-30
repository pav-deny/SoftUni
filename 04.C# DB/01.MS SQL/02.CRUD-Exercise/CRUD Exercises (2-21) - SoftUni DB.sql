--02.CRUD - Exercise (1-21)
USE [SoftUni]

--Exercise 01: Examine The Databases
--Done with GUI

GO
--Exercise 02: Find All Information About Departments
SELECT * 
FROM [Departments]

GO
--Exercise 03: Find All Department Names
SELECT [Name]
FROM [Departments]

GO
--Exercise 04: Find Salary Of Each Employee
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]

GO
--Exercise 05: Find Full Name Of Each Employee
SELECT [FirstName], [MiddleName], [LastName]
FROM [Employees]

GO
--Exercise 06: Find Email Address Of Each Employee
SELECT [FirstName] + '.' + [LastName] + '@' + 'softuni.bg' AS [Full Email Address]
FROM [Employees]

GO
--Exercise 07: Find All Different Employees' Salaries
SELECT DISTINCT [Salary]
FROM [Employees]


GO
--Exercise 08: Find All Information About Employees
SELECT *
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'

GO
--Exercise 09: Find Names Of All Employees By Salary In Range
SELECT [FirstName],
		[LastName],
		[JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

GO
--Exercise 10: Find Names Of All Employees
SELECT CONCAT_WS(' ', [FirstName], [MiddleName], [LastName]) AS [Full Name]
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)

GO
--Exercise 11: Find All Employees Without A Manager
SELECT [FirstName],
		[LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL

GO
--Exercise 12: Find All Employees With A Salary More Than 50000
SELECT [FirstName],
		[LastName],
		[Salary]
FROM [Employees]
WHERE [Salary] >= 50000
ORDER BY [Salary]
DESC

GO
--Exercise 13: Find 5 Best Paid Employees
SELECT TOP(5) [FirstName],
			   [LastName]
FROM [Employees]
ORDER BY [Salary]
DESC

GO
--Exercise 14: Find All Employees Except Marketing
SELECT [FirstName],
		[LastName]
FROM [Employees]
WHERE [DepartmentID] != 4

GO
--Exercise 15: Sort Employees Table
SELECT *
FROM [Employees]
ORDER BY [Salary] DESC,
		[FirstName] ASC,
		[LastName] DESC,
		[MiddleName] ASC

GO
--Exercise 16: Create View Employees With Salaries
CREATE VIEW [V_EmployeesSalaries] AS
			(
				SELECT [FirstName],
						[LastName],
						[Salary]
				FROM [Employees]
			)

GO
SELECT *
FROM [V_EmployeesSalaries]

GO
--Exercise 17: Create View Employees With Job Title
CREATE VIEW [V_EmployeeNameJobTitle] AS 
			(
				SELECT [FirstName] + ' ' + ISNULL([MiddleName], '') + ' ' + [LastName] AS [Full Name],
						[JobTitle]
					FROM [Employees]
			)
GO
SELECT *
	FROM [V_EmployeeNameJobTitle]

GO
--Exercise 18: Distinct Job Titles
SELECT DISTINCT [JobTitle]
FROM [Employees]

GO
--Exercise 19: Find First 10 Started Projects
SELECT TOP(10) *
FROM [Projects]
ORDER BY [StartDate],
[Name]

GO
--Exercise 20: Last 7 Hired Employees
SELECT TOP(7) [FirstName],
		[LastName],
		[HireDate]
FROM [Employees]
ORDER BY [HireDate] DESC

GO
--Exercise 21: Increase Salaries
SELECT * 
FROM [Employees]
WHERE [DepartmentID] IN (1, 2, 4, 11)

UPDATE [Employees]
	SET [Salary] += [Salary] * 0.12 -- +12% of the old salary
WHERE [DepartmentID] IN (1, 2, 4, 11) 

GO

SELECT [Salary]
FROM [Employees]
WHERE [DepartmentID] IN (1, 2, 4, 11) 	