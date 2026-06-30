----------------------------
-- User Defined Functions --
----------------------------
-- Scalar function
CREATE FUNCTION udf_ProjectDurationWeeks (@StartDate DATETIME, @ENDDATE DATETIME)
RETURNS INT
AS 
BEGIN
		DECLARE @projectWeeks INT;
		IF (@EndDate IS NULL)
		BEGIN 
				SET @EndDate = GETDATE();
		END
		SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
		RETURN @projectWeeks;
END;

SELECT	
		[ProjectId],
		[Name],
		[StartDate],
		[EndDate],
		dbo.udf_ProjectDurationWeeks([StartDate], [EndDate]) AS [WeeksDiff]
FROM [Projects]

-- Table-Valued Function (TVF)
GO
CREATE FUNCTION udf_AverageSalaryByDepartment(@DepartmentName VARCHAR(50))
RETURNS TABLE AS
RETURN
(
	SELECT d.[Name] AS DepartmentName, AVG(e.Salary) AS [AverageSalary]
	FROM [Departments] AS d 
	JOIN [Employees] as e ON d.[DepartmentID] = e.[DepartmentID]
	WHERE d.[Name] = @DepartmentName
	GROUP BY d.[Name]
)

SELECT * FROM udf_AverageSalaryByDepartment('Sales')
SELECT [AverageSalary] FROM udf_AverageSalaryByDepartment('Sales')

-- Multi-statement Table-Valued Function (MTVF)
GO
CREATE FUNCTION udf_EmployeeListByDepartment (@DepName NVARCHAR(20))
RETURNS @result TABLE (
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[DepartmentName] NVARCHAR(20) NOT NULL) AS
BEGIN
	WITH Employees_CTE ([FirstName], [LastName], [DepartmentName])
	AS (
			SELECT e.[FirstName], e.[LastName], d.[Name]
			FROM [Employees] AS e
			LEFT JOIN [Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
		)

	INSERT INTO @result SELECT [FirstName], [LastName], [DepartmentName]
		FROM [Employees_CTE] WHERE [DepartmentName] = @DepName
	RETURN
END

SELECT * FROM udf_EmployeeListByDepartment('Sales')

GO
-- Problem: Salary Level Function
CREATE FUNCTION udf_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(20)
BEGIN
	DECLARE @level VARCHAR(20)
	IF (@Salary < 30000)
	BEGIN
		SET @level = 'Low';
	END;
	ELSE IF (@Salary <= 50000)
	BEGIN
		SET @level = 'Average';
	END;
	ELSE 
	BEGIN
		SET @level = 'High';
	END;
	RETURN @level
END;

SELECT 
		[FirstName],
		[LastName],
		[Salary],
		dbo.udf_GetSalaryLevel([Salary]) AS [Salary]
FROM [Employees]

GO
-----------------------
-- Stored Procedures --
-----------------------

CREATE OR ALTER PROCEDURE usp_SelectEmployeesBySeniority -- you can use PROC instead of Procedure
AS 
	SELECT 
			FirstName,
			LastName,
			HireDate,
			DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsOnDuty
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 20
	ORDER BY HireDate
GO

EXEC usp_SelectEmployeesBySeniority

EXEC sp_depends usp_SelectEmployeesBySeniority
DROP PROC usp_SelectEmployeesBySeniority


-- Stored Procedures with parameters
GO
CREATE OR ALTER PROCEDURE usp_SelectEmployeesBySeniorityCustom(@MINYears INT = 5)
AS 
	SELECT 
			FirstName,
			LastName,
			HireDate,
			DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsOnDuty
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @MINYears
	ORDER BY HireDate
GO

EXEC usp_SelectEmployeesBySeniorityCustom
EXEC usp_SelectEmployeesBySeniorityCustom 23
EXEC usp_SelectEmployeesBySeniorityCustom 25
EXEC usp_SelectEmployeesBySeniorityCustom @MINYears = 25

GO
-- Output Parameter
CREATE PROCEDURE usp_AddNumbers
	@firstNum INT,
	@secondNum INT,
	@result INT OUTPUT
AS 
	SET @result = @firstNum + @secondNum
GO

DECLARE @answer INT
EXECUTE usp_AddNumbers 5, 6, @answer OUTPUT
SELECT @answer AS Result

GO
-- Returning Multiple Results
CREATE OR ALTER PROC usp_MultipleResults
AS
	SELECT FirstName, LastName 
		FROM Employees
	SELECT FirstName, LastName, d.[Name] AS Department 
		FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID;
GO

EXEC usp_MultipleResults

--------------------
-- Error Handling --
--------------------
GO
CREATE PROC usp_FailProc
AS
BEGIN TRY
	SELECT 1/0
END TRY 
BEGIN CATCH
	SELECT
		ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO

EXEC usp_FailProc

-- @@ERROR
SELECT 1/0
SELECT @@ERROR

-- @@ERROR Stored
DECLARE @test INT
SELECT 1/0
SET @test = @@ERROR
SELECT @test