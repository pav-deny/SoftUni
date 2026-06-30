--02.CRUD - Exercise (22-25)
USE [Geography]
GO

--Exercise 22: All Mountain Peaks
SELECT [PeakName]
FROM [Peaks]
ORDER BY [PeakName]

GO
--Exercise 23: Biggest Countries By Population
SELECT TOP(30) [CountryName],
				[Population]
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC

GO
--Exercise 24: Countries And Currency (Euro / Not Euro)
SELECT [CountryName],
		[CountryCode],
		[CurrencyCode],
		CASE 
			WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
		END
		AS [Is Euro]
	FROM [Countries]
	ORDER BY [CountryName]

--Additional stuff
UPDATE [Countries]
	SET [CurrencyCode] = 'EUR'
	WHERE [CountryCode] = 'BG'

UPDATE [Countries]
	SET [CurrencyCode] = 'BGN'
	WHERE [CountryCode] = 'BG'

GO
--Exercise 25: All Diablo Characters
USE [Diablo]
GO

SELECT [Name]
FROM [Characters]
ORDER BY [Name]