CREATE PROCEDURE CountUsersWithUsername ( @username NVARCHAR(50), @UserWithUsernameCount INT OUTPUT ) 
AS 
SELECT 
@UserWithUsernameCount = COUNT(*) 
FROM dbo.Users
WHERE Username=@username