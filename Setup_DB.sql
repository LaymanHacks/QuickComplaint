USE [master]
GO
CREATE LOGIN [QuickComplaintUser] WITH PASSWORD=N'P@ssw0rd', DEFAULT_DATABASE=[QuickComplaint], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [QuickComplaint]
GO
/****** Object:  User [QuickComplaintUser]    Script Date: 10/30/2016 9:30:35 PM ******/
CREATE USER [QuickComplaintUser] FOR LOGIN [QuickComplaintUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [QuickComplaintUser]
GO
/****** Object:  Table [dbo].[Complaint]    Script Date: 10/30/2016 9:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complaint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComplaintTypeId] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[LocationDetails] [nvarchar](1000) NULL,
	[ReportingPartyId] [int] NOT NULL,
 CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComplaintType]    Script Date: 10/30/2016 9:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComplaintType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](80) NULL,
 CONSTRAINT [PK_IssueType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhoneType]    Script Date: 10/30/2016 9:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportingParty]    Script Date: 10/30/2016 9:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportingParty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](128) NULL,
	[Phone] [nvarchar](50) NULL,
	[PhoneTypeId] [int] NULL,
 CONSTRAINT [PK_Reporter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ComplaintDetails]    Script Date: 10/30/2016 9:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ComplaintDetails]
AS
SELECT        dbo.Complaint.Id, dbo.ComplaintType.Name, dbo.Complaint.Description, dbo.Complaint.LocationDetails, dbo.ReportingParty.Name AS ReportingParty
FROM            dbo.Complaint INNER JOIN
                         dbo.ComplaintType ON dbo.Complaint.ComplaintTypeId = dbo.ComplaintType.Id INNER JOIN
                         dbo.ReportingParty ON dbo.Complaint.ReportingPartyId = dbo.ReportingParty.Id

GO
ALTER TABLE [dbo].[Complaint]  WITH CHECK ADD  CONSTRAINT [FK_Complaint_ComplaintType] FOREIGN KEY([ComplaintTypeId])
REFERENCES [dbo].[ComplaintType] ([Id])
GO
ALTER TABLE [dbo].[Complaint] CHECK CONSTRAINT [FK_Complaint_ComplaintType]
GO
ALTER TABLE [dbo].[Complaint]  WITH CHECK ADD  CONSTRAINT [FK_Complaint_ReportingParty] FOREIGN KEY([ReportingPartyId])
REFERENCES [dbo].[ReportingParty] ([Id])
GO
ALTER TABLE [dbo].[Complaint] CHECK CONSTRAINT [FK_Complaint_ReportingParty]
GO
ALTER TABLE [dbo].[ReportingParty]  WITH CHECK ADD  CONSTRAINT [FK_ReportingParty_PhoneType] FOREIGN KEY([PhoneTypeId])
REFERENCES [dbo].[PhoneType] ([Id])
GO
ALTER TABLE [dbo].[ReportingParty] CHECK CONSTRAINT [FK_ReportingParty_PhoneType]
GO

INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'Unspecified')
GO
INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'SG-99')
GO
INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'Meals Home Delivery Required')
GO
INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'Traffic/Illegal Parking')
GO
INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'Unlicensed Dog')
GO
INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'Weatherization')
GO
INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'Dead Tree')
GO
INSERT [dbo].[ComplaintType] ( [Name]) VALUES ( N'Found Property')
GO

INSERT [dbo].[PhoneType] ( [Name]) VALUES ( N'Cell')
GO
INSERT [dbo].[PhoneType] ( [Name]) VALUES ( N'Home')
GO
INSERT [dbo].[PhoneType] ( [Name]) VALUES ( N'Work')
GO
