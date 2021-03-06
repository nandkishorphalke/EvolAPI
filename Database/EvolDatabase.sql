/****** Object:  Table [dbo].[Contact]    Script Date: 08/16/2018 21:46:44 ******/

CREATE DATABASE EvolPOC2
GO

USE EvolPOC2

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Email] [varchar](20) NULL,
	[PhoneNumber] [char](10) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON
INSERT [dbo].[Contact] ([ContactId], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (1, N'Nandkishor', N'Phalke', N'test@test.com', N'1010101010', 1)
INSERT [dbo].[Contact] ([ContactId], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (2, N'Amit', N'Patil', N'test@test.com', N'2020202020', 1)
INSERT [dbo].[Contact] ([ContactId], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (3, N'Manish', N'Oza', N'test@test.com', N'3030303030', 0)
INSERT [dbo].[Contact] ([ContactId], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (4, N'Nikita', N'Phalke', N'test@test.com', N'4040404040', 0)
INSERT [dbo].[Contact] ([ContactId], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (5, N'Mayura', N'Parkale', N'test@test.com', N'6060606060', 0)
SET IDENTITY_INSERT [dbo].[Contact] OFF

GO
