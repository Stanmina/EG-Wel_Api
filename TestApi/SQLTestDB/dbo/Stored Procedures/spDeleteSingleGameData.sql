CREATE PROCEDURE [dbo].[spDeleteSingleGameData]
	@Id int
AS
BEGIN
	UPDATE GameData
	SET HighScore = NULL, LevelsCompleted = NULL, TimePlayed = NULL
	WHERE UserDataId = @Id;
END
