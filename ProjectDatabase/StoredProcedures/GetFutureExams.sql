CREATE PROCEDURE [dbo].[GetFutureExams]
	@Examiner_Id int = null,
	@Examinee_Id int = null,
	@Category varchar(10) = null,
	@Date datetime = null
AS
	SELECT [exam].[Id], [exam].[Category], [exam].[Date], [exam].[Examinee_Id], [exam].[Examiner_Id]

	FROM [dbo].[Exams] exam

	WHERE (exam.Examiner_Id = @Examiner_Id or @Examiner_Id is null)
	  AND (exam.Examinee_Id = @Examinee_Id or @Examinee_Id is null)
	  AND (exam.Category = @Category or @Category is null)
	  AND ((exam.Date = @Date and @Date is not null)  or @Date is null)
	  AND (exam.Result is null)