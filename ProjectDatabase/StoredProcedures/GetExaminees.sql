CREATE PROCEDURE [dbo].[GetExaminees]
	@Name nvarchar(50) = null,
	@Surname nvarchar(50) = null,
	@Category varchar(10) = null,
	@City nvarchar(50) = null,
	@BirthDate date = null
AS
	SELECT [examinee].[Id], [examinee].[Name], [examinee].[Surname], [examinee].[Pesel], [examinee].[BirthDate], [examinee].[Address_Id], 
		   [address].[Id], [address].[City], [address].[State], [address].[Country], [address].[Zipcode],
		   [exam].Category
	FROM [dbo].[Examinees] examinee

	LEFT JOIN [dbo].[Exams] exam ON (examinee.Id = exam.Examinee_Id AND exam.Result='True')
	INNER JOIN [dbo].[Addresses] address ON examinee.Address_Id = address.Id

	WHERE (examinee.Name = @Name or @Name is null)
	  AND (examinee.Surname = @Surname or @Surname is null)
	  AND (Month(examinee.BirthDate) = Month(@BirthDate) or @BirthDate is null)
	  AND (address.City = @City or @City is null)
	  AND (exam.Category = @Category or @Category is null)
