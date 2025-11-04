CREATE TABLE [dbo].[Verifications]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Status]    INT				   NOT NULL,
	[UserId]    NVARCHAR(450)	   NOT NULL,
	[Documents] NVARCHAR(MAX)  NULL,
	CONSTRAINT [FK_Verifications_To_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE
)
