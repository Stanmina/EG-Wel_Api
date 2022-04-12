CREATE PROCEDURE [dbo].[spInsertSingleUserData]
	@Name VARCHAR(50),
	@Alias VARCHAR(50)
AS
IF NOT EXISTS ( SELECT * FROM UserData WHERE Name = @Name AND Alias = @Alias )
BEGIN
	INSERT INTO dbo.UserData ( Name, Alias)
	VALUES ( @Name, @Alias );

	INSERT INTO dbo.GameData ( UserDataId, HighScore, LevelsCompleted, TimePlayed )
	VALUES ( (SELECT UserDataId FROM UserData WHERE Name = @Name AND Alias = @Alias ), 0, 0, 60 );
END
