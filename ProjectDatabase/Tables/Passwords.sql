CREATE TABLE [dbo].[Passwords]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Login] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL
)
