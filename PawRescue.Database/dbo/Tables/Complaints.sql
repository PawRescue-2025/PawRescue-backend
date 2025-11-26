CREATE TABLE [dbo].[Complaints]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ComplainantId] NVARCHAR(450) NULL,
	[UserId] NVARCHAR(450) NULL,
	[PostId] INT NULL,
	[CommentId] INT NULL,
	[Category] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Status] INT NOT NULL,
	[CreationDate] DATETIME2     NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_Complaints_To_Complainants] FOREIGN KEY ([ComplainantId]) REFERENCES [dbo].[AspNetUsers]([Id]),
	CONSTRAINT [FK_Complaints_To_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]),
	CONSTRAINT [FK_Complaints_To_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts]([Id]),
	CONSTRAINT [FK_Complaints_To_Comments] FOREIGN KEY ([CommentId]) REFERENCES [dbo].[Comments]([Id])
)
