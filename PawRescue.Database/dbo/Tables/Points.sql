CREATE TABLE [dbo].[Points]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    
    [RecipientId] NVARCHAR(450) NOT NULL,
    [ReviewerId] NVARCHAR(450) NULL, 
    
    [Points] INT NOT NULL,
    [Comment] NVARCHAR(MAX) NOT NULL,
    
    [ReviewDate] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(), 

    CONSTRAINT [FK_Points_To_Users_Recipient] FOREIGN KEY ([RecipientId]) REFERENCES [dbo].[AspNetUsers]([Id]),
    CONSTRAINT [FK_Points_To_Users_Reviewer] FOREIGN KEY ([ReviewerId]) REFERENCES [dbo].[AspNetUsers]([Id])
)