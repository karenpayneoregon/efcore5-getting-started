USE [DatabaseFirst.Blogging]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 11/20/2020 6:00:15 AM ******/
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
/****** Object:  Table [dbo].[Posts]    Script Date: 11/20/2020 6:00:15 AM ******/
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
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([BlogId], [Name], [Url], [Title], [DateModified]) VALUES (1, N'Developer insights', N'https://paynekaren.blogspot.com/', N'Greetings', CAST(N'2020-11-19T15:18:35.5266667' AS DateTime2))
INSERT [dbo].[Blogs] ([BlogId], [Name], [Url], [Title], [DateModified]) VALUES (2, N'Second blog', N'www.myotherblog', N'hello', CAST(N'2020-11-19T15:23:35.6800000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Blogs] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1002, N'Dialogs for web solutions mobile friendly', N'When building mobile friendly web solutions I needed a language agnostic solution and went with BootBox JS.', 1)
INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1003, N'GitHub download partial repository', N'There may be times when a developer wants one or two projects from a GitHub repository rather than downloading the entire repository.', 1)
INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1004, N'Entity Framework Core Find method code samples', N'At one time or another a record needs to be located, usually developers will use FirstOrDefault or SingleOrDefault (along with First and Single) to find a single records.

When working with a primary key using the Find and FindAsync method will find entities in the added state that are not yet persisted while the Where method will not and need to query the database. Also, in many cases Find will be a good deal faster than Where.

What developers need to do is learn what methods are available and work with the appropriate method for a specific task e.g. a model has City name, using Find will not work as it''s used on primary keys while FirstOrDefault to find the first city interested in or Where to find all cities interested in.

Here the Customers table has a single primary key, FindAsync will if a entity is located with the key passed in keys will record an entity while navigation properties will not be included.', 1)
INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (1005, N'Fantastic Cheese in Germany', N'TODO', 2)
INSERT [dbo].[Posts] ([PostId], [Title], [Content], [BlogId]) VALUES (2003, N'Entity Framework/Entity Framework Core connection strings for Windows Forms', N'When creating a DbContext for Entity Framework 6 or Entity Framework Core by default the constructor for Entity Framework 6 has the name for the connection string and for Entity Framework Core is embedded in OnConfigurating.', 2)
SET IDENTITY_INSERT [dbo].[Posts] OFF
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blogs_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Posts_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([BlogId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_dbo.Posts_dbo.Blogs_BlogId]
GO
