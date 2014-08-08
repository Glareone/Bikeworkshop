CREATE TABLE [dbo].[Bikes]
(
	BikeID				int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	Manufacturer		nvarchar(30) NOT NULL,
	Mark				nvarchar(50) NOT NULL,
	Owner				nvarchar(50) NOT NULL,
	BikeYear			date NOT NULL,
)
