CREATE PROCEDURE usp_GetUser (@Username nvarchar(50))
AS
SELECT
r.RoleName
FROM [dbo].[Role] AS r
JOIN [dbo].[UserRole] AS ur ON ur.RoleID=r.RoleID
JOIN [dbo].[User] AS u ON ur.UserID=u.UserID
WHERE u.Username=@Username

SELECT
r.RoleName,p.Permissionname 
FROM [dbo].[Permission] AS p
JOIN [dbo].[PermissionRole] AS pr ON pr.PermissionID=p.PermissionID
JOIN [dbo].[Role] AS r ON r.RoleID=pr.RoleID
JOIN [dbo].[UserRole] AS ur ON ur.RoleID=r.RoleID
JOIN [dbo].[User] AS u ON u.UserID=ur.UserID
WHERE u.Username=@Username