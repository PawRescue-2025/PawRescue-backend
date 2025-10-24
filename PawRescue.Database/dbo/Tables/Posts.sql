CREATE TABLE [dbo].[Posts]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[UserId]   NVARCHAR(450)	   NOT NULL,
	[PostType] NVARCHAR(50)	   NOT NULL,
	[Title]     NVARCHAR(100)   NOT NULL,
	[Content]   TEXT           NOT NULL,
	[Status]    NVARCHAR(50)    NOT NULL,
	[IsHelpRequestCompleted] BIT NULL,
	[CreationDate] DATETIME2     NOT NULL DEFAULT GETDATE(),
	[DeletionDate] DATETIME2     NULL,
	[Location]   NVARCHAR(200)   NULL,
	CONSTRAINT [FK_Posts_To_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE
)
