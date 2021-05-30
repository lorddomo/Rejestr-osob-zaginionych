CREATE TABLE [dbo].[Lost]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Age] NVARCHAR(50) NOT NULL, 
    [LastSeenPlace] NVARCHAR(50) NOT NULL, 
    [LastSeenDate] DATE NOT NULL
)
