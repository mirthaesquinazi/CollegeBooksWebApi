﻿CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Title] VARCHAR(50) NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT (SYSUTCDATETIME()),
	[UpdatedAt] DATETIME2 NOT NULL DEFAULT (SYSUTCDATETIME()),
)
