CREATE PROCEDURE [dbo].[GetExaminerById]
	@Id int
AS
	SELECT [examiner].[Id], [examiner].[Name], [examiner].[Surname], [examiner].[Pesel], [examiner].[BirthDate], [examiner].[Address_Id],
		   [address].[Id], [address].[City], [address].[State], [address].[Country], [address].[Zipcode],
		   [permision].[Category]
	FROM [dbo].[Examiners] examiner
	LEFT JOIN [dbo].[Permissions] permision ON permision.Examiner_Id = examiner.Id
	LEFT JOIN [dbo].[Addresses] address ON examiner.Address_Id = address.Id
	WHERE examiner.Id = @Id
