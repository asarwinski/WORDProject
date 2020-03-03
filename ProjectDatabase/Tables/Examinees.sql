CREATE TABLE [dbo].[Examinees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Pesel] VARCHAR(50) NOT NULL, 
    [BirthDate] Date NULL,
    [Address_Id] INT NOT NULL, 
    CONSTRAINT [FK_Examinees_ToAddresses] FOREIGN KEY (Address_Id) REFERENCES [Addresses]([Id])
)
