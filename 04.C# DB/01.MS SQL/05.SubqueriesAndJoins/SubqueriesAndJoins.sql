--------------------------
-- Subqueries and Joins --
--------------------------
-- Joins
USE [SoftUni]
GO

SELECT * FROM [Employees] AS e INNER JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID -- Inner Join
SELECT * FROM [Employees] AS e JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID -- (Inner) Join

INSERT INTO [Departments]
VALUES 
('Otdel', 283)

SELECT * FROM [Departments] AS d LEFT OUTER JOIN [Employees] AS e ON d.DepartmentID = e.DepartmentID -- Left Outer Join
SELECT * FROM [Departments] AS d LEFT JOIN [Employees] AS e ON d.DepartmentID = e.DepartmentID -- Left (Outer) Join

SELECT * FROM  [Employees] AS e RIGHT OUTER JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID -- Right Outer Join
SELECT * FROM [Employees] AS e RIGHT JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID -- Right (Outer) Join

SELECT * FROM [Employees] AS e FULL OUTER JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID -- Full Outer Join
SELECT * FROM [Employees] AS e FULL JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID -- Full (Outer) Join

DELETE FROM [Departments]
WHERE [Name] = 'Otdel'

SELECT [FirstName], [Name] FROM [Employees], [Departments] -- Cartesian Product

SELECT [FirstName], [Name] FROM [Employees] CROSS JOIN [Departments] -- Cross Join

-- Problem: Adresses with towns
SELECT TOP (50)
		e.[FirstName], 
		e.[LastName],
		t.[Name] as [Town],
		a.[AddressText]
FROM [Employees] as e
LEFT JOIN [Addresses] as a ON e.AddressID = a.AddressID
LEFT JOIN [Towns] as t ON a.TownID = t.TownID
ORDER BY e.[FirstName], e.[LastName]

-- Problem: Sales Employees
SELECT
		e.[EmployeeID],
		e.[FirstName],
		e.[LastName],
		d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]

-- Second way
SELECT
		e.[EmployeeID],
		e.[FirstName],
		e.[LastName],
		d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID] AND d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]

-- Problem: Employees Hired After
SELECT
		e.[FirstName],
		e.[LastName],
		e.[HireDate],
		d.[Name] AS [DeptName]
FROM [Employees] AS e
	JOIN [Departments] AS d
	ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[HireDate] > '1999-01-01' 
	AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.[HireDate]

-- Problem: Employee Summary
SELECT TOP (50)
		e.[EmployeeID],
		CONCAT_WS(' ', e.[FirstName], e.[LastName]) AS [EmployeeName],
		CONCAT_WS(' ', m.[FirstName], m.[LastName]) AS [ManagerName],
		d.[Name] AS [DepartmentName]
FROM [Employees] AS e
	LEFT JOIN [Employees] AS m
		ON e.[ManagerID] = m.[EmployeeID]
	JOIN [Departments] AS d
		ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]

----------------
-- Subqueries --
----------------

-- Problem: Min Average Salary
SELECT
		MIN(dt.SalaryAvg) AS [MinAverageSalary]
	FROM 
	(SELECT 
		AVG(Salary) AS [SalaryAvg]
			FROM [Employees]
			GROUP BY [DepartmentID]
	) AS dt

-- Second Way
SELECT TOP(1)
		AVG(Salary) AS [MinAverageSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
	ORDER BY [MinAverageSalary]

---------------------------------------------------------
-- Common Table Expressions (CTE) and Temporary Tables --
---------------------------------------------------------
-- CTE
WITH [AvgSalaryCTE] ([AverageSalary])
AS
(SELECT 
	AVG(Salary)
	FROM [Employees]
	GROUP BY [DepartmentID])

SELECT
		MIN([AverageSalary]) AS [MinAverageSalary]
	FROM [AvgSalaryCTE]

-- Temporary Tables
-- Local Temporary Table
CREATE TABLE #Employees
(
	[Id] INT PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Adress] VARCHAR(200)
)

INSERT INTO #Employees 
SELECT 
		e.[EmployeeId], 
		e.[FirstName], 
		e.[LastName],
		a.[AddressText]
FROM [Employees] AS e
JOIN [Addresses] AS a ON e.AddressID = a.AddressID 

SELECT * FROM #Employees

-- Global Temporary Tables
CREATE TABLE ##Employees
(
	[Id] INT PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Adress] VARCHAR(200)
)

INSERT INTO ##Employees 
SELECT 
		e.[EmployeeId], 
		e.[FirstName], 
		e.[LastName],
		a.[AddressText]
FROM [Employees] AS e
JOIN [Addresses] AS a ON e.AddressID = a.AddressID 

SELECT * FROM ##Employees