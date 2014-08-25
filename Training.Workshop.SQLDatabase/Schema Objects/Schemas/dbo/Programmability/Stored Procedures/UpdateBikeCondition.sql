CREATE PROCEDURE UpdateBikeCondition (
									  @manufacturer nvarchar(30),
									  @mark nvarchar(50),
									  @ownerID int,
									  @condition nvarchar(50)
									 )
AS
UPDATE
[Bike]
SET ConditionState=@condition
WHERE Manufacturer=@manufacturer AND Mark=@mark AND OwnerID=@ownerID 