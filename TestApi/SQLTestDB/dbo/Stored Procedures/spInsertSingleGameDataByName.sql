CREATE PROCEDURE [dbo].[spInsertSingleGameDataByName]
	@Name varchar(50),
	@HighScore int,
	@LevelsCompleted int,
	@TimePlayed float
AS

BEGIN
	UPDATE dbo.GameData
	SET HighScore = @HighScore, LevelsCompleted = @LevelsCompleted, TimePlayed = @TimePlayed
	WHERE ( SELECT dbo.UserData.UserDataId FROM dbo.UserData WHERE dbo.UserData.Name = @Name ) = dbo.GameData.UserDataId;
END