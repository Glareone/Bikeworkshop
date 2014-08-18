CREATE PROCEDURE SearchBikesByOwner (@Username nvarchar(50),					
									 @Manufacturer nvarchar(30)		OUTPUT,
									 @Mark		   nvarchar(50)		OUTPUT,
									 @BikeYear     date				OUTPUT,
									 @OwnerID	   int				OUTPUT,
									 @ConditionState nvarchar(50)   OUTPUT
									)
AS
SELECT
*
FROM dbo.Bikes
WHERE OwnerID=
(
 SELECT I.UserID
 FROM dbo.Users AS I
 WHERE I.Username=@Username
)