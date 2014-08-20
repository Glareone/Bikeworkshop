CREATE PROCEDURE DeletefromUserRole (
										@Username nvarchar(50)
									)
AS
DELETE FROM [UserRole] 
WHERE UserID=
(
	SELECT 
	A.UserID
	FROM
	[User] AS A
	WHERE
	A.Username=@Username
)
