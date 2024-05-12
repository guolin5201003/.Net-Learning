CREATE TABLE [dbo].[T_Order]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerID] BIGINT NOT NULL, 
    [ProductID] BIGINT NOT NULL, 
    [CreateDate] DATETIME NULL, 
    [Description] NVARCHAR(1500) NULL
)
