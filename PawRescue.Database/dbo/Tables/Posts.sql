CREATE TABLE [dbo].[Posts]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[UserId]   NVARCHAR(450)	   NOT NULL,
	[PostType] INT	   NOT NULL,
	[EventDate] DATETIME2     NULL,
	[Title]     NVARCHAR(100)   NOT NULL,
	[Content]   NVARCHAR(MAX)           NOT NULL,
	[Status]    INT    NOT NULL,
	[IsHelpRequestCompleted] BIT NULL,
	[CreationDate] DATETIME2     NOT NULL DEFAULT GETDATE(),
	[DeletionDate] DATETIME2     NULL,
	[Location]   NVARCHAR(200)   NULL,
	[Photos] NVARCHAR(MAX)  NULL,
	[ContactPhone] NVARCHAR(50) NULL, 
    [ContactEmail] NVARCHAR(50) NULL, 
	[ContactLink] NVARCHAR(50) NULL, 
	CONSTRAINT [FK_Posts_To_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE
)
