CREATE TABLE [dbo].[Comments]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[AuthorId] NVARCHAR(450) NOT NULL,
	[PostId]   INT          NOT NULL,
	[Content] TEXT NOT NULL,
	[Status] NVARCHAR(50) NOT NULL,
	[CreationDate] DATETIME2     NOT NULL DEFAULT GETDATE(),
	[DeletionDate] DATETIME2     NULL,
	CONSTRAINT [FK_Comments_To_Users] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_Comments_To_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts]([Id]) ON DELETE CASCADE
)
