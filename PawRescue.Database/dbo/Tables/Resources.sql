CREATE TABLE [dbo].[Resources]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[ShelterId] INT NOT NULL,
	[Category] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[IsPresent] BIT NOT NULL,
	CONSTRAINT [FK_Resources_To_Shelters] FOREIGN KEY ([ShelterId]) REFERENCES [dbo].[Shelters]([Id]) ON DELETE CASCADE
)
