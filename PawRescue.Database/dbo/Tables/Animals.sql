CREATE TABLE [dbo].[Animals]
(
	[Id]	    INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [ShelterId] INT NOT NULL,
    [Name]      NVARCHAR(50) NOT NULL, 
    [Species]  NVARCHAR(50) NOT NULL, 
    [Breed] NVARCHAR(50) NOT NULL, 
    [Gender] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [Weight] INT NOT NULL, 
    [Size] INT NOT NULL, 
    [Description] TEXT NULL, 
    [IsHealthy] BIT NOT NULL, 
    [IsVaccinated] BIT NOT NULL,
    [IsSterilized] BIT NOT NULL, 
    [AdoptionStatus] INT NOT NULL, 
    [Documents] NVARCHAR(MAX)  NULL,
    [Photos] NVARCHAR(MAX)  NULL,
    [ArrivalDate] DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_Shelters_To_Animals] FOREIGN KEY ([ShelterId]) REFERENCES [dbo].[Shelters]([Id]) ON DELETE CASCADE

)
