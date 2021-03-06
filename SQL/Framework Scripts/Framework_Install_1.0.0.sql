IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__StaffTabl__MemID__33D4B598]') AND parent_object_id = OBJECT_ID(N'[dbo].[StaffTable]'))
ALTER TABLE [dbo].[StaffTable] DROP CONSTRAINT [FK__StaffTabl__MemID__33D4B598]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__MemberTab__Admin__49C3F6B7]') AND parent_object_id = OBJECT_ID(N'[dbo].[MemberTable]'))
ALTER TABLE [dbo].[MemberTable] DROP CONSTRAINT [FK__MemberTab__Admin__49C3F6B7]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__FacesTabl__MemID__32E0915F]') AND parent_object_id = OBJECT_ID(N'[dbo].[FacesTable]'))
ALTER TABLE [dbo].[FacesTable] DROP CONSTRAINT [FK__FacesTabl__MemID__32E0915F]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__MemRe__31EC6D26]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MemberTable] DROP CONSTRAINT [DF__tmp_ms_xx__MemRe__31EC6D26]
END

GO
/****** Object:  Table [dbo].[StaffTable]    Script Date: 02/01/2017 18:21:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StaffTable]') AND type in (N'U'))
DROP TABLE [dbo].[StaffTable]
GO
/****** Object:  Table [dbo].[MemberTable]    Script Date: 02/01/2017 18:21:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberTable]') AND type in (N'U'))
DROP TABLE [dbo].[MemberTable]
GO
/****** Object:  Table [dbo].[FacesTable]    Script Date: 02/01/2017 18:21:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FacesTable]') AND type in (N'U'))
DROP TABLE [dbo].[FacesTable]
GO
/****** Object:  Table [dbo].[AdminTable]    Script Date: 02/01/2017 18:21:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdminTable]') AND type in (N'U'))
DROP TABLE [dbo].[AdminTable]
GO
/****** Object:  Database [FelicityLive]    Script Date: 02/01/2017 18:21:55 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'FelicityLive')
DROP DATABASE [FelicityLive]
GO
/****** Object:  Database [FelicityLive]    Script Date: 02/01/2017 18:21:55 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'FelicityLive')
BEGIN
CREATE DATABASE [FelicityLive] ON  PRIMARY 
( NAME = N'FelicityLive', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER1\MSSQL\DATA\FelicityLive.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FelicityLive_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER1\MSSQL\DATA\FelicityLive_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FelicityLive].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FelicityLive] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FelicityLive] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FelicityLive] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FelicityLive] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FelicityLive] SET ARITHABORT OFF 
GO
ALTER DATABASE [FelicityLive] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FelicityLive] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FelicityLive] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FelicityLive] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FelicityLive] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FelicityLive] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FelicityLive] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FelicityLive] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FelicityLive] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FelicityLive] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FelicityLive] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FelicityLive] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FelicityLive] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FelicityLive] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FelicityLive] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FelicityLive] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FelicityLive] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FelicityLive] SET RECOVERY FULL 
GO
ALTER DATABASE [FelicityLive] SET  MULTI_USER 
GO
ALTER DATABASE [FelicityLive] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FelicityLive] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FelicityLive', N'ON'
GO
USE [FelicityLive]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
/****** Object:  Table [dbo].[AdminTable]    Script Date: 02/01/2017 18:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdminTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AdminTable](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [varchar](max) NULL,
	[AdminEmail] [varchar](max) NULL,
	[AdminPinCode] [varchar](max) NULL,
 CONSTRAINT [PK__tmp_ms_x__719FE4E88144EE20] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FacesTable]    Script Date: 02/01/2017 18:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FacesTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FacesTable](
	[FaceID] [int] IDENTITY(1,1) NOT NULL,
	[MemFace0] [image] NULL,
	[MemFace1] [image] NULL,
	[MemFace2] [image] NULL,
	[MemFace3] [image] NULL,
	[MemFace4] [image] NULL,
	[MemFace5] [image] NULL,
	[MemFace6] [image] NULL,
	[MemFace7] [image] NULL,
	[MemFace8] [image] NULL,
	[MemFace9] [image] NULL,
	[MemFace10] [image] NULL,
	[MemFace11] [image] NULL,
	[MemFace12] [image] NULL,
	[MemFace13] [image] NULL,
	[MemFace14] [image] NULL,
	[MemFace15] [image] NULL,
	[MemFace16] [image] NULL,
	[MemFace17] [image] NULL,
	[MemFace18] [image] NULL,
	[MemFace19] [image] NULL,
	[MemFace20] [image] NULL,
	[MemID] [int] NOT NULL,
 CONSTRAINT [PK__FacesTab__58B5872D81B9C085] PRIMARY KEY CLUSTERED 
(
	[FaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MemberTable]    Script Date: 02/01/2017 18:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MemberTable](
	[MemID] [int] IDENTITY(1,1) NOT NULL,
	[MemFirstname] [varchar](max) NULL,
	[MemLastname] [varchar](max) NULL,
	[MemPhonenumber] [varchar](max) NULL,
	[MemDOB] [date] NULL,
	[MemPostcode] [varchar](max) NULL,
	[MemStatus] [bit] NULL,
	[MemRegDate] [date] NULL,
	[AdminID] [int] NOT NULL,
	[IsStaff] [bit] NULL,
 CONSTRAINT [PK__tmp_ms_x__E9341AE215E94679] PRIMARY KEY CLUSTERED 
(
	[MemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[StaffTable]    Script Date: 02/01/2017 18:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StaffTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StaffTable](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[BadgeNo] [int] NULL,
	[MemID] [int] NOT NULL,
 CONSTRAINT [PK__StaffTab__96D4AAF7709A9B30] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__MemRe__31EC6D26]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MemberTable] ADD  CONSTRAINT [DF__tmp_ms_xx__MemRe__31EC6D26]  DEFAULT (getdate()) FOR [MemRegDate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__FacesTabl__MemID__32E0915F]') AND parent_object_id = OBJECT_ID(N'[dbo].[FacesTable]'))
ALTER TABLE [dbo].[FacesTable]  WITH CHECK ADD  CONSTRAINT [FK__FacesTabl__MemID__32E0915F] FOREIGN KEY([MemID])
REFERENCES [dbo].[MemberTable] ([MemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__FacesTabl__MemID__32E0915F]') AND parent_object_id = OBJECT_ID(N'[dbo].[FacesTable]'))
ALTER TABLE [dbo].[FacesTable] CHECK CONSTRAINT [FK__FacesTabl__MemID__32E0915F]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__MemberTab__Admin__49C3F6B7]') AND parent_object_id = OBJECT_ID(N'[dbo].[MemberTable]'))
ALTER TABLE [dbo].[MemberTable]  WITH CHECK ADD  CONSTRAINT [FK__MemberTab__Admin__49C3F6B7] FOREIGN KEY([AdminID])
REFERENCES [dbo].[AdminTable] ([AdminID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__MemberTab__Admin__49C3F6B7]') AND parent_object_id = OBJECT_ID(N'[dbo].[MemberTable]'))
ALTER TABLE [dbo].[MemberTable] CHECK CONSTRAINT [FK__MemberTab__Admin__49C3F6B7]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__StaffTabl__MemID__33D4B598]') AND parent_object_id = OBJECT_ID(N'[dbo].[StaffTable]'))
ALTER TABLE [dbo].[StaffTable]  WITH CHECK ADD  CONSTRAINT [FK__StaffTabl__MemID__33D4B598] FOREIGN KEY([MemID])
REFERENCES [dbo].[MemberTable] ([MemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__StaffTabl__MemID__33D4B598]') AND parent_object_id = OBJECT_ID(N'[dbo].[StaffTable]'))
ALTER TABLE [dbo].[StaffTable] CHECK CONSTRAINT [FK__StaffTabl__MemID__33D4B598]
GO
ALTER DATABASE [FelicityLive] SET  READ_WRITE 
GO
