CREATE PROCEDURE RetrieveRolesbyUsername	( @Username nvarchar(50),
											  @Rolename nvarchar(50) OUTPUT
											)
AS
SELECT
*
FROM [UserRole]
WHERE UserID=
	(
	 SELECT
	 A.UserID
	 FROM [User] as A
	 WHERE A.Username=@Username
	)