USE EuroLeagues
GO
----------------

-- Problem 05: Matches by Goals and Date
SELECT	
		FORMAT(MatchDate, 'yyyy-MM-dd', 'bg-BG'),
		HomeTeamGoals,
		AwayTeamGoals,
		(HomeTeamGoals + AwayTeamGoals) AS TotalGoals
	FROM Matches
	WHERE (HomeTeamGoals + AwayTeamGoals) >= 5
	ORDER BY TotalGoals DESC, MatchDate ASC

-- Problem 06: Players with Common Part in Their Names
SELECT 
		p.[Name],
		t.City
	FROM Players AS p 
	JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	JOIN Teams AS t ON pt.TeamId = t.Id
	WHERE p.[Name] LIKE '%Aaron%'
	ORDER BY p.[Name] ASC

-- Problem 07: Players in Teams Situated in London
SELECT 
		p.Id,
		p.[Name],
		p.Position
	FROM Players AS p
	JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	JOIN Teams AS t ON pt.TeamId = t.Id
	WHERE t.City = 'London'
	ORDER BY [Name] ASC

-- Problem 08: First 10 Matches in Early September
SELECT TOP 10
		th.[Name] AS HomeTeamName,
		ta.[Name] AS AwayTeamName,
		l.[Name] AS LeagueName,
		FORMAT(m.MatchDate, 'yyyy-MM-dd', 'bg-BG')
	FROM Matches AS m
	JOIN Teams AS th ON m.HomeTeamId = th.Id
	JOIN Teams AS ta ON m.AwayTeamId = ta.Id
	JOIN Leagues AS l ON m.LeagueId = l.Id
	WHERE (MatchDate BETWEEN '2024-09-01' AND '2024-09-15') AND l.Id % 2 = 0
	ORDER BY MatchDate ASC, HomeTeamName ASC

-- Problem 09: Best Guest Teams
SELECT 
		t.Id,
		t.[Name],
		SUM(m.AwayTeamGoals) AS TotalAwayGoals
	FROM Teams AS t
	JOIN Matches AS m ON t.Id = m.AwayTeamId
	GROUP BY t.Id, t.[Name]
	HAVING SUM(m.AwayTeamGoals) >= 6
	ORDER BY TotalAwayGoals DESC, t.[Name] ASC

-- Problem 10: Average Scoring Rate
SELECT 
		l.[Name] AS LeagueName,
		ROUND(AVG(CAST(m.AwayTeamGoals AS FLOAT) + m.HomeTeamGoals), 2) AS AvgScoringRate
	FROM Leagues AS l
	JOIN Matches as m ON l.Id = m.LeagueId
	GROUP BY l.Id, l.[Name]
	ORDER BY AvgScoringRate DESC
