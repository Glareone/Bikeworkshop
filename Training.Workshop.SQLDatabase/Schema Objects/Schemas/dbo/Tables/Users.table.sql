CREATE TABLE [Users]
(
	UserID			int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	Username		nvarchar(50) NOT NULL,
	UserPassword	nvarchar(50)  NOT NULL,
)
