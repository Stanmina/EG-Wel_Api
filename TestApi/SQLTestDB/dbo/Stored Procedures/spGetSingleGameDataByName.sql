CREATE PROCEDURE [dbo].[spGetSingleGameDataByName]
	@Name nvarchar(50)
AS
BEGIN
	SELECT [GameDataId], [HighScore], [LevelsCompleted], [TimePlayed] 
	FROM [dbo].[GameData][G]
	JOIN [dbo].[UserData][U] ON [G].[UserDataId] = [U].[UserDataId]
	WHERE [U].[Name] = @Name;
END