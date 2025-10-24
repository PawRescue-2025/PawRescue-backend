﻿CREATE TABLE [dbo].[Verifications]
(
	[Id]	 INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Status] NVARCHAR(50)	   NOT NULL,
	[UserId] NVARCHAR(450)	   NOT NULL,
	CONSTRAINT [FK_Verifications_To_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE
)
