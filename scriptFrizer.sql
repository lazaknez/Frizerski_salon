USE [master]
GO
/****** Object:  Database [FrizerskiSalon]    Script Date: 9/17/2020 10:41:37 AM ******/
CREATE DATABASE [FrizerskiSalon]
GO
ALTER DATABASE [FrizerskiSalon] SET COMPATIBILITY_LEVEL = 120
GO

ALTER DATABASE [FrizerskiSalon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET ARITHABORT OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FrizerskiSalon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FrizerskiSalon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FrizerskiSalon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FrizerskiSalon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET RECOVERY FULL 
GO
ALTER DATABASE [FrizerskiSalon] SET  MULTI_USER 
GO
ALTER DATABASE [FrizerskiSalon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FrizerskiSalon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FrizerskiSalon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FrizerskiSalon] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FrizerskiSalon] SET DELAYED_DURABILITY = DISABLED 
GO

USE [FrizerskiSalon]
GO
/****** Object:  Table [dbo].[Frizer]    Script Date: 9/17/2020 10:41:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Frizer](
	[idFrizera] [nvarchar](50) NOT NULL,
	[imePrezime] [nvarchar](50) NULL,
 CONSTRAINT [PK_Frizer] PRIMARY KEY CLUSTERED 
(
	[idFrizera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Racun]    Script Date: 9/17/2020 10:41:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[idRacuna] [int] NOT NULL,
	[datumFormiranja] [date] NULL,
	[iznos] [numeric](11, 2) NULL,
	[idFrizera] [nvarchar](50) NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[idRacuna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StavkaRacuna]    Script Date: 9/17/2020 10:41:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaRacuna](
	[idRacuna] [int] NOT NULL,
	[redniBroj] [int] NOT NULL,
	[brojMinuta] [int] NULL,
	[cena] [numeric](11, 2) NULL,
	[idUsluga] [int] NULL,
 CONSTRAINT [PK_StavkaRacuna] PRIMARY KEY CLUSTERED 
(
	[idRacuna] ASC,
	[redniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipUsluge]    Script Date: 9/17/2020 10:41:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipUsluge](
	[idTipUsluge] [int] NOT NULL,
	[Naziv] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipUsluge] PRIMARY KEY CLUSTERED 
(
	[idTipUsluge] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usluga]    Script Date: 9/17/2020 10:41:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usluga](
	[idUsluga] [int] NOT NULL,
	[Naziv] [nvarchar](50) NULL,
	[Opis] [nvarchar](50) NULL,
	[CenaPoMinutu] [numeric](11, 2) NULL,
	[idTipUsluge] [int] NULL,
 CONSTRAINT [PK_Usluga] PRIMARY KEY CLUSTERED 
(
	[idUsluga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Frizer] ([idFrizera], [imePrezime]) VALUES (N'1111', N'Miki Maus')
INSERT [dbo].[Frizer] ([idFrizera], [imePrezime]) VALUES (N'2222', N'Mini Maus')
INSERT [dbo].[Frizer] ([idFrizera], [imePrezime]) VALUES (N'3333', N'Paja Patak')
INSERT [dbo].[TipUsluge] ([idTipUsluge], [Naziv]) VALUES (1, N'Tip 1')
INSERT [dbo].[TipUsluge] ([idTipUsluge], [Naziv]) VALUES (2, N'Tip 2')
INSERT [dbo].[TipUsluge] ([idTipUsluge], [Naziv]) VALUES (3, N'Tip 3')
INSERT [dbo].[TipUsluge] ([idTipUsluge], [Naziv]) VALUES (4, N'Tip 4')
ALTER TABLE [dbo].[Racun]  WITH CHECK ADD  CONSTRAINT [FK_Racun_Frizer] FOREIGN KEY([idFrizera])
REFERENCES [dbo].[Frizer] ([idFrizera])
GO
ALTER TABLE [dbo].[Racun] CHECK CONSTRAINT [FK_Racun_Frizer]
GO
ALTER TABLE [dbo].[StavkaRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkaRacuna_Racun] FOREIGN KEY([idRacuna])
REFERENCES [dbo].[Racun] ([idRacuna])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StavkaRacuna] CHECK CONSTRAINT [FK_StavkaRacuna_Racun]
GO
ALTER TABLE [dbo].[StavkaRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkaRacuna_Usluga] FOREIGN KEY([idUsluga])
REFERENCES [dbo].[Usluga] ([idUsluga])
GO
ALTER TABLE [dbo].[StavkaRacuna] CHECK CONSTRAINT [FK_StavkaRacuna_Usluga]
GO
ALTER TABLE [dbo].[Usluga]  WITH CHECK ADD  CONSTRAINT [FK_Usluga_TipUsluge] FOREIGN KEY([idTipUsluge])
REFERENCES [dbo].[TipUsluge] ([idTipUsluge])
GO
ALTER TABLE [dbo].[Usluga] CHECK CONSTRAINT [FK_Usluga_TipUsluge]
GO
USE [master]
GO
ALTER DATABASE [FrizerskiSalon] SET  READ_WRITE 
GO
