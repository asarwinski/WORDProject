CREATE PROCEDURE [dbo].[AddAddress]
	@City nvarchar(50),
	@State nvarchar(50),
	@Country nvarchar(50),
	@Zipcode nvarchar(50)
AS
	INSERT INTO [dbo].[Addresses] (City, State, Country, Zipcode)
	VALUES (@City, @State, @Country, @Zipcode)
	SELECT IDENT_CURRENT('Addresses')
