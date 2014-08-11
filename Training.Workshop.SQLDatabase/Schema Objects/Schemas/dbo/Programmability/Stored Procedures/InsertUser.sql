﻿CREATE PROCEDURE InsertUser (@Username nvarchar(50), @Password nvarchar(250), @Salt nvarchar(15))
AS
BEGIN
INSERT INTO dbo.Users 
(
 [Username], 
 [UserPassword],
 [Salt] 
)
VALUES
(
 @Username,
 @Password,
 @Salt 
)
END