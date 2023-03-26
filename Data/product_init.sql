USE db_region01_v1;
create table [Product] (
	[ProductId] int not null,
	[ProductName] VARCHAR(100),
	[ProductCategory] VARCHAR(100),
	[ProductDescription] VARCHAR(100),
	[ModifiedDate] DateTime,
	[Price] Decimal
);
INSERT INTO [dbo].[Product] VALUES (1, 'product 1', 'category 1', 'Description 1', GETDATE(), 10);  
INSERT INTO [dbo].[Product] VALUES (2, 'product 2', 'category 2', 'Description 2', GETDATE(), 20.5);  
INSERT INTO [dbo].[Product] VALUES (3, 'product 3', 'category 3', 'Description 3', GETDATE(), 30);  
INSERT INTO [dbo].[Product] VALUES (4, 'product 4', 'category 4', 'Description 4', GETDATE(), 40);  
