CREATE PROCEDURE [dbo].[spGetSingleUserDataByName]
	@Name nvarchar(50)
AS
BEGIN
	SELECT [U].[UserDataId], [U].[Name], [U].[Alias]
	FROM [dbo].[GameData][G]
	JOIN [dbo].[UserData][U] ON [G].[UserDataId] = [U].[UserDataId]
	WHERE [U].[Name] = @Name;
END