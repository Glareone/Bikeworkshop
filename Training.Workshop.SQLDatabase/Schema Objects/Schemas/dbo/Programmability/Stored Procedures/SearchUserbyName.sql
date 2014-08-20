CREATE PROCEDURE SearchUserbyName (
			@username nvarchar(50),		
			@userpassword nvarchar(50)	OUTPUT,
			@salt nvarchar(15)			OUTPUT)
AS
SELECT 
@userpassword=UserPassword,
@salt=Salt
FROM [User]
WHERE Username=@username