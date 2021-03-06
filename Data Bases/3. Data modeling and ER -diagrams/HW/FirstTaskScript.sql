USE [master]
GO
/****** Object:  Database [TestE/RDiagram]    Script Date: 22-Aug-14 14:14:44 ******/
CREATE DATABASE [TestE/RDiagram]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestE_RDiagram', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TestE_RDiagram.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestE_RDiagram_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TestE_RDiagram_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestE/RDiagram] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestE/RDiagram].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestE/RDiagram] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestE/RDiagram] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestE/RDiagram] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestE/RDiagram] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestE/RDiagram] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestE/RDiagram] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET RECOVERY FULL 
GO
ALTER DATABASE [TestE/RDiagram] SET  MULTI_USER 
GO
ALTER DATABASE [TestE/RDiagram] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestE/RDiagram] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestE/RDiagram] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestE/RDiagram] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestE/RDiagram', N'ON'
GO
USE [TestE/RDiagram]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 22-Aug-14 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nvarchar](50) NULL,
	[town_id] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 22-Aug-14 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 22-Aug-14 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[continent_id] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 22-Aug-14 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[address_id] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 22-Aug-14 14:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[country_id] [int] NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (1, N'zsdasd', 2)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (2, N'asdf', 3)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (3, N'trgnty', 1)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (4, N'adfbbdfbfd', 10)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (5, N'erhthbgfbgf', 6)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'North America')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Australia')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (2, N'Germany', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (3, N'USA', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (4, N'Mexico', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (5, N'Canada', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (6, N'Australia', 3)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Berlin', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (3, N'Washington', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (4, N'New York', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (5, N'Mexico', 4)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (6, N'Tichuana', 4)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (7, N'Otava', 5)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (8, N'Toronto', 5)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (9, N'Perth', 6)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (10, N'Canbera', 6)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [TestE/RDiagram] SET  READ_WRITE 
GO
