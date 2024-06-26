﻿-- MERGE generated by running the 'sp_generate_merge' 
-- For more info: https://github.com/readyroll/generate-sql-merge

--   EXEC sp_generate_merge
--   @schema = 'dbo',
--   @table_name ='Book'

   USE [CollegeBooks]
GO

--MERGE generated by 'sp_generate_merge' stored procedure
--Originally by Vyas (http://vyaskn.tripod.com/code): sp_generate_inserts (build 22)
--Adapted for SQL Server 2008+ by Daniel Nolan (https://twitter.com/dnlnln)

SET NOCOUNT ON

SET IDENTITY_INSERT [dbo].[Book] ON

MERGE INTO [dbo].[Book] AS [Target]
USING (VALUES
(2,N'Mi dia de suerte',N'santillana@gmail.com',0,'2024-06-20T06:46:09.8089406','2024-06-20T06:46:09.8089406')
,(3,N'Cumpleaños feroz',N'kapeluz@gmail.com',0,'2024-06-20T06:46:29.2827957','2024-06-20T06:46:29.2827957')
,(4,N'Colon agarra viaje a toda costa',N'messi@gmail.com',0,'2024-06-20T06:47:08.4797072','2024-06-20T06:47:08.4797072')
) AS [Source] ([Id],[Title],[PublishingHouseEmail],[NumberOfReadings],[CreatedAt],[UpdatedAt])
ON ([Target].[Id] = [Source].[Id])
WHEN MATCHED AND (
NULLIF([Source].[Title], [Target].[Title]) IS NOT NULL OR NULLIF([Target].[Title], [Source].[Title]) IS NOT NULL OR
NULLIF([Source].[PublishingHouseEmail], [Target].[PublishingHouseEmail]) IS NOT NULL OR NULLIF([Target].[PublishingHouseEmail], [Source].[PublishingHouseEmail]) IS NOT NULL OR
NULLIF([Source].[NumberOfReadings], [Target].[NumberOfReadings]) IS NOT NULL OR NULLIF([Target].[NumberOfReadings], [Source].[NumberOfReadings]) IS NOT NULL OR
NULLIF([Source].[CreatedAt], [Target].[CreatedAt]) IS NOT NULL OR NULLIF([Target].[CreatedAt], [Source].[CreatedAt]) IS NOT NULL OR
NULLIF([Source].[UpdatedAt], [Target].[UpdatedAt]) IS NOT NULL OR NULLIF([Target].[UpdatedAt], [Source].[UpdatedAt]) IS NOT NULL) THEN
UPDATE SET
[Target].[Title] = [Source].[Title],
[Target].[PublishingHouseEmail] = [Source].[PublishingHouseEmail],
[Target].[NumberOfReadings] = [Source].[NumberOfReadings],
[Target].[CreatedAt] = [Source].[CreatedAt],
[Target].[UpdatedAt] = [Source].[UpdatedAt]
WHEN NOT MATCHED BY TARGET THEN
INSERT([Id],[Title],[PublishingHouseEmail],[NumberOfReadings],[CreatedAt],[UpdatedAt])
VALUES([Source].[Id],[Source].[Title],[Source].[PublishingHouseEmail],[Source].[NumberOfReadings],[Source].[CreatedAt],[Source].[UpdatedAt])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

DECLARE @mergeError int
, @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
BEGIN
PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[Book]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
END
ELSE
BEGIN
PRINT '[dbo].[Book] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
END
GO



SET IDENTITY_INSERT [dbo].[Book] OFF
SET NOCOUNT OFF
GO

