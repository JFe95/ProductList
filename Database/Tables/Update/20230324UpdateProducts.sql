If Not Exists (Select 1 From INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = 'Products'And COLUMN_NAME = 'Url')
Begin
	Alter Table Products
		Add [Url] nvarchar(2048) Default('example.com') Not Null 
End

If  Not Exists (Select 1 From INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = 'Products'And COLUMN_NAME = 'ViewCount')
Begin
	Alter Table Products
		Add ViewCount int Default(0) Null 
End