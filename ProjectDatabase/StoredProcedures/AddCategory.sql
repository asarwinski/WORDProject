CREATE PROCEDURE [dbo].[AddCategory]
	@Examiner_Id int,
	@Category varchar(10)
AS
	INSERT INTO [dbo].[Permissions] (Examiner_Id, Category)
	VALUES (@Examiner_Id, @Category)
	SELECT IDENT_CURRENT('Permissions')
