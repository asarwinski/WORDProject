CREATE TABLE [dbo].[Exams]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Examinee_Id] INT NOT NULL, 
    [Examiner_Id] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Result] BIT NULL, 
    [Duration] TIME NULL, 
    CONSTRAINT [FK_Exams_ToExaminees] FOREIGN KEY ([Examinee_Id]) REFERENCES [Examinees]([Id]), 
    CONSTRAINT [FK_Exams_ToExaminers] FOREIGN KEY ([Examiner_Id]) REFERENCES [Examiners]([Id])
)
