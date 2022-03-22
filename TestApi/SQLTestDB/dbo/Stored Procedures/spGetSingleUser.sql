CREATE PROCEDURE [dbo].[spGetSingleUser]
	@Name varchar(50)
AS
BEGIN
	select [U].[UserDataId], [U].[Name], [U].[Alias], [G].[GameDataId], [G].[UserDataId], [G].[HighScore], [G].[LevelsCompleted], [G].[TimePlayed]
	FROM UserData U 
	JOIN GameData G ON U.UserDataId = G.UserDataId
	WHERE U.Name = @Name;
END
