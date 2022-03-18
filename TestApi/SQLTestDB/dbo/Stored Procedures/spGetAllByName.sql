CREATE PROCEDURE [dbo].[GetAllByName]
	@Name VARCHAR(50)
AS
BEGIN
	SELECT [U].[UserDataId], [U].[Name], [U].[Alias], [G].[HighScore], [G].[LevelsCompleted], [G].[TimePlayed]
	FROM UserData [U]
	JOIN GameData [G] ON U.UserDataId = G.UserDataId
	WHERE Name = @Name;
END
