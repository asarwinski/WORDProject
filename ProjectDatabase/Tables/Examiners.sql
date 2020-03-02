CREATE TABLE [dbo].[Examiners]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Pesel] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [Address_Id] INT NOT NULL, 

    CONSTRAINT [FK_Examiners_ToAddresses] FOREIGN KEY ([Address_Id]) REFERENCES [Addresses]([Id])
)
