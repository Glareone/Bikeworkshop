CREATE PROCEDURE InsertUser (@Username nvarchar(50), @Password nvarchar(250), @Salt nvarchar(15),@Permissions nvarchar(50),@Role nvarchar(30))
AS
BEGIN
INSERT INTO dbo.Users 
(
 [Username], 
 [UserPassword],
 [Salt],
 [Permissions],
 [Role] 
)
VALUES
(
 @Username,
 @Password,
 @Salt,
 @Permissions,
 @Role 
)
END