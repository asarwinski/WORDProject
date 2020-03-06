CREATE PROCEDURE [dbo].[GetExamineeById]
	@Id int
AS
	SELECT [examinee].[Id], [examinee].[Name], [examinee].[Surname], [examinee].[Pesel], [examinee].[BirthDate], [examinee].[Address_Id],
		   [address].[Id], [address].[City], [address].[State], [address].[Country], [address].[Zipcode],
		   [exam].[Category]
	FROM [dbo].[Examinees] examinee
	LEFT JOIN [dbo].[Exams] exam ON (examinee.Id = exam.Examinee_Id AND exam.Result='True')
	LEFT JOIN [dbo].[Addresses] address ON examinee.Address_Id = address.Id
	WHERE examinee.Id = @Id