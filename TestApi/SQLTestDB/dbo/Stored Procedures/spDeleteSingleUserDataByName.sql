CREATE PROCEDURE [dbo].[spDeleteSingleUserDataByName]
	@Name varchar(50)
AS
BEGIN
	-- Delete GameData
	DELETE
	FROM GameData
	WHERE ( SELECT dbo.UserData.UserDataId FROM dbo.UserData WHERE dbo.UserData.Name = @Name ) = dbo.GameData.UserDataId;
	-- Delete UserData
	DELETE
	FROM UserData 
	WHERE Name = @Name;
END