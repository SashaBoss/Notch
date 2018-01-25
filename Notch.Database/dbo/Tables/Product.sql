CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(256) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Discount] FLOAT NULL,
)
