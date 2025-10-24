CREATE TABLE [dbo].[Reports]
(
	[Id]	      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PostId] INT NOT NULL,
	[Text]   Text NULL,
	[CreationDate] DATETIME2     NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_Reports_To_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts]([Id]) ON DELETE CASCADE
)
