USE [SoftUni]
GO

---------------------
-- Retrieving Data --
---------------------

SELECT * 
FROM [Employees] -- Everything (a lot)

SELECT	[FirstName], [LastName], [JobTitle]
FROM [Employees] -- Projection (smaller)

SELECT *
FROM [Employees]
WHERE [DepartmentID] = 3 -- Selection (smaller)

SELECT [FirstName], [LastName], [JobTitle]
FROM [Employees] 
WHERE [DepartmentID] = 3 -- Projection and Selection (smallest)

SELECT 
		[FirstName] AS [Първо Име], 
		[LastName] AS [Фамилия],
		[JobTitle], 
		d.[Name] as [Department Name]
FROM [Employees] AS e JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID -- Join
WHERE e.[DepartmentID] IN (1, 3, 5) -- Join and assigning different names for viewing

-- Concatanation
SELECT [FirstName] + ' ' + [MiddleName] + '' + [LastName] AS [Full Name]
FROM [Employees] -- If [MiddleName] is NULL the output is NULL if we use [+] for concatanation

SELECT CONCAT_WS(' ', [FirstName], [MiddleName], [LastName]) 
FROM [Employees] -- If [MiddleName] is NULL the output is [FirstName] + ' ' + [LastName]

SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) 
FROM [Employees] -- If [MiddleName] is NULL the output is [FirstName] + ' ' + ' ' + [LastName]

/* + as concatanation makes '1' + 1 = 2
CONCAT() makes '1' + 1 = '11'
CONCAT_WS() makes '1' + 1 = '11'
*/

-- Problem: Employee Summary
SELECT 
		CONCAT_WS(' ', [FirstName], [LastName]) AS [Full Name],
		[JobTitle],
		[Salary]
	FROM [Employees]

-- Distinct -- selects only UNIQUE values
SELECT DISTINCT
		[DepartmentID],
		[Salary]
FROM [Employees]

-- Filtering - WHERE
SELECT 
		[LastName],
		[DepartmentID]
FROM [Employees]
WHERE [DepartmentID]= 1

SELECT 
		[LastName],
		[DepartmentID],
		[Salary]
FROM [Employees]
WHERE [DepartmentID] <> 3 -- [<>] = [!=]

-- Logic operators: NOT, OR, AND
SELECT [LastName] 
FROM [Employees]
WHERE NOT ([ManagerID] = 3 OR [ManagerID] = 4)

-- Between - specify range
SELECT [LastName], [Salary]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 22000

-- IN / NOT IN () - search a set of values
SELECT [FirstName], [LastName], [ManagerID]
FROM [Employees]
WHERE [ManagerID] IN (109, 3, 6)

-- NULL (NULL != 0, NULL != ' ', NULL != NULL)
SELECT [LastName], [ManagerID]
FROM [Employees]
WHERE [ManagerID] = NULL -- Doesn't work

SELECT [LastName], [ManagerID]
FROM [Employees]
WHERE [ManagerID] IS NULL -- Works

SELECT [LastName], [ManagerID]
FROM [Employees]
WHERE [ManagerID] != NULL -- Doesn't work

SELECT [LastName], [ManagerID]
FROM [Employees]
WHERE [ManagerID] IS NOT NULL -- Works

-- Sorting: ASC - ascending, DEC - descending
SELECT TOP(4) *
FROM [Employees]
ORDER BY [FirstName] ASC -- can be skipped - it's set to ASC by default

SELECT TOP(4) *
FROM [Employees]
ORDER BY [FirstName] DESC

GO
-- Views - named (saved) queriess
CREATE VIEW [v_FullNameJobAndSalary] AS 
SELECT 
	CONCAT_WS(' ', [FirstName], [LastName]) AS 'Full Name',
	[JobTitle] AS 'Job Title',
	[Salary]
FROM [Employees]

GO

SELECT * FROM [v_FullNameJobAndSalary]

-- Problem: Highest Peak
USE [Geography]
GO

CREATE VIEW [v_HighestPeak] AS
	SELECT TOP(1) *
	FROM [Peaks]
	ORDER BY [Elevation] DESC

GO

SELECT * FROM [v_HighestPeak]
GO

----------------------------
-- Writing Data In Tables --
----------------------------

USE [SoftUni]
GO

INSERT INTO [Towns] 
VALUES ('Paris')

INSERT INTO [Towns] ([Name])
VALUES ('Lisbon')

SELECT *
FROM [Towns]

INSERT INTO [Projects] ([Name], [StartDate]) -- Only sets the name and start date collumns /and any IDENTITY collumn/
VALUES ('Reflecctive Jacket', GETDATE()) -- GETDATE() sets current date

SELECT * FROM [Projects]

INSERT INTO [Projects] ([Name], [StartDate])
SELECT 
		[Name] + ' Restructuring',
		GETDATE()
FROM [Departments]
/* Selects Department names from Departments table
and adds Restructuring to them and sets it as the projet name and the date is set to the current date
*/

SELECT * FROM [Projects]

-- SELECT INTO - creates a new table with the selected data and shows the view
SELECT 
		[FirstName],
		[LastName],
		dep.[Name] AS 'Department Name'
INTO [EmployeesDepartments]
FROM [Employees] AS emp JOIN Departments AS dep ON emp.DepartmentID = dep.[DepartmentID]

SELECT * FROM [EmployeesDepartments]
DROP TABLE [EmployeesDepartments]

-- Sequences
CREATE SEQUENCE [seq_NumberGenerator]
	AS INT
	START WITH 1
	INCREMENT BY 1

SELECT NEXT VALUE FOR [seq_NumberGenerator]

-- There is a way to reset it
ALTER SEQUENCE [seq_NumberGenerator]
	RESTART WITH 1

SELECT NEXT VALUE FOR [seq_NumberGenerator]

--------------------------------
-- Modifying Existing Records --
--------------------------------

-- Deleting Data
DELETE FROM [Towns] WHERE [TownID] = 34
SELECT * FROM [Towns]

-- Deleting EVERYTHING From A Table
CREATE TABLE [DeleteDataSoon] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(10) NOT NULL,
	[LastName]	VARCHAR(10) NOT NULL,
)

INSERT INTO [DeleteDataSoon]
VALUES 
	('James', 'Bond'),
	('Ivan', 'Ivanov'),
	('Mark', 'Zuckerburg'),
	('Jhon', 'Doe')

SELECT * FROM [DeleteDataSoon]

TRUNCATE TABLE [DeleteDataSoon]  -- Used to delete the data from a table

SELECT * FROM [DeleteDataSoon]

DROP TABLE [DeleteDataSoon] -- Used to delete table itself

-- Updating Data --

UPDATE [Employees]
SET [Salary] = [Salary] * 1.10,
	[JobTitle] = 'Senior ' + JobTitle
WHERE [DepartmentID] = 3 AND [AddressID] <= 100

SELECT * 
FROM [Employees]
WHERE [DepartmentID] = 3 AND [AddressID] <= 100

-- Problem: Update Projects
UPDATE [Projects]
SET [EndDate] = GETDATE()
WHERE [EndDate] IS NULL

SELECT * FROM [Projects]

