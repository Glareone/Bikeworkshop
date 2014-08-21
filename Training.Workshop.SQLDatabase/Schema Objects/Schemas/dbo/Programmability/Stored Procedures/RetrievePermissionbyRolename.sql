CREATE PROCEDURE RetrievePermissionbyRolename (	@Rolename nvarchar(50),
											    @Permissionname nvarchar(50) OUTPUT
				  							  )
AS 
SELECT DISTINCT
P.Permissionname
FROM [Permission] P
JOIN [PermissionRole] PR
 ON PR.PermissionID = P.PermissionID 
JOIN [Role] R
 ON R.RoleName=@Rolename


/*
SELECT
Permissionname
FROM [Permission]
WHERE Permission.PermissionID IN
(
	SELECT E.PermissionID
	FROM  [PermissionRole] as E
	WHERE E.RoleID IN
	(
		SELECT A.RoleID
		FROM [Role] AS A
		WHERE A.RoleName=@Rolename
	)
)
*/