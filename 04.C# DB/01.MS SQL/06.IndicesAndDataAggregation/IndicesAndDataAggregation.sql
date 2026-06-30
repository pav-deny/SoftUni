-------------
-- Indices --
-------------

--------------
-- Grouping --
--------------

USE [SoftUni]
GO

SELECT DISTINCT [DepartmentId]
FROM [Employees]

SELECT [DepartmentId]
FROM [Employees]
GROUP BY [DepartmentID]

-- error
--SELECT [DepartmentId], [Salary] 
--FROM [Employees]
--GROUP BY [DepartmentID]

SELECT [DepartmentId], [Salary]
FROM [Employees]
GROUP BY [DepartmentID], [Salary]

SELECT [DepartmentId], [Salary], COUNT(*)
FROM [Employees]
GROUP BY [DepartmentID], [Salary]

SELECT [DepartmentId], [Salary], COUNT(*)
FROM [Employees]
GROUP BY [DepartmentID], [Salary]
ORDER BY [DepartmentID], [Salary]

SELECT [DepartmentId], [Salary], COUNT(*)
FROM [Employees]
GROUP BY [DepartmentID], [Salary]
ORDER BY 1, 3 -- DepId and COUNT(*)

-- Problem: Departments Total Salaries
SELECT 
		[DepartmentId],
		SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

-------------------------
-- Aggregate functions --
-------------------------
-- String_AGG

SELECT 
		[DepartmentId],
		COUNT([Salary]) AS [Employees],
		MIN([Salary]) AS [MinSalary],
		MAX([Salary]) AS [MaxSalary],
		AVG([Salary]) AS [AverageSalary],
		SUM([Salary]) AS [TotalSalary],
		STRING_AGG(CONCAT_WS(' ', [FirstName], [LastName]), ', ') WITHIN GROUP (ORDER BY [FirstName], [LastName]) AS [Name]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

------------
-- Having --
------------
SELECT 
		[DepartmentId],
		SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING SUM([Salary]) <= 100000
