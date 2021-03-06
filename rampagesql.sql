create database SMS_RAMPAGE
USE [SMS_RAMPAGE]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/16/2019 12:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/16/2019 12:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address] [varchar](255) NULL,
	[Contact] [varchar](11) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Loyality_Point] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/16/2019 12:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Reorder_Level] [int] NOT NULL,
	[Descriptions] [text] NULL,
	[Category_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 10/16/2019 12:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address] [varchar](255) NULL,
	[Contact] [varchar](11) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Contact_Person] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Code], [Name]) VALUES (1, N'1122', N'Electronics')
INSERT [dbo].[Category] ([Id], [Code], [Name]) VALUES (3, N'1124', N'Mobile')
INSERT [dbo].[Category] ([Id],[Code], [Name]) VALUES ( 4,N'1125', N'Food')

SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Contact], [Email], [Loyality_Point]) VALUES (1, N'1122', N'Rajib', N'Dhaka', N'09887766553', N'rj@ex.com', 10)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Contact], [Email], [Loyality_Point]) VALUES (2, N'1123', N'Rajib', N'Dhaka', N'09887766554', N'rj@wx.com', 10)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Code], [Name], [Reorder_Level], [Descriptions], [Category_Id]) VALUES (5, N'1111', N'Samsung', 10, N'This is from korea', 3)
INSERT [dbo].[Product] ([Id], [Code], [Name], [Reorder_Level], [Descriptions], [Category_Id]) VALUES (6, N'1112', N'Xiaomi', 10, N'This is from China', 3)

INSERT [dbo].[Product] ([Code], [Name], [Reorder_Level], [Descriptions], [Category_Id]) VALUES ( N'1114', N'Fan', 10, N'This is from japan', 1)

INSERT [dbo].[Product] ([Code], [Name], [Reorder_Level], [Descriptions], [Category_Id]) VALUES ( N'1113', N'Led Light', 10, N'This is from China', 1)

INSERT [dbo].[Product] ( [Code], [Name], [Reorder_Level], [Descriptions], [Category_Id]) VALUES ( N'1115', N'Pizza', 10, N'This is from korea', 4)
INSERT [dbo].[Product] ( [Code], [Name], [Reorder_Level], [Descriptions], [Category_Id]) VALUES ( N'1116', N'Burger', 10, N'This is from China', 4)


SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Code], [Name], [Address], [Contact], [Email], [Contact_Person]) VALUES (1, N'1122', N'Rahat', N'Dhaka', N'09827766553', N'rh@ex.com', N'Rahat Ahmed')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Category__737584F66B6C3BDA]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Category] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Category__A25C5AA7C89BC623]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Category] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__A25C5AA752336416]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__A9D1053490231DA2]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__F7C046655C7A6A66]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[Contact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Product__737584F694D4B11B]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Product] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Product__A25C5AA7F2753F4B]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Product] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Supplier__A25C5AA7170B3FB6]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Supplier] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Supplier__A9D105345DFE3937]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Supplier] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Supplier__F7C046653B98BB22]    Script Date: 10/16/2019 12:10:20 PM ******/
ALTER TABLE [dbo].[Supplier] ADD UNIQUE NONCLUSTERED 
(
	[Contact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO

select * from [dbo].[Category]
select * from [dbo].[Customer]
select * from [dbo].[Product]
select * from [dbo].[Supplier]
SELECT * FROM Product
SELECT Code FROM Product WHERE Name='Samsung'

create table Purchase
(
Id INT IDENTITY(1,1),
Date1 date,InvoiceNo varchar(20),
Supplier_id int FOREIGN KEY REFERENCES Supplier(Id) ,
category_id int FOREIGN KEY REFERENCES Category(Id),
Product_id int FOREIGN KEY REFERENCES Product(Id) ,
Manufacture_Date date,Expire_Date date,Quantity int,
Unit_Price float,MRP float,Remarks varchar(50)
)

CREATE TABLE Orders (
    OrderID int NOT NULL PRIMARY KEY,
    OrderNumber int NOT NULL,
    Product_Id int FOREIGN KEY REFERENCES Product(Id)
);
Select * from Purchase
insert into Purchase(Date1,InvoiceNo,Supplier_id,category_id,Product_id,Manufacture_Date,Expire_Date,Quantity.uni 
INSERT Purchase ( Date1, InvoiceNo, Supplier_id,category_id,Product_id,Manufacture_Date,Expire_Date,Quantity,MRP,Remarks) VALUES ( '2019-10-18' , 12345 , 2 , 3 , 5 , '2019-10-18'  , '2028-11-11'  , 5 ,  5300 ,'note 7' )

INSERT [dbo].[Product] ( [Code], [Name], [Reorder_Level], [Descriptions], [Category_Id]) VALUES ( N'1116', N'Burger', 10, N'This is from China', 4)


