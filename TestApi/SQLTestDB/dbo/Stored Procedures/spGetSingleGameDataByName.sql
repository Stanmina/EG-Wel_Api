CREATE PROCEDURE [dbo].[spGetSingleGameDataByName]
	@Name nvarchar(50)
AS
BEGIN
	SELECT [g].[GameDataId], [G].[UserDataId], [G].[HighScore], [G].[LevelsCompleted], [G].[TimePlayed]
	FROM [dbo].[GameData][G]
	JOIN [dbo].[UserData][U] ON [G].[UserDataId] = [U].[UserDataId]
	WHERE [U].[Name] = @Name;
END