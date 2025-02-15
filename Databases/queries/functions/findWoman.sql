CREATE OR ALTER FUNCTION ufnFindWoman ()
RETURNS @retFindWoman TABLE
(
	WomanName varchar(50) NOT NULL,
	WomanSurname varchar(50) NOT NULL
)
AS
BEGIN 
	WITH Womans AS 
	(
		SELECT a.Name, a.Surname FROM Authors a
		WHERE a.Name LIKE '%A'
		UNION
		SELECT w.Name, w.Surname FROM Workers w
		WHERE w.Name LIKE '%A'
	)
	INSERT @retFindWoman
	SELECT * FROM Womans
	RETURN
END;
GO