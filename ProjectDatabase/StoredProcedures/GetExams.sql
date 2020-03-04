CREATE PROCEDURE [dbo].[GetExams]
	@Examiner_Id int = null,
	@Examinee_Id int = null,
	@Category varchar(10) = null,
	@Date datetime = null,
	@Result bit = null
AS
	SELECT [exam].[Id], [exam].[Category], [exam].[Date], [exam].[Result], [exam].[Duration], [exam].[Examinee_Id], [exam].[Examiner_Id]

	FROM [dbo].[Exams] exam

	WHERE (exam.Examiner_Id = @Examiner_Id or @Examiner_Id is null)
	  AND (exam.Examinee_Id = @Examinee_Id or @Examinee_Id is null)
	  AND (exam.Category = @Category or @Category is null)
	  AND (exam.Date = @Date or @Date is null)
	  AND (exam.Result = @Result or @Result is null)
