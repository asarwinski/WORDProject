CREATE PROCEDURE [dbo].[DoesExamineeExist]
	@Pesel varchar(50)
AS
	SELECT e.Id
	FROM [dbo].[Examinees] e
	WHERE e.Pesel = @Pesel
RETURN 0
