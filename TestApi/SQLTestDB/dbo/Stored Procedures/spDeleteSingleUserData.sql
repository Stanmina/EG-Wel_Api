CREATE PROCEDURE [dbo].[spDeleteSingleUserData]
	@Id int
AS
BEGIN
	-- Delete GameData
	DELETE
	FROM GameData
	WHERE UserDataId = @Id;
	-- Delete UserData
	DELETE
	FROM UserData 
	WHERE UserDataId = @Id;

END
