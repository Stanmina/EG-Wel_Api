CREATE PROCEDURE [dbo].[spGetSingleUserDataByName]
	@name nvarchar(50)
AS
BEGIN
	SELECT [UserDataId], [Name], [Alias]
	FROM [dbo].[UserData]
	WHERE [Name] = @name;
END