USE [master]
GO
/****** Object:  Database [Product_Management]    Script Date: 27-10-2023 05:59:48 PM ******/
CREATE DATABASE [Product_Management]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Product_Management', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Product_Management.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Product_Management_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Product_Management_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Product_Management] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Product_Management].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Product_Management] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Product_Management] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Product_Management] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Product_Management] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Product_Management] SET ARITHABORT OFF 
GO
ALTER DATABASE [Product_Management] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Product_Management] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Product_Management] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Product_Management] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Product_Management] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Product_Management] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Product_Management] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Product_Management] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Product_Management] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Product_Management] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Product_Management] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Product_Management] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Product_Management] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Product_Management] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Product_Management] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Product_Management] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Product_Management] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Product_Management] SET RECOVERY FULL 
GO
ALTER DATABASE [Product_Management] SET  MULTI_USER 
GO
ALTER DATABASE [Product_Management] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Product_Management] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Product_Management] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Product_Management] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Product_Management] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Product_Management] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Product_Management', N'ON'
GO
ALTER DATABASE [Product_Management] SET QUERY_STORE = OFF
GO
USE [Product_Management]
GO
/****** Object:  Table [dbo].[Product_Details]    Script Date: 27-10-2023 05:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Details](
	[Product_Details_Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductVariant] [nvarchar](50) NULL,
	[ProductColor] [nvarchar](50) NULL,
	[ProductDes] [nvarchar](1000) NULL,
	[ProductCost] [decimal](9, 2) NULL,
	[ProductSalePrice] [decimal](9, 2) NULL,
	[ProductImage] [nvarchar](500) NULL,
 CONSTRAINT [PK__Product___844424212C449CA8] PRIMARY KEY CLUSTERED 
(
	[Product_Details_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductBrand] [nvarchar](50) NULL,
	[ProductManufacturer] [nvarchar](50) NULL,
 CONSTRAINT [PK__Products__B40CC6CD5506FB7F] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product_Details]  WITH CHECK ADD  CONSTRAINT [FK__Product_D__Produ__267ABA7A] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Product_Details] CHECK CONSTRAINT [FK__Product_D__Produ__267ABA7A]
GO
/****** Object:  StoredProcedure [dbo].[PR_Product_Details_Insert]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[PR_Product_Details_Insert]
    @ProductId int,
	@ProductVariant  nvarchar(50),
	@ProductColor  nvarchar(50),
	@ProductDes nvarchar(1000),
	@ProductCost decimal(9,2),
	@ProductSalePrice decimal(9,2),
	@ProductImage nvarchar(500)
AS

INSERT INTO [dbo].[Product_Details]
(
	       [dbo].[Product_Details].[ProductId],
		   [dbo].[Product_Details].[ProductVariant],
		   [dbo].[Product_Details].[ProductColor],
		   [dbo].[Product_Details].[ProductDes],
		   [dbo].[Product_Details].[ProductCost],
		   [dbo].[Product_Details].[ProductSalePrice],
		   [dbo].[Product_Details].[ProductImage] 
)

VALUES
(
	@ProductId,
	@ProductVariant,
	@ProductColor,
	@ProductDes,
	@ProductCost,
	@ProductSalePrice,
	ISNULL(@ProductImage,'Image')
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Product_Details_SelectAll]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PR_Product_Details_SelectAll]

AS

SELECT
           [dbo].[Product_Details].[Product_Details_Id],
		   [dbo].[Product_Details].[ProductId],
		   [dbo].[Product_Details].[ProductVariant],
		   [dbo].[Product_Details].[ProductColor],
		   [dbo].[Product_Details].[ProductDes],
		   [dbo].[Product_Details].[ProductCost],
		   [dbo].[Product_Details].[ProductSalePrice],
		   [dbo].[Product_Details].[ProductImage]
FROM	   [dbo].[Product_Details]
GO
/****** Object:  StoredProcedure [dbo].[PR_Product_Details_Update]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create    Procedure [dbo].[PR_Product_Details_Update]
	@Product_Details_Id int,
	@ProductId int,
	@ProductVariant  nvarchar(50),
	@ProductColor  nvarchar(50),
	@ProductDes nvarchar(1000),
	@ProductCost decimal(9,2),
	@ProductSalePrice decimal(9,2),
	@ProductImage nvarchar(500)
	

AS

Update [dbo].[Product_Details]

Set    
	   [dbo].[Product_Details].[ProductId]= @ProductId,
	   [dbo].[Product_Details].[ProductVariant]= @ProductVariant,
	   [dbo].[Product_Details].[ProductColor] = @ProductColor,
	   [dbo].[Product_Details].[ProductDes]=@ProductDes,
	   [dbo].[Product_Details].[ProductCost] = @ProductCost,
	   [dbo].[Product_Details].[ProductSalePrice]=@ProductSalePrice,
	   [dbo].[Product_Details].[ProductImage]=@ProductImage
	   
Where [dbo].[Product_Details].[Product_Details_Id] = @Product_Details_Id
GO
/****** Object:  StoredProcedure [dbo].[PR_Products_DeleteByPK]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       Procedure [dbo].[PR_Products_DeleteByPK]
	
	@ProductId int

AS


Delete from [dbo].[Product_Details]
Where [dbo].[Product_Details].[ProductId] = @ProductId
Delete from [dbo].[Products]
Where [dbo].[Products].[ProductId] = @ProductId
GO
/****** Object:  StoredProcedure [dbo].[PR_Products_Insert]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create       PROCEDURE [dbo].[PR_Products_Insert]
	@ProductName  nvarchar(50),
	@ProductBrand  nvarchar(50),
	@ProductManufacturer  nvarchar(50)
AS

INSERT INTO  [dbo].[Products]

(
	       [dbo].[Products].[ProductName],
		   [dbo].[Products].[ProductBrand],
		   [dbo].[Products].[ProductManufacturer]
)

VALUES
(
	@ProductName,
	@ProductBrand,
	@ProductManufacturer
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Products_SelectAll]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PR_Products_SelectAll]

AS

SELECT
           [dbo].[Products].[ProductId],
		   [dbo].[Products].[ProductName],
		   [dbo].[Products].[ProductBrand],
		   [dbo].[Products].[ProductManufacturer],
		   [dbo].[Product_Details].[ProductImage]
		  
FROM	   [dbo].[Products]
left outer join  [dbo].[Product_Details]
on [dbo].[Products].[ProductId]=[dbo].[Product_Details].[ProductId]
GO
/****** Object:  StoredProcedure [dbo].[PR_Products_SelectByPK]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create       PROCEDURE [dbo].[PR_Products_SelectByPK]

	@ProductId int

AS

SELECT   [dbo].[Products].[ProductId],
		   [dbo].[Products].[ProductName],
		   [dbo].[Products].[ProductBrand],
		   [dbo].[Products].[ProductManufacturer]
FROM   [dbo].[Products]

WHERE  [dbo].[Products].[ProductId] = @ProductId 
GO
/****** Object:  StoredProcedure [dbo].[PR_Products_Update]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create      Procedure [dbo].[PR_Products_Update]
	@ProductId int,
	@ProductName  nvarchar(50),
	@ProductBrand  nvarchar(50),
	@ProductManufacturer  nvarchar(50)
	

AS

Update [dbo].[Products]

Set    
	  [dbo].[Products].[ProductName]= @ProductName,
	  [dbo].[Products].[ProductBrand]= @ProductBrand,
	  [dbo].[Products].[ProductManufacturer] = @ProductManufacturer
	   
Where [dbo].[Products].[ProductId] = @ProductId
GO
/****** Object:  StoredProcedure [dbo].[PR_ProductsDetails_SelectByPK]    Script Date: 27-10-2023 05:59:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[PR_ProductsDetails_SelectByPK] 

	@ProductId int

AS

SELECT [dbo].[Product_Details].[Product_Details_Id],
		   [dbo].[Product_Details].[ProductId],
		   [dbo].[Product_Details].[ProductVariant],
		   [dbo].[Product_Details].[ProductColor],
		   [dbo].[Product_Details].[ProductDes],
		   [dbo].[Product_Details].[ProductCost],
		   [dbo].[Product_Details].[ProductSalePrice],
		   [dbo].[Product_Details].[ProductImage]
FROM  [dbo].[Product_Details]

WHERE  [dbo].[Product_Details].[ProductId] = @ProductId
GO
USE [master]
GO
ALTER DATABASE [Product_Management] SET  READ_WRITE 
GO
