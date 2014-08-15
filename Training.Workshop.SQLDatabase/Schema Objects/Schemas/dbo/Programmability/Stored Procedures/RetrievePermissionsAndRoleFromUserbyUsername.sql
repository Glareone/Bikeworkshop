CREATE PROCEDURE RetrievePermissionsAndRoleFromUserbyUsername (
			@username nvarchar(50),		
			@role nvarchar(30)			OUTPUT,
			@permissions nvarchar(50)	OUTPUT
			)
AS
SELECT 
@role=Role,
@permissions=Permissions
FROM dbo.Users
WHERE Username=@username