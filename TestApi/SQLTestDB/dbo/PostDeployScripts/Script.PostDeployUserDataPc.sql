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
IF NOT EXISTS ( SELECT 1 FROM dbo.UserData )
BEGIN
    EXEC spInsertSingleUserData 'Demo', 'User';
    EXEC spInsertSingleUserData 'Stan', 'Stanmina';
    EXEC spInsertSingleUserData 'Boyd', 'IDk';
    EXEC spInsertSingleUserData 'Rens', 'Nijlander';
    EXEC spInsertSingleUserData 'Angela', 'Gans';

    EXEC spInsertSingleGameDataByName 'Demo', 10, 2, 28;
    EXEC spInsertSingleGameDataByName 'Stan', 42069, 4, 60;
    EXEC spInsertSingleGameDataByName 'Boyd', 666, 3, 86;
    EXEC spInsertSingleGameDataByName 'Rens', 420, 3, 74;
    EXEC spInsertSingleGameDataByName 'Angela', 69, 2, 126;
END