USE [master]
GO
/****** Object:  Database [DatabaseFirst.Blogging]    Script Date: 11/19/2020 3:35:13 PM ******/
CREATE DATABASE [DatabaseFirst.Blogging]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DatabaseFirst.Blogging', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DatabaseFirst.Blogging.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DatabaseFirst.Blogging_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DatabaseFirst.Blogging_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DatabaseFirst.Blogging].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET ARITHABORT OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET  MULTI_USER 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET QUERY_STORE = OFF
GO
USE [DatabaseFirst.Blogging]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 11/19/2020 3:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Url] [nvarchar](200) NULL,
	[Title] [nvarchar](max) NULL,
	[DateModified] [datetime2](7) NULL,
 CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 11/19/2020 3:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Content] [ntext] NULL,
	[BlogId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 11/19/2020 3:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[First] [nchar](10) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([BlogId], [Name], [Url], [Title], [DateModified]) VALUES (1, N'First blog', N'www.myblog', N'Greetings', CAST(N'2020-11-19T15:18:35.5266667' AS DateTime2))
INSERT [dbo].[Blogs] ([BlogId], [Name], [Url], [Title], [DateModified]) VALUES (2, N'Second blog', N'www.myotherblog', N'hello', CAST(N'2020-11-19T15:23:35.6800000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Blogs] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1002, N'Great Cheese', N'TODO', 1)
INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1003, N'Great Meats', N'TODO', 1)
INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1004, N'Cheese ', N'TODO', 1)
INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1005, N'Fantastic Cheese in Germany', N'TODO', 2)
SET IDENTITY_INSERT [dbo].[Posts] OFF
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blogs_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Posts_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([BlogId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_dbo.Posts_dbo.Blogs_BlogId]
GO
USE [master]
GO
ALTER DATABASE [DatabaseFirst.Blogging] SET  READ_WRITE 
GO
