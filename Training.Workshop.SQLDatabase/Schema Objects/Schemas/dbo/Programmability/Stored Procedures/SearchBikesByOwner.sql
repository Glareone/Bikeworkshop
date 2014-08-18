CREATE PROCEDURE SearchBikesByOwner (@Username nvarchar(50),					
									 @Manufacturer nvarchar(30)		OUTPUT,
									 @Mark		   nvarchar(50)		OUTPUT,
									 @BikeYear     date				OUTPUT,
									 @OwnerID	   int				OUTPUT,
									 @ConditionState nvarchar(50)   OUTPUT
									)
AS
SELECT
@Manufacturer=Manufacturer,
@Mark=Mark,
@BikeYear=BikeYear,
@OwnerID=OwnerID,
@ConditionState=ConditionState
FROM dbo.Bikes
WHERE OwnerID=
(
 SELECT UserID
 FROM dbo.Users
 WHERE Username=@Username
)