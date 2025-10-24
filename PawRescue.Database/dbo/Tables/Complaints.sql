CREATE TABLE [dbo].[Complaints]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ComplainantId] NVARCHAR(450) NULL,
	[UserId] NVARCHAR(450) NULL,
	[PostId] INT NULL,
	[CommentId] INT NULL,
	[Category] NVARCHAR(100) NOT NULL,
	[Description] TEXT NULL,
	[Status] NVARCHAR(50) NOT NULL,
	[CreationDate] DATETIME2     NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_Complaints_To_Complainants] FOREIGN KEY ([ComplainantId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE SET NULL,
	CONSTRAINT [FK_Complaints_To_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_Complaints_To_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_Complaints_To_Comments] FOREIGN KEY ([CommentId]) REFERENCES [dbo].[Comments]([Id]) ON DELETE CASCADE
)
