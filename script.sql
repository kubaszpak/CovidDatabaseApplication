USE [master]
GO
/****** Object:  Database [CovidDatabase]    Script Date: 10.05.2021 07:19:41 ******/
CREATE DATABASE [CovidDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CovidDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CovidDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CovidDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CovidDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CovidDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CovidDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CovidDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CovidDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CovidDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CovidDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CovidDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [CovidDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CovidDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CovidDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CovidDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CovidDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CovidDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CovidDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CovidDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CovidDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CovidDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CovidDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CovidDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CovidDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CovidDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CovidDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CovidDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CovidDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CovidDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [CovidDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [CovidDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CovidDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CovidDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CovidDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CovidDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CovidDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CovidDatabase', N'ON'
GO
ALTER DATABASE [CovidDatabase] SET QUERY_STORE = OFF
GO
USE [CovidDatabase]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VaccinationId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MedicalTitleId] [int] NOT NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PostCode] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalTitles]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalTitles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MedicalTitles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](9) NOT NULL,
	[ReceivedFirstDose] [bit] NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaccinations]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaccinations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[LocationId] [int] NOT NULL,
	[VaccineTypeId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
 CONSTRAINT [PK_Vaccinations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaccineTypes]    Script Date: 10.05.2021 07:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaccineTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](10) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[NumberOfDoses] [int] NOT NULL,
	[Cost] [money] NOT NULL,
 CONSTRAINT [PK_VaccineTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([Id], [VaccinationId], [PatientId]) VALUES (2, 7, 9)
INSERT [dbo].[Appointments] ([Id], [VaccinationId], [PatientId]) VALUES (3, 8, 11)
INSERT [dbo].[Appointments] ([Id], [VaccinationId], [PatientId]) VALUES (5, 31, 8)
INSERT [dbo].[Appointments] ([Id], [VaccinationId], [PatientId]) VALUES (6, 7, 18)
INSERT [dbo].[Appointments] ([Id], [VaccinationId], [PatientId]) VALUES (7, 7, 13)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([Id], [FirstName], [LastName], [MedicalTitleId]) VALUES (4, N'Jakub', N'Szpak', 1)
INSERT [dbo].[Doctors] ([Id], [FirstName], [LastName], [MedicalTitleId]) VALUES (5, N'Steve', N'Jobs', 2)
INSERT [dbo].[Doctors] ([Id], [FirstName], [LastName], [MedicalTitleId]) VALUES (6, N'John', N'Helpful', 3)
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([Id], [Name], [PostCode], [City], [Street], [RegionId]) VALUES (1, N'Szpital w Zielonej Górze', N'66-100', N'Zielona Góra', N'Mroczna 6', 1)
INSERT [dbo].[Locations] ([Id], [Name], [PostCode], [City], [Street], [RegionId]) VALUES (2, N'Szpital we Wrocławiu', N'66-101', N'Wrocław', N'Sezamkowa 3', 2)
INSERT [dbo].[Locations] ([Id], [Name], [PostCode], [City], [Street], [RegionId]) VALUES (3, N'Szpital wojewódzki w Lubrzy', N'66-102', N'Lubrza', N'Prosta 9', 3)
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[MedicalTitles] ON 

INSERT [dbo].[MedicalTitles] ([Id], [Name]) VALUES (1, N'Doktor')
INSERT [dbo].[MedicalTitles] ([Id], [Name]) VALUES (2, N'Pielęgniarz')
INSERT [dbo].[MedicalTitles] ([Id], [Name]) VALUES (3, N'Pomocnik')
SET IDENTITY_INSERT [dbo].[MedicalTitles] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (1, N'Jakub', N'Szpak', N'123456789', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (2, N'Kacper', N'Antos', N'123123123', 1)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (3, N'Elon', N'Musk', N'333333333', 1)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (4, N'Piotr', N'Pr', N'789610456', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (6, N'Jakub', N'Szpak', N'567123456', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (7, N'Piotr', N'Kredek', N'895689123', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (8, N'Kuba', N'Kredek', N'123567895', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (9, N'Kacper', N'Las', N'123123123', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (10, N'Elon', N'Musk', N'567123455', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (11, N'Elon', N'Musk', N'912367331', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (12, N'Melon', N'Kask', N'777777771', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (13, N'Melon', N'Kask', N'777777777', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (14, N'Piotrek', N'Zgredek', N'567123455', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (15, N'Elon', N'Musk', N'91236733a', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (16, N'Elon', N'Musk', N'912367333', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (17, N'Piotrek', N'Zgredek', N'567123451', 0)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [PhoneNumber], [ReceivedFirstDose]) VALUES (18, N'Piotrek', N'Zgredek', N'567123453', 0)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([Id], [Name]) VALUES (1, N'Lubuskie')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (2, N'Mazowieckie')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (3, N'Wielkopolskie')
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[Vaccinations] ON 

INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (6, CAST(N'2000-11-03' AS Date), 1, 1, 4)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (7, CAST(N'2020-12-04' AS Date), 2, 3, 5)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (8, CAST(N'2021-06-26' AS Date), 3, 4, 6)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (10, CAST(N'2015-12-17' AS Date), 1, 1, 5)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (21, CAST(N'2016-12-13' AS Date), 2, 1, 4)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (22, CAST(N'2021-03-26' AS Date), 2, 1, 6)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (23, CAST(N'2021-03-26' AS Date), 2, 1, 4)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (24, CAST(N'2021-03-26' AS Date), 1, 1, 4)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (29, CAST(N'2021-03-26' AS Date), 1, 3, 6)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (30, CAST(N'2021-03-26' AS Date), 3, 1, 5)
INSERT [dbo].[Vaccinations] ([Id], [Date], [LocationId], [VaccineTypeId], [DoctorId]) VALUES (31, CAST(N'2021-03-26' AS Date), 3, 3, 5)
SET IDENTITY_INSERT [dbo].[Vaccinations] OFF
GO
SET IDENTITY_INSERT [dbo].[VaccineTypes] ON 

INSERT [dbo].[VaccineTypes] ([Id], [Tag], [FullName], [Type], [NumberOfDoses], [Cost]) VALUES (1, N'PFZ', N'Pfizer', N'mRNA', 2, 73.0000)
INSERT [dbo].[VaccineTypes] ([Id], [Tag], [FullName], [Type], [NumberOfDoses], [Cost]) VALUES (3, N'AZ', N'AstraZeneca', N'adenowirus', 2, 15.0000)
INSERT [dbo].[VaccineTypes] ([Id], [Tag], [FullName], [Type], [NumberOfDoses], [Cost]) VALUES (4, N'MDN', N'Moderna', N'mRNA', 2, 120.0000)
SET IDENTITY_INSERT [dbo].[VaccineTypes] OFF
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Patients]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Vaccinations] FOREIGN KEY([VaccinationId])
REFERENCES [dbo].[Vaccinations] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Vaccinations]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_MedicalTitles] FOREIGN KEY([MedicalTitleId])
REFERENCES [dbo].[MedicalTitles] ([Id])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_MedicalTitles]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Regions] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Regions]
GO
ALTER TABLE [dbo].[Vaccinations]  WITH CHECK ADD  CONSTRAINT [FK_Vaccinations_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([Id])
GO
ALTER TABLE [dbo].[Vaccinations] CHECK CONSTRAINT [FK_Vaccinations_Doctors]
GO
ALTER TABLE [dbo].[Vaccinations]  WITH CHECK ADD  CONSTRAINT [FK_Vaccinations_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Vaccinations] CHECK CONSTRAINT [FK_Vaccinations_Locations]
GO
ALTER TABLE [dbo].[Vaccinations]  WITH CHECK ADD  CONSTRAINT [FK_Vaccinations_VaccineTypes] FOREIGN KEY([VaccineTypeId])
REFERENCES [dbo].[VaccineTypes] ([Id])
GO
ALTER TABLE [dbo].[Vaccinations] CHECK CONSTRAINT [FK_Vaccinations_VaccineTypes]
GO
USE [master]
GO
ALTER DATABASE [CovidDatabase] SET  READ_WRITE 
GO
