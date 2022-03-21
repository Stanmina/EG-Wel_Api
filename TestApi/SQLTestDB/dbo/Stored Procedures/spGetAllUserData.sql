CREATE PROCEDURE [dbo].[spGetAllUserData]
	
AS
BEGIN
	SELECT [U].[UserDataId], [U].[Name], [U].[Alias], [G].[GameDataId], [G].[UserDataId], [G].[HighScore], [G].[LevelsCompleted], [G].[TimePlayed]
	FROM UserData U
	JOIN GameData G ON U.UserDataId = G.UserDataId;
END
