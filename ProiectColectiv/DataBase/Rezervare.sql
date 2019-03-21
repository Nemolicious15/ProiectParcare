CREATE TABLE [dbo].[Rezervare]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdLoc] INT NOT NULL, 
    [Start] DATETIME NOT NULL, 
    [End] DATETIME NOT NULL, 
    CONSTRAINT [IdLoc] FOREIGN KEY ([IdLoc]) REFERENCES [LocParcare]([Id])
)
