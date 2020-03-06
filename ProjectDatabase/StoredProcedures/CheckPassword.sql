CREATE PROCEDURE [dbo].[CheckPassword]
	@Login nvarchar(50),
	@Password nvarchar(50)
AS
	SELECT COUNT(*)
	FROM [dbo].[Passwords] p
	WHERE p.Login = @Login AND p.Password = @Password
