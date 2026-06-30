----------------------
-- String Functions --
----------------------

-- Concatination
SELECT '1' + 1
SELECT CONCAT('1', 1)
SELECT CONCAT_WS('', '1', 1)

SELECT 'Deni' + ' | ' + NULL + ' | ' + 'Pavlov'
SELECT CONCAT('Deni', ' | ', NULL, ' | ', 'Pavlov')
SELECT CONCAT_WS(' | ', 'Deni', NULL, 'Pavlov')

-- Substring
SELECT SUBSTRING('SoftUni', 5, 3)

SELECT SUBSTRING('SoftUni', 5, 7) -- Works /even though SoftUni has 7 letters 7 - 4 -> 3 letters we can pick

SELECT SUBSTRING('SoftUni', 10, 3) -- Returns empty string since SoftUni has only 7 letters

SELECT SUBSTRING('Once upon a time there was a young boy named MICHEAL who decided to', 1, 45) + '...' AS [Summary]

-- Replace
SELECT REPLACE('Microsoft', 'soft', 'slop')
SELECT REPLACE('SoftUniSoft', 'Soft', 'Hard')

-- LTRIM & RTRIM
SELECT LTRIM('  Deni  ') -- Deni__
SELECT RTRIM('  Deni  ') -- __Deni
SELECT TRIM('  Deni  ') -- Deni  

-- LEN
SELECT  CONCAT(SUBSTRING('1003086704', 1, LEN('1003086704') - 4), '****')

-- DATALENGHT
SELECT DATALENGTH('Pesho') -- ASCII
SELECT DATALENGTH('Пешо') -- UTF-8
SELECT DATALENGTH('αβγΔ') -- UTF-8
SELECT DATALENGTH('ᯃ') -- (U+1C87) UTF-16

-- LEFT & RIGHT
SELECT LEFT('1003086704', 6) + '****'
SELECT '****' + RIGHT('1003086704', 6)

-- LOWER & UPPER
SELECT 
		'Pesho' AS [Name],
		UPPER('Peshev') AS [LastName],
		LOWER('SoFtWaRe EnGiNeEr') AS [JobTitle]

SELECT UPPER('Pesho') AS [NormalizedName]

-- REVERSE
SELECT REVERSE('?YAS XOF EHT SEOD TAHW')

-- REPLICATE
SELECT  CONCAT(SUBSTRING('1003086704', 1, LEN('1003086704') - 4), REPLICATE('*', 4))

-- FORMAT 
SELECT FORMAT(8.675, 'C2', 'bg-BG') -- 8,68 лв.
SELECT FORMAT(8.675, 'C2', 'fr-FR') -- 8.68 €
SELECT FORMAT(8.675, 'F2', 'bg-BG') -- 8,68
SELECT FORMAT(8.675, 'F2', 'fr-FR') -- 8.68

SELECT FORMAT(StartDate, 'dd/MM/yyy') FROM [Projects]

-- Problem: Obfuscate CC Numbers
USE [Demo]
GO

SELECT 
		[CustomerId],
		[FirstName],
		[LastName],
		LEFT([PaymentNumber], 6) + '**********'
FROM [Customers]

-- CHARINDEX
USE [SoftUni]
GO

SELECT CHARINDEX('Uni', 'SoftUni')

-- STUUF

SELECT STUFF('SoftUni', 5, 4, 'ware university')

--------------------
-- Math Functions --
--------------------

USE [Demo]
GO

SELECT *,
	([A] * [H]) / 2 AS [Area]
FROM [Triangles2]

-- PI
SELECT PI()

-- ABS
SELECT ABS(-8)

-- SQRT
SELECT SQRT(9)

-- SQUARE
SELECT SQUARE(6)

-- Problem: Line Length
USE [Demo]
GO

Select [Id],
		SQRT(SQUARE(X1 - X2) + SQUARE(Y1 - Y2))
FROM [Lines]

-- Power
USE [SoftUni]
GO

SELECT POWER(6, 3)

-- Round
SELECT ROUND(3.14159254358979323, 4)
SELECT ROUND(214.345, -2)

-- Ceiling & Floor
SELECT CEILING(3.658),
		FLOOR(3.658),
		ROUND(3.658, 0)

-- Problem: Pallets
SELECT 
		[Id],
		CEILING(CAST(CEILING(CAST([Quantity] AS FLOAT) / [BoxCapacity]) AS FLOAT)/ [PalletCapacity])
FROM [Demo].[dbo].[Products]

-- Sign
SELECT	SIGN(0),
		SIGN(4),
		SIGN(+4),
		SIGN(-4)

-- RAND
SELECT RAND(), RAND() * 10, RAND() * 100

--------------------
-- DATE FUNCTIONS --
--------------------

-- DatePart
DECLARE @DATE DATE = '2026-05-12'
SELECT 
		DATEPART(day, @DATE) AS [Day],
		DATEPART(mm, @DATE) AS [Month],
		YEAR(@DATE) AS [Year],
		DATEPART(WEEKDAY, @DATE) AS [Weekday],
		DATEPART(WEEK, @DATE) AS [Week]

SELECT DATEPART(y, '2026-05-12')
SELECT DATEPART(y, '2026-09-13')

--  Problem: Quarterly Report
SELECT 
		[InvoiceId],
		[Total],
		DATEPART(q, [InvoiceDate]) AS [Quarter],
		DATEPART(m, [InvoiceDate]) AS [Month],
		YEAR([InvoiceDate]) AS [Year],
		DAY([InvoiceDate]) AS [Day]
FROM [Demo].[dbo].[Invoices]

-- DATEDIFF
SELECT 
		[EmployeeID],
		[FirstName],
		DATEDIFF(yy, [HireDate], GETDATE()) AS [Years In Service]
FROM [Employees]
ORDER BY [Years In Service] DESC

-- DATENAME
SELECT DATENAME(WEEKDAY, '2010-03-08')
SELECT DATENAME(MONTH, '2010-03-08')

-- DATEADD
SELECT DATEADD(YEAR, 16, '2010-03-08')

-- GETDATE 
SELECT GETDATE()

-- EOMONTH
SELECT EOMONTH('2026-03-12')
SELECT EOMONTH('2024-02-12')
SELECT EOMONTH('2026-02-12')

---------------------
-- Other functions --
---------------------

-- Cast & Convert
SELECT CAST('0' AS INT) + 3 + '1',
		CONVERT(INT, '56') + 3 + '1'

-- ISNULL
SELECT ISNULL([MiddleName], 'N/A')
FROM [Employees]

SELECT COALESCE('a', 'b', 'N/A', 'bsd')

-- OFFSET & FETCH
SELECT * FROM [Employees]
ORDER BY [FirstName]
OFFSET 4 * 10 - 10 ROWS
FETCH NEXT 10 ROWS ONLY

-- ROW_NUMBER, RANK, DENSE_RANK
SELECT 
		ROW_NUMBER() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary]) AS [Row Number],
		RANK() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary]) AS [Rank],
		DENSE_RANK() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary]) AS [Dense Rank],
		NTILE(2) OVER (PARTITION BY [DepartmentId] ORDER BY [Salary]) AS [NTILE],
		[FirstName],
		[LastName],
		[DepartmentID],
		[Salary]
FROM [Employees]

---------------
-- WILDCARDS --
---------------
SELECT *
FROM [Employees]
WHERE [FirstName] LIKE 'Ro%'