/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS ( SELECT * FROM dbo.UserData WHERE Name = 'Demo' AND Alias = 'User' )
BEGIN
    INSERT INTO dbo.UserData ( Name, Alias )
    VALUES ( 'Demo', 'User' );
    INSERT INTO dbo.GameData ( UserDataId, HighScore, LevelsCompleted, TimePlayed )
    VALUES ( (SELECT UserDataId FROM UserData WHERE Name = 'Demo' AND Alias = 'User') , 420, 2, 69 );
END