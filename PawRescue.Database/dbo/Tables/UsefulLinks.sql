CREATE TABLE [dbo].[UsefulLinks]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Type] NVARCHAR(50) NOT NULL, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Content] TEXT NOT NULL, 
)
