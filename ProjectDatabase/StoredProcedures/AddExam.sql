CREATE PROCEDURE [dbo].[AddExam]
	@Examinee_Id int,
	@Examiner_Id int,
	@Category varchar(10),
	@Date datetime
AS
	INSERT INTO [dbo].[Exams] (Examinee_Id, Examiner_Id, Category, Date)
	VALUES (@Examinee_Id, @Examiner_Id, @Category, @Date)
	SELECT IDENT_CURRENT('Exams')
