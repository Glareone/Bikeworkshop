CREATE TABLE [Bikes]
(
	BikeID				int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	Manufacturer		nvarchar(30) NOT NULL,
	Mark				nvarchar(50) NOT NULL,
	BikeYear			date NOT NULL,
	OwnerID				int NULL,
	ConditionState		nvarchar(50) NULL,

)
