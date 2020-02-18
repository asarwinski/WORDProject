CREATE TABLE [dbo].[Permissions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Examiner_Id] INT NOT NULL, 
    [Category] VARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Permissions_ToExaminers] FOREIGN KEY ([Examiner_Id]) REFERENCES [Examiners]([Id])
)
