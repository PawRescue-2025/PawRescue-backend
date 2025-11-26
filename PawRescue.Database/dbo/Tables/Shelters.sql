CREATE TABLE [dbo].[Shelters]
(
	[Id]	      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[OwnerId]	  NVARCHAR(450)   NOT NULL,
	[Name]		  NVARCHAR(100)	   NOT NULL,
	[Description] NVARCHAR(MAX)   NOT NULL,
	[Location]	  NVARCHAR(200)   NOT NULL,

	[ContactPhone] NVARCHAR(50) NULL, 
    [ContactEmail] NVARCHAR(50) NULL, 
    [ContactLink] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Shelters_To_Users] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE
)
