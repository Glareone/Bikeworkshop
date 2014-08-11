CREATE PROCEDURE DeleteUser (@Username nvarchar(50))
AS
BEGIN
DELETE FROM dbo.Users 
WHERE
 [Username]=@Username
END