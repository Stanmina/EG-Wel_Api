CREATE PROCEDURE [dbo].[spInsertTimePlayedByName]
	@Name varchar(50),
	@TimePlayed float
AS

BEGIN
	UPDATE dbo.GameData
	SET TimePlayed = @TimePlayed
	WHERE ( SELECT dbo.UserData.UserDataId FROM dbo.UserData WHERE dbo.UserData.Name = @Name ) = dbo.GameData.UserDataId;
END