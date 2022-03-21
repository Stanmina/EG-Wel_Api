CREATE VIEW [dbo].[FullUserData]
	AS SELECT [U].[UserDataId], [U].[Name], [U].[Alias], [G].[GameDataId], [G].[HighScore], [G].[LevelsCompleted], [G].[TimePlayed]
	FROM [dbo].[UserData] [U]
	JOIN [dbo].[GameData] [G] ON [U].[UserDataId] = [G].[UserDataId];
