CREATE TABLE [dbo].[GameData]
(
	[Id] INT NOT NULL PRIMARY KEY , 
    [UserDataId] INT NOT NULL, 
    [HighScore] INT NULL, 
    [LevelsCompleted] INT NULL, 
    [TimePlayedInSeconds] INT NULL, 
    CONSTRAINT [FK_GameData_UserData] FOREIGN KEY ([UserDataId]) REFERENCES [UserData]([Id])
)
