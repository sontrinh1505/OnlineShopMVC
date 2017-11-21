USE [OnlineShopMVC]
GO
/****** Object:  StoredProcedure [dbo].[Account_Login]    Script Date: 11/21/2017 5:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Account_Login] 
	@UserName varchar(50),
	@PassWord varchar(50)
AS
BEGIN
	declare @count int
	declare @res bit

	select @count = count(*) from Account where UserName = @UserName and PassWord = @PassWord

	if @count > 0
		set @res = 1
	else 
		set @res = 0

	select @res
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Category_Insert]    Script Date: 11/21/2017 5:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Category_Insert]
	@Name nvarchar(50),
	@Alias varchar(50),
	@ParentId int,
	@Order int,
	@Status bit
AS
BEGIN
	insert into Category(Name,Alias,ParentId,[Order],CreatedDate,Status)
	values(@Name, @Alias, @ParentId, @Order, getdate(), @Status)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_category_listAll]    Script Date: 11/21/2017 5:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_category_listAll]
as
select * from Category where Status = 1
order by [Order] asc  
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/21/2017 5:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[PassWord] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/21/2017 5:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NULL,
	[Alias] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Category_CreatedDate]  DEFAULT (getdate()),
	[Order] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/21/2017 5:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [varchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[CategoryId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Price] [decimal](18, 0) NULL,
	[Detail] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [UserName], [PassWord]) VALUES (1, N'admin', N'123456')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Alias], [ParentId], [CreatedDate], [Order], [Status]) VALUES (1, N'Phone                                             ', N'phone', NULL, CAST(N'2001-01-01 00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[Category] ([Id], [Name], [Alias], [ParentId], [CreatedDate], [Order], [Status]) VALUES (2, N'Tablet                                            ', N'tablet', NULL, CAST(N'2001-01-01 00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([Id], [Name], [Alias], [ParentId], [CreatedDate], [Order], [Status]) VALUES (3, N'Computer                                          ', N'computer', 1, CAST(N'2017-11-21 15:33:09.307' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
