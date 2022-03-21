CREATE TABLE [dbo].[GameData]
(
	[GameDataId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserDataId] INT NOT NULL, 
    [HighScore] INT NULL, 
    [LevelsCompleted] INT NULL, 
    [TimePlayed] FLOAT NULL, 
    CONSTRAINT [FK_GameData_UserData] FOREIGN KEY ([UserDataId]) REFERENCES [UserData]([UserDataId])
)