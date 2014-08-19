CREATE PROCEDURE DeleteUser (@Username nvarchar(50))
AS
BEGIN
DELETE FROM [dbo.User]
WHERE
 [Username]=@Username
END