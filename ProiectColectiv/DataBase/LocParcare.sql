CREATE TABLE [dbo].[LocParcare]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdParcare] INT NOT NULL, 
    [Tip] INT NOT NULL, 
    CONSTRAINT [IdParcare] FOREIGN KEY ([IdParcare]) REFERENCES [Parcare]([Id]) 
)
