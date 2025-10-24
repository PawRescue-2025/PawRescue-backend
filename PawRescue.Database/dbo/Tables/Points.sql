CREATE TABLE [dbo].[Points]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[RecipientId] NVARCHAR(450) NOT NULL,
	[ReviwerId] NVARCHAR(450) NULL,
	[Points]   INT          NOT NULL,
	[Comment]   TEXT NOT NULL,
	[ReviewDate] DATETIME2     NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_Points_To_Users_Recipient] FOREIGN KEY ([RecipientId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_Points_To_Users_Reviewer] FOREIGN KEY ([ReviwerId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE SET NULL
)
