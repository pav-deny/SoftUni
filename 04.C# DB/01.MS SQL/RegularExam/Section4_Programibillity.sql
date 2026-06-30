-- Problem 11: League Top Scorer

CREATE FUNCTION udf_LeagueTopScorer (@LeagueName NVARCHAR(50))
RETURNS TABLE AS
RETURN
(
	SELECT
			p.[Name],
			ps.[Goals] AS TotalGoals
	FROM Players AS p
	JOIN PlayerStats AS ps ON p.Id = ps.PlayerId
	JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	JOIN Teams AS t ON pt.TeamId = t.Id
	JOIN Leagues AS l ON t.LeagueId = l.Id
	WHERE l.[Name] = @LeagueName AND ps.Goals = 
	(
		SELECT MAX(ps2.Goals)
		FROM Players AS p2
		JOIN PlayerStats AS ps2 ON p2.Id = ps2.PlayerId
		JOIN PlayersTeams AS pt2 ON p2.Id = pt2.PlayerId
		JOIN Teams AS t2 ON pt2.TeamId = t2.Id
		JOIN Leagues AS l2 ON t2.LeagueId = l2.Id
		WHERE l2.Name = @LeagueName
	)
)

SELECT * FROM udf_LeagueTopScorer ('Serie A')

UPDATE PlayerStats
SET Goals = 18
WHERE PlayerId = (SELECT p.Id FROM Players p WHERE p.Name = 'Erling Haaland');

UPDATE PlayerStats
SET Goals = 18
WHERE PlayerId = (SELECT p.Id FROM Players p WHERE p.Name = 'Alexander Isak');

SELECT * FROM udf_LeagueTopScorer ('Premier League')

-- Problem 12: Update Player Stats
CREATE PROCEDURE usp_UpdatePLayerStats 
@PlayerId INT,
@GoalsDelta INT = NULL,
@AssistsDelta INT = NULL
AS
	IF (SELECT COUNT(*) FROM PlayerStats WHERE PlayerId = @PlayerId) = 0
	BEGIN
		INSERT INTO PlayerStats (PlayerId, Goals, Assists)
		VALUES (@PlayerId, 0, 0)
	END
	IF (@GoalsDelta IS NOT NULL)
	BEGIN
		UPDATE PlayerStats 
		SET Goals += @GoalsDelta
		WHERE PlayerId = @PlayerId
	END
	IF (@AssistsDelta IS NOT NULL)
	BEGIN
		UPDATE PlayerStats 
		SET Assists += @AssistsDelta
		WHERE PlayerId = @PlayerId
	END
GO

EXEC usp_UpdatePlayerStats 51, 2;
EXEC usp_UpdatePLayerStats 51, NULL, 2

SELECT 
		p.Id,
		p.[Name],
		ps.Goals,
		ps.Assists
FROM Players AS p
JOIN PlayerStats AS ps ON p.Id = ps.PlayerId
WHERE p.Id = 51