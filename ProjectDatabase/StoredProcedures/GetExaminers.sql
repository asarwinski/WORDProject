CREATE PROCEDURE [dbo].[GetExaminers]
	@Name nvarchar(50) = null,
	@Surname nvarchar(50) = null,
	@Category varchar(10) = null,
	@City nvarchar(50) = null,
	@BirthDate date = null
AS
	SELECT [examiner].[Id], [examiner].[Name], [examiner].[Surname], [examiner].[Pesel], [examiner].[BirthDate], [examiner].[Address_Id],    
		   [address].[Id], [address].[City], [address].[State], [address].[Country], [address].[Zipcode],
		   [permision].[Category]
	FROM [dbo].[Examiners] examiner

	LEFT JOIN [dbo].[Permissions] permision ON permision.Examiner_Id = examiner.Id
	INNER JOIN [dbo].[Addresses] address ON examiner.Address_Id = address.Id

	WHERE (examiner.Name = @Name or @Name is null)
	  AND (examiner.Surname = @Surname or @Surname is null)
	  AND (Month(examiner.BirthDate) = Month(@BirthDate) or @BirthDate is null)
	  AND (address.City = @City or @City is null)
	  AND (permision.Category = @Category or @Category is null)