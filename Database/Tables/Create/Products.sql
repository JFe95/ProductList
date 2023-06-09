Use ProductList

If Not Exists (Select 1 From sys.objects Where object_id = OBJECT_ID(N'dbo.Products') AND type in (N'U'))

Create Table dbo.Products
(
	ProductId				int				Identity(1,1)	Not Null,
	[Name]					nvarchar(100)					Not Null,
	[Description]			nvarchar(1000)					Null,
	Price					decimal(18,2)					Not Null,
	[Priority]				bit				Default(0)		Not Null

	Constraint PKProduct Primary Key Clustered 
		(
			ProductId asc
		)With (Ignore_Dup_Key = Off) 
)

Go