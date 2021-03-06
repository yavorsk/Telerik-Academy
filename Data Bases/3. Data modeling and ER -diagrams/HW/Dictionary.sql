USE [master]
GO
/****** Object:  Database [Dictionary]    Script Date: 23-Aug-14 18:15:43 ******/
CREATE DATABASE [Dictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Dictionary.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Dictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [Dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [Dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dictionary', N'ON'
GO
USE [Dictionary]
GO
/****** Object:  Table [dbo].[Antonym Mapping]    Script Date: 23-Aug-14 18:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonym Mapping](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[AntonymID] [int] NULL,
 CONSTRAINT [PK_Antonym Mapping] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanation Mapping]    Script Date: 23-Aug-14 18:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanation Mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Explanation] [text] NULL,
	[LanguageID] [int] NULL,
 CONSTRAINT [PK_Explanation Mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hypernym/Hyponym mapping]    Script Date: 23-Aug-14 18:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hypernym/Hyponym mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[HypernymID] [int] NULL,
	[HyponymID] [int] NULL,
 CONSTRAINT [PK_Hypernym/Hyponym mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 23-Aug-14 18:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parts Of Speech]    Script Date: 23-Aug-14 18:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parts Of Speech](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PartOfSpeech] [nvarchar](50) NULL,
 CONSTRAINT [PK_Parts Of Speech] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonims Mapping]    Script Date: 23-Aug-14 18:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonims Mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NULL,
	[SynonimID] [int] NULL,
 CONSTRAINT [PK_Synonims Mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translation Words Mapping]    Script Date: 23-Aug-14 18:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translation Words Mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NULL,
	[TranslationWordID] [int] NULL,
 CONSTRAINT [PK_Translation Words Mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 23-Aug-14 18:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[wordID] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NULL,
	[ExplanationID] [int] NULL,
	[LanguageID] [int] NULL,
	[PartOfSpeechID] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Antonym Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Antonym Mapping_Words] FOREIGN KEY([AntonymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Antonym Mapping] CHECK CONSTRAINT [FK_Antonym Mapping_Words]
GO
ALTER TABLE [dbo].[Explanation Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Explanation Mapping_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Explanation Mapping] CHECK CONSTRAINT [FK_Explanation Mapping_Languages]
GO
ALTER TABLE [dbo].[Hypernym/Hyponym mapping]  WITH CHECK ADD  CONSTRAINT [FK_Hypernym/Hyponym mapping_Words] FOREIGN KEY([HypernymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Hypernym/Hyponym mapping] CHECK CONSTRAINT [FK_Hypernym/Hyponym mapping_Words]
GO
ALTER TABLE [dbo].[Hypernym/Hyponym mapping]  WITH CHECK ADD  CONSTRAINT [FK_Hypernym/Hyponym mapping_Words1] FOREIGN KEY([HyponymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Hypernym/Hyponym mapping] CHECK CONSTRAINT [FK_Hypernym/Hyponym mapping_Words1]
GO
ALTER TABLE [dbo].[Synonims Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Synonims Mapping_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Synonims Mapping] CHECK CONSTRAINT [FK_Synonims Mapping_Words]
GO
ALTER TABLE [dbo].[Synonims Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Synonims Mapping_Words1] FOREIGN KEY([SynonimID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Synonims Mapping] CHECK CONSTRAINT [FK_Synonims Mapping_Words1]
GO
ALTER TABLE [dbo].[Translation Words Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Translation Words Mapping_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Translation Words Mapping] CHECK CONSTRAINT [FK_Translation Words Mapping_Words]
GO
ALTER TABLE [dbo].[Translation Words Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Translation Words Mapping_Words1] FOREIGN KEY([TranslationWordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Translation Words Mapping] CHECK CONSTRAINT [FK_Translation Words Mapping_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Antonym Mapping] FOREIGN KEY([wordID])
REFERENCES [dbo].[Antonym Mapping] ([WordID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Antonym Mapping]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Explanation Mapping] FOREIGN KEY([ExplanationID])
REFERENCES [dbo].[Explanation Mapping] ([id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Explanation Mapping]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Parts Of Speech] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[Parts Of Speech] ([id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Parts Of Speech]
GO
USE [master]
GO
ALTER DATABASE [Dictionary] SET  READ_WRITE 
GO
