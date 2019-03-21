CREATE TABLE [dbo].[Masina]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdUser] INT NOT NULL, 
    [NumarMatricol] VARCHAR(50) NOT NULL, 
    CONSTRAINT [IdUser] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
)
