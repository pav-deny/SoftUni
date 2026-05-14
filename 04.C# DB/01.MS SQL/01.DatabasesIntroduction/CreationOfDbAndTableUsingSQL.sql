USE [master]

CREATE DATABASE [DbIntroSQL]

GO

USE [DbIntroSQL]

GO

CREATE TABLE [People]
(
Id INT NOT NULL,
Email VARCHAR(50) NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50)
)

GO

USE [01.DatabasesIntroduction]

SELECT TOP(2) [FirstName], [LastName] FROM [Employees]
ORDER BY [EmployeeId]