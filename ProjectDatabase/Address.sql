CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Address_ToTable] FOREIGN KEY (PersonId) REFERENCES [Person]([Id])

)
