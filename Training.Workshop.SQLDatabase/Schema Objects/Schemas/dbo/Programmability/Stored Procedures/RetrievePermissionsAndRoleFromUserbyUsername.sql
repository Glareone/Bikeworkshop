CREATE PROCEDURE RetrievePermissionsAndRoleFromUserbyUsername (
			@username nvarchar(50),		
			@role nvarchar(30)			OUTPUT,
			@permissions nvarchar(50)	OUTPUT
			)
AS
SELECT 
*
FROM dbo.Users
WHERE Username=@username