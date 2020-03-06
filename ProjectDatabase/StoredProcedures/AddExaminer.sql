CREATE PROCEDURE [dbo].[AddExaminer]
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Pesel nvarchar(50),
	@BirthDate date,
	@Address_Id int
AS
	INSERT INTO [dbo].[Examiners] (Name, Surname, Pesel, BirthDate, Address_Id)
	VALUES (@Name, @Surname, @Pesel, @BirthDate, @Address_Id)
	SELECT IDENT_CURRENT('Examiners')
