CREATE PROCEDURE [dbo].[spInsertSingleGameDataById]
	@Id int,
	@HighScore int,
	@LevelsCompleted int,
	@TimePlayed float
AS
IF EXISTS ( SELECT UserDataId FROM UserData WHERE UserDataId = @Id )
BEGIN
	UPDATE GameData
	SET UserDataId = @Id, HighScore = @HighScore, LevelsCompleted = @LevelsCompleted, TimePlayed = @TimePlayed
	WHERE UserDataId = @Id;
END