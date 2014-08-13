CREATE PROCEDURE SearchUserbyName (
			@username nvarchar(50),		
			@userpassword nvarchar(50)	OUTPUT,
			@role nvarchar(30)			OUTPUT,
			@permissions nvarchar(50)	OUTPUT,
			@salt nvarchar(15)			OUTPUT)
AS
SELECT 
@userpassword=UserPassword,
@role=Role,
@permissions=Permissions,
@salt=Salt
FROM dbo.Users
WHERE Username=@username