CREATE PROCEDURE [dbo].[AddExaminee]
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Pesel nvarchar(50),
	@BirthDate date,
	@Address_Id int
AS
	INSERT INTO [dbo].[Examinees] (Name, Surname, Pesel, BirthDate, Address_Id)
	VALUES (@Name, @Surname, @Pesel, @BirthDate, @Address_Id)
	SELECT IDENT_CURRENT('Examinees')
