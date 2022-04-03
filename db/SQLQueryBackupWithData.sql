USE [master]
GO
/****** Object:  Database [BNAMS]    Script Date: 03-Apr-22 2:53:27 PM ******/
CREATE DATABASE [BNAMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BNAMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BNAMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BNAMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BNAMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BNAMS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BNAMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BNAMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BNAMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BNAMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BNAMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BNAMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [BNAMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BNAMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BNAMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BNAMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BNAMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BNAMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BNAMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BNAMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BNAMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BNAMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BNAMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BNAMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BNAMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BNAMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BNAMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BNAMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BNAMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BNAMS] SET RECOVERY FULL 
GO
ALTER DATABASE [BNAMS] SET  MULTI_USER 
GO
ALTER DATABASE [BNAMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BNAMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BNAMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BNAMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BNAMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BNAMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BNAMS', N'ON'
GO
ALTER DATABASE [BNAMS] SET QUERY_STORE = OFF
GO
USE [BNAMS]
GO
/****** Object:  Table [dbo].[HR_TraineePersonBio]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HR_TraineePersonBio](
	[TraningPersonId] [nvarchar](50) NOT NULL,
	[BioDataCode] [nvarchar](50) NULL,
	[Pno] [nvarchar](50) NULL,
	[RankId] [nvarchar](50) NULL,
	[Name] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_HR_TraineePersonBio] PRIMARY KEY CLUSTERED 
(
	[TraningPersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HR_TraningInformation]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HR_TraningInformation](
	[TrainingId] [nvarchar](50) NOT NULL,
	[TraningCode] [nvarchar](50) NULL,
	[WeaponTypeId] [nvarchar](50) NULL,
	[CourseName] [varchar](50) NULL,
	[RefNo] [varchar](50) NULL,
	[TraningPersonBioId] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CounryId] [nvarchar](50) NULL,
	[OrganizationId] [nvarchar](50) NULL,
	[LocalAbroadStatus] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_HR_TraningInformation] PRIMARY KEY CLUSTERED 
(
	[TrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[I_BinLocation]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[I_BinLocation](
	[BinLocationId] [nvarchar](50) NOT NULL,
	[ProgramName] [varchar](50) NULL,
	[ProcessDate] [datetime] NULL,
	[WareHouseId] [nvarchar](50) NULL,
	[SelfIdNo] [varchar](50) NULL,
	[RowIdNo] [varchar](50) NULL,
	[ProductCategoryId] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_I_BinLocation] PRIMARY KEY CLUSTERED 
(
	[BinLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[I_Indent]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[I_Indent](
	[IndentId] [nvarchar](50) NOT NULL,
	[IndentType] [nvarchar](50) NULL,
	[ProgramId] [nvarchar](50) NULL,
	[IndentNo] [nvarchar](50) NULL,
	[IndentFrom] [nvarchar](50) NULL,
	[IssueTo] [nvarchar](50) NULL,
	[ItemId] [nvarchar](50) NULL,
	[IndentQuantity] [int] NULL,
	[IndentValidity] [datetime] NULL,
	[OtherOptions] [varchar](50) NULL,
	[Remarks] [varchar](50) NULL,
	[IndentStatusId] [nvarchar](50) NULL,
	[IndentStatusDate] [datetime] NULL,
	[CompositeId] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsStatus] [int] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_I_Indent] PRIMARY KEY CLUSTERED 
(
	[IndentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[I_MaintenanceInfo]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[I_MaintenanceInfo](
	[MaintainceId] [nvarchar](50) NOT NULL,
	[MaintainceCode] [nvarchar](50) NULL,
	[ItemId] [nvarchar](50) NULL,
	[LastMaintainceDate] [datetime] NULL,
	[MaintainceYear] [varchar](50) NULL,
	[MaintainceDetails] [varchar](500) NULL,
	[MaintainceLocation] [varchar](50) NULL,
	[DefectInfo] [varchar](500) NULL,
	[MaintainceTypeId] [nvarchar](50) NULL,
	[NextMaintainceSchadule] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_I_MaintenanceInfo] PRIMARY KEY CLUSTERED 
(
	[MaintainceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[I_StatusAfterMaintaince]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[I_StatusAfterMaintaince](
	[AfterMaintainceStatusId] [nvarchar](50) NOT NULL,
	[AfterMaintainceStatusCode] [nvarchar](50) NULL,
	[WeaponsInfoId] [nvarchar](50) NULL,
	[MaintainceStatusId] [nvarchar](50) NULL,
	[Remarks] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_I_StatusAfterMaintaince] PRIMARY KEY CLUSTERED 
(
	[AfterMaintainceStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[I_WeaponsInfo]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[I_WeaponsInfo](
	[WeaponsInfoId] [nvarchar](50) NOT NULL,
	[WeaponsTypeId] [nvarchar](50) NOT NULL,
	[NameOfWeaponsId] [nvarchar](50) NULL,
	[TrackingNo] [nvarchar](50) NULL,
	[WeaponsModel] [nvarchar](50) NULL,
	[RegistrationNo] [nvarchar](50) NULL,
	[ManufactureYear] [nvarchar](50) NULL,
	[FiscalYearId] [nvarchar](50) NULL,
	[OriginCountryId] [nvarchar](50) NULL,
	[ManufactureCountryId] [nvarchar](50) NULL,
	[Purpose] [nvarchar](50) NULL,
	[ProcurementYear] [nvarchar](50) NULL,
	[WarrantyPeriod] [nvarchar](50) NULL,
	[PriceTypeId] [nvarchar](50) NULL,
	[UnitPrice] [nvarchar](50) NULL,
	[Quantity] [decimal](18, 0) NULL,
	[QuantityCategoryId] [nvarchar](50) NULL,
	[TotalPrice] [nvarchar](50) NULL,
	[LocalAgentId] [nvarchar](50) NULL,
	[PrincipalAgentId] [nvarchar](50) NULL,
	[ManufactureAgentId] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[DepotId] [nvarchar](50) NULL,
	[ProcurementCatId] [nvarchar](50) NULL,
	[WareHouseId] [nvarchar](50) NULL,
	[BinLocationId] [nvarchar](50) NULL,
	[TechnicalSpec] [varchar](500) NULL,
	[Weight] [nvarchar](50) NULL,
	[Dimention] [nvarchar](50) NULL,
	[MaximumRange] [nvarchar](50) NULL,
	[EffectiveRange] [nvarchar](50) NULL,
	[MuzzeleVelocity] [nvarchar](50) NULL,
	[BarrelLife] [nvarchar](50) NULL,
	[OperatingTemp] [nvarchar](50) NULL,
	[StoringTemp] [nvarchar](50) NULL,
	[PreservatingTemp] [nvarchar](50) NULL,
	[StatusId] [nvarchar](50) NULL,
	[DateAfterAcceptance] [datetime] NULL,
	[WorkOrderNumber] [nvarchar](50) NULL,
	[Remarks] [varchar](500) NULL,
	[MissilTypeId] [nvarchar](50) NULL,
	[SerialNumber] [nvarchar](50) NULL,
	[ShelfLifeOfWeapon] [nvarchar](50) NULL,
	[ShelfLifeOfLauncher] [nvarchar](50) NULL,
	[PreparationTimeId] [nvarchar](50) NULL,
	[CombatDuration] [varchar](50) NULL,
	[Caliber] [varchar](50) NULL,
	[AmmunitationTypeId] [nvarchar](50) NULL,
	[LotNumberId] [nvarchar](50) NULL,
	[ProofFiringStatus] [varchar](50) NULL,
	[ProofFiringDate] [datetime] NULL,
	[Humidity] [varchar](50) NULL,
	[IsUse] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsMaintaince] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[Brand] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_I_WeaponsInfo] PRIMARY KEY CLUSTERED 
(
	[WeaponsInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[I_WeaponsInfotracking]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[I_WeaponsInfotracking](
	[WeaponTracking] [int] IDENTITY(1,1) NOT NULL,
	[WeaponId] [nvarchar](50) NULL,
	[DepotId] [nvarchar](50) NULL,
	[ProcQuantity] [int] NULL,
 CONSTRAINT [PK_I_WeaponsInfotracking] PRIMARY KEY CLUSTERED 
(
	[WeaponTracking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Agent]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Agent](
	[LocalAgentId] [nvarchar](50) NOT NULL,
	[Code] [varchar](50) NULL,
	[SupplierName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[EnlistmintType] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[ContractNumber] [varchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[AgentTypeId] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_LocalAgent] PRIMARY KEY CLUSTERED 
(
	[LocalAgentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_AgentEnlistment]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_AgentEnlistment](
	[EnlistmentTypeId] [nvarchar](50) NOT NULL,
	[EnlistmentType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_AgentEstimation] PRIMARY KEY CLUSTERED 
(
	[EnlistmentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_AgentType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_AgentType](
	[AgentTypeId] [varchar](50) NOT NULL,
	[AgentType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_AgentType] PRIMARY KEY CLUSTERED 
(
	[AgentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Area]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Area](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_Area] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Authorirty]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Authorirty](
	[AuthorityId] [nvarchar](50) NOT NULL,
	[AuthorityCode] [varchar](50) NULL,
	[AuthorityName] [varchar](50) NULL,
	[AreaId] [int] NULL,
	[Contract] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_Authorirty] PRIMARY KEY CLUSTERED 
(
	[AuthorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_CapabilityOfWeapons]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_CapabilityOfWeapons](
	[CapabilityOfWeaponsID] [nvarchar](50) NOT NULL,
	[CapabilityCode] [varchar](50) NULL,
	[CapabilityName] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_CapabilityOfWeapons] PRIMARY KEY CLUSTERED 
(
	[CapabilityOfWeaponsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Composite]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Composite](
	[CompositeId] [nvarchar](50) NOT NULL,
	[CompositeCode] [varchar](50) NULL,
	[CompositeName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_Composite] PRIMARY KEY CLUSTERED 
(
	[CompositeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Country]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Country](
	[CountryNameId] [nvarchar](50) NOT NULL,
	[CountryCode] [varchar](50) NULL,
	[CountryName] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
	[DollerType] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_Country] PRIMARY KEY CLUSTERED 
(
	[CountryNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_DepotShipCategory]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_DepotShipCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_FiscalYear]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_FiscalYear](
	[FiscalYearId] [nvarchar](50) NOT NULL,
	[FiscalYearCode] [varchar](10) NULL,
	[Name] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_FiscalYear] PRIMARY KEY CLUSTERED 
(
	[FiscalYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_IndentStatus]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_IndentStatus](
	[IndentStatusId] [nvarchar](50) NOT NULL,
	[IndentStatus] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_IndentStatus] PRIMARY KEY CLUSTERED 
(
	[IndentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_IndentType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_IndentType](
	[IndentTypeId] [nvarchar](50) NOT NULL,
	[IndentTypeName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_IndentType] PRIMARY KEY CLUSTERED 
(
	[IndentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_MaintainceStatus(c)]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_MaintainceStatus(c)](
	[MaintainceStatusId] [nvarchar](50) NOT NULL,
	[Status] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_maintainceStatus(c)] PRIMARY KEY CLUSTERED 
(
	[MaintainceStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_MaintainceType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_MaintainceType](
	[MaintainceId] [nvarchar](50) NOT NULL,
	[MaintainceType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_MaintainceType] PRIMARY KEY CLUSTERED 
(
	[MaintainceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Menu]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[SubParentId] [int] NULL,
	[MenuName] [varchar](50) NULL,
	[MenuClass] [varchar](50) NULL,
	[MenuId] [varchar](50) NULL,
	[MenuUrl] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SortingOrderHelper] [int] NULL,
	[SetUpUserId] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdateUserId] [int] NULL,
	[UpdateDateTime] [datetime] NULL,
 CONSTRAINT [PK_M_Manu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_MissilePrepType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_MissilePrepType](
	[MissilePrepTimeId] [nvarchar](50) NOT NULL,
	[MissilePrepTime] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_MissilePrepType] PRIMARY KEY CLUSTERED 
(
	[MissilePrepTimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_NameOfWeapon]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_NameOfWeapon](
	[NameOfGunId] [nvarchar](50) NOT NULL,
	[NameOfGunCode] [varchar](50) NULL,
	[WeaponsTypeId] [nvarchar](50) NULL,
	[NameOfGun] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_NameOfGun] PRIMARY KEY CLUSTERED 
(
	[NameOfGunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_PriceType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_PriceType](
	[PriceTypeId] [nvarchar](50) NOT NULL,
	[PriceType] [varchar](50) NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_ProcurementCategory]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_ProcurementCategory](
	[ProcurementId] [nvarchar](50) NOT NULL,
	[ProcurementCode] [varchar](50) NULL,
	[ProcurementName] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_ProcurementCategory] PRIMARY KEY CLUSTERED 
(
	[ProcurementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_ProductCategory]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_ProductCategory](
	[ProductCategoryId] [nvarchar](50) NOT NULL,
	[ProductCtegoryName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_QuantityCategory]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_QuantityCategory](
	[QuantityId] [nvarchar](50) NOT NULL,
	[QuantityCode] [varchar](50) NULL,
	[QuantityName] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_QuantityCategory] PRIMARY KEY CLUSTERED 
(
	[QuantityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_RankSetup]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_RankSetup](
	[RankSetupId] [nvarchar](50) NOT NULL,
	[RankName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_RankSetup] PRIMARY KEY CLUSTERED 
(
	[RankSetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_StatusInformation]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_StatusInformation](
	[StatusId] [nvarchar](50) NOT NULL,
	[StatusCode] [varchar](50) NULL,
	[StatusName] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_StatusInformation] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_TraningOrg]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_TraningOrg](
	[TraningOrgId] [nvarchar](50) NOT NULL,
	[OrgName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_TraningOrg] PRIMARY KEY CLUSTERED 
(
	[TraningOrgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_TypeOfShip]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_TypeOfShip](
	[ShipTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_TypeOfShip] PRIMARY KEY CLUSTERED 
(
	[ShipTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_WareHouseType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_WareHouseType](
	[WareHouseTypeId] [nvarchar](50) NOT NULL,
	[WarHouseType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_M_WareHouseType] PRIMARY KEY CLUSTERED 
(
	[WareHouseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_WeaponsModelType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_WeaponsModelType](
	[GunModelId] [nvarchar](50) NOT NULL,
	[GunModelCode] [varchar](50) NULL,
	[GunModelName] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
	[WeaponsTypeId] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_M_GunModelType] PRIMARY KEY CLUSTERED 
(
	[GunModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_WeaponsType]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_WeaponsType](
	[WeaponsTypeId] [nvarchar](50) NOT NULL,
	[WeaponsType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_M_WeaponsType] PRIMARY KEY CLUSTERED 
(
	[WeaponsTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[O_DirectorateInfo]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[O_DirectorateInfo](
	[DirectorateID] [nvarchar](50) NOT NULL,
	[AdminAuthorityId] [nvarchar](50) NULL,
	[DirectorateCode] [varchar](50) NULL,
	[DirectorateName] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[TelephoneNumber] [varchar](50) NULL,
	[FaxNumber] [varchar](50) NULL,
	[WebAddress] [varchar](50) NULL,
	[Logo] [varchar](150) NULL,
	[AreaId] [int] NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_O_DirectorateInfo] PRIMARY KEY CLUSTERED 
(
	[DirectorateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[O_ShipOrDepotInfo]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[O_ShipOrDepotInfo](
	[ShipOrDepotId] [nvarchar](50) NOT NULL,
	[ShipOrDepotCode] [varchar](50) NULL,
	[DirectorateId] [nvarchar](50) NULL,
	[ShipDepotCategory] [int] NULL,
	[ShipDepotName] [varchar](50) NULL,
	[DateOfCommmisson] [datetime] NULL,
	[WTCallSign] [varchar](50) NULL,
	[CapabilityOfWeaponsId] [nvarchar](50) NULL,
	[TypeOfShip] [int] NULL,
	[Telephone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[FaxNo] [varchar](50) NULL,
	[WebAddress] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_O_ShipOrDepotInfo] PRIMARY KEY CLUSTERED 
(
	[ShipOrDepotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[O_WareHouse]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[O_WareHouse](
	[WareHouseId] [nvarchar](50) NOT NULL,
	[ProgramName] [varchar](50) NULL,
	[ProcessDate] [datetime] NULL,
	[WareHouseTypeId] [nvarchar](50) NULL,
	[WareHouseCode] [varchar](50) NULL,
	[WareHouseName] [varchar](50) NULL,
	[Address1] [varchar](250) NULL,
	[Address2] [varchar](250) NULL,
	[UnitShipId] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_O_WareHouse] PRIMARY KEY CLUSTERED 
(
	[WareHouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmpIdNumber] [varchar](50) NULL,
	[EmployeePhoneNo] [varchar](50) NULL,
	[EmpImage] [varchar](100) NULL,
	[DirectorateId] [nvarchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](256) NOT NULL,
	[PhoneNo] [varchar](50) NULL,
	[UserRole] [int] NULL,
	[IsActive] [bit] NULL,
	[UserName] [varchar](50) NOT NULL,
	[LastLoginDate] [datetime] NULL,
	[SessionKey] [text] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[PermId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
	[IsEdit] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[IsCreate] [bit] NOT NULL,
 CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED 
(
	[PermId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[RoleId] [int] NOT NULL,
	[UserRoleName] [varchar](50) NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[IsActive] [bit] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[W_Inspection]    Script Date: 03-Apr-22 2:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[W_Inspection](
	[InspectionId] [nvarchar](50) NOT NULL,
	[ProgramId] [nvarchar](50) NULL,
	[DepotId] [nvarchar](50) NULL,
	[ItemCategoryId] [nvarchar](50) NULL,
	[ItemId] [nvarchar](50) NULL,
	[LastInspectionDate] [datetime] NULL,
	[NextInspectionDate] [datetime] NULL,
	[INstallDate] [datetime] NULL,
	[InstallBy] [varchar](50) NULL,
	[InstallAt] [varchar](50) NULL,
	[InspectionDate] [datetime] NULL,
	[InspectionMethod] [varchar](50) NULL,
	[InspectionBy] [varchar](50) NULL,
	[Commence] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SetUpBy] [int] NULL,
	[SetUpDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsBackup] [bit] NULL,
	[DerectorateId] [nvarchar](50) NULL,
	[LastBackupDate] [datetime] NULL,
 CONSTRAINT [PK_W_Inspection] PRIMARY KEY CLUSTERED 
(
	[InspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[I_BinLocation] ([BinLocationId], [ProgramName], [ProcessDate], [WareHouseId], [SelfIdNo], [RowIdNo], [ProductCategoryId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-BIN-1591705722', N'shelf-1', CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'DIR-1586243597-WAR-1591698878', N'shelf-1', N'row-1', N'PROD-1591700343', 1, 2, CAST(N'2020-06-09T18:28:42.080' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.073' AS DateTime))
GO
INSERT [dbo].[I_BinLocation] ([BinLocationId], [ProgramName], [ProcessDate], [WareHouseId], [SelfIdNo], [RowIdNo], [ProductCategoryId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-BIN-1591705779', N'shelf-1', CAST(N'2020-02-06T00:00:00.000' AS DateTime), N'DIR-1586243597-WAR-1591698878', N'shelf-1', N'row-2', N'PROD-1591700343', 1, 2, CAST(N'2020-06-09T18:29:39.577' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.073' AS DateTime))
GO
INSERT [dbo].[I_Indent] ([IndentId], [IndentType], [ProgramId], [IndentNo], [IndentFrom], [IssueTo], [ItemId], [IndentQuantity], [IndentValidity], [OtherOptions], [Remarks], [IndentStatusId], [IndentStatusDate], [CompositeId], [IsActive], [IsStatus], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-INS-1600275416', NULL, NULL, N'1', N'DIR-1586243597-SHIP-1591697358', N'DIR-1586243597-SHIP-1591677412', N'DIR-1586243597-W-1593891858-W-1', 10, CAST(N'2020-09-01T00:00:00.000' AS DateTime), N'others ', NULL, NULL, NULL, N'COMP-1592236762', 0, 2, NULL, NULL, 1586280264, CAST(N'2020-09-17T00:59:43.507' AS DateTime), 0, N'DIR-1586243597', NULL)
GO
INSERT [dbo].[I_Indent] ([IndentId], [IndentType], [ProgramId], [IndentNo], [IndentFrom], [IssueTo], [ItemId], [IndentQuantity], [IndentValidity], [OtherOptions], [Remarks], [IndentStatusId], [IndentStatusDate], [CompositeId], [IsActive], [IsStatus], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-INS-1600276112', NULL, NULL, N'2', N'DIR-1586243597-SHIP-1591697358', N'DIR-1586243597-SHIP-1591677412', N'DIR-1586243597-W-1593892064-W-1', 20, CAST(N'2020-09-01T00:00:00.000' AS DateTime), N'dasdasd', NULL, NULL, NULL, N'COMP-1592236762', 0, 5, NULL, NULL, 1586280264, CAST(N'2020-09-17T02:13:06.803' AS DateTime), 0, N'DIR-1586243597', NULL)
GO
INSERT [dbo].[I_Indent] ([IndentId], [IndentType], [ProgramId], [IndentNo], [IndentFrom], [IssueTo], [ItemId], [IndentQuantity], [IndentValidity], [OtherOptions], [Remarks], [IndentStatusId], [IndentStatusDate], [CompositeId], [IsActive], [IsStatus], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-INS-1600276133', NULL, NULL, N'3', N'DIR-1586243597-SHIP-1591697358', N'DIR-1586243597-SHIP-1591677412', N'DIR-1586243597-W-1593891423-W-1', 1, CAST(N'2020-09-01T00:00:00.000' AS DateTime), N'dasdasd', NULL, NULL, NULL, N'COMP-1592236762', 0, 5, NULL, NULL, 1586280264, CAST(N'2020-09-17T02:13:19.143' AS DateTime), 0, N'DIR-1586243597', NULL)
GO
INSERT [dbo].[I_WeaponsInfo] ([WeaponsInfoId], [WeaponsTypeId], [NameOfWeaponsId], [TrackingNo], [WeaponsModel], [RegistrationNo], [ManufactureYear], [FiscalYearId], [OriginCountryId], [ManufactureCountryId], [Purpose], [ProcurementYear], [WarrantyPeriod], [PriceTypeId], [UnitPrice], [Quantity], [QuantityCategoryId], [TotalPrice], [LocalAgentId], [PrincipalAgentId], [ManufactureAgentId], [Image], [DepotId], [ProcurementCatId], [WareHouseId], [BinLocationId], [TechnicalSpec], [Weight], [Dimention], [MaximumRange], [EffectiveRange], [MuzzeleVelocity], [BarrelLife], [OperatingTemp], [StoringTemp], [PreservatingTemp], [StatusId], [DateAfterAcceptance], [WorkOrderNumber], [Remarks], [MissilTypeId], [SerialNumber], [ShelfLifeOfWeapon], [ShelfLifeOfLauncher], [PreparationTimeId], [CombatDuration], [Caliber], [AmmunitationTypeId], [LotNumberId], [ProofFiringStatus], [ProofFiringDate], [Humidity], [IsUse], [IsActive], [IsMaintaince], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [Brand], [LastBackupDate]) VALUES (N'DIR-1586243597-W-1593891423-W-1', N'1042020WEAP137', N'DIR-1586243597-GN-1591706778', N'1', N'DIR-1586243597-MOD-1591706023', N'Reg-1', N'DIR-1586243597-FIS-1591707323', NULL, N'DIR-1586243597-CON-1591723873', NULL, N'War', N'2020', N'12 year', N'14-4-2020PRTP', N'200', CAST(1 AS Decimal(18, 0)), N'DIR-1586243597-QU-1591724612', N'200', N'DIR-1586243597-LA-1591725257', NULL, NULL, N'uploads/DIR-15862435971042020WEAP137DIR-1586243597-GN-1591706778image.jpeg', N'DIR-1586243597-SHIP-1591697358', N'PROD-1591700343', N'DIR-1586243597-WAR-1591698878', N'DIR-1586243597-BIN-1591705722', N'Technical', N'12', N'12', N'12', N'12', N'12', N'12', N'12', N'12', N'12', N'DIR-1586243597-ST-1591724911', CAST(N'2020-07-01T00:00:00.000' AS DateTime), N'worker', N'Remarks', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(N'2020-07-05T01:37:03.813' AS DateTime), NULL, NULL, 0, N'DIR-1586243597', NULL, CAST(N'2020-07-24T01:31:25.613' AS DateTime))
GO
INSERT [dbo].[I_WeaponsInfo] ([WeaponsInfoId], [WeaponsTypeId], [NameOfWeaponsId], [TrackingNo], [WeaponsModel], [RegistrationNo], [ManufactureYear], [FiscalYearId], [OriginCountryId], [ManufactureCountryId], [Purpose], [ProcurementYear], [WarrantyPeriod], [PriceTypeId], [UnitPrice], [Quantity], [QuantityCategoryId], [TotalPrice], [LocalAgentId], [PrincipalAgentId], [ManufactureAgentId], [Image], [DepotId], [ProcurementCatId], [WareHouseId], [BinLocationId], [TechnicalSpec], [Weight], [Dimention], [MaximumRange], [EffectiveRange], [MuzzeleVelocity], [BarrelLife], [OperatingTemp], [StoringTemp], [PreservatingTemp], [StatusId], [DateAfterAcceptance], [WorkOrderNumber], [Remarks], [MissilTypeId], [SerialNumber], [ShelfLifeOfWeapon], [ShelfLifeOfLauncher], [PreparationTimeId], [CombatDuration], [Caliber], [AmmunitationTypeId], [LotNumberId], [ProofFiringStatus], [ProofFiringDate], [Humidity], [IsUse], [IsActive], [IsMaintaince], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [Brand], [LastBackupDate]) VALUES (N'DIR-1586243597-W-1593891858-W-1', N'1042020WEAP139', N'DIR-1586243597-GN-1592234689', N'1', N'DIR-1586243597-MOD-1592234744', N'Lot-1', N'DIR-1586243597-FIS-1591707323', NULL, N'DIR-1586243597-CON-1591723556', N'DIR-1586243597-CON-1591723556', NULL, N'2018', N'12', N'14-4-2020PRTP', N'12', CAST(100 AS Decimal(18, 0)), NULL, N'1200', N'DIR-1586243597-LA-1591725257', NULL, NULL, N'uploads/DIR-15862435971042020WEAP139DIR-1586243597-GN-1592234689image.jpeg', N'DIR-1586243597-SHIP-1591697358', NULL, N'DIR-1586243597-WAR-1591698878', N'DIR-1586243597-BIN-1591705722', N'dasdasd', NULL, NULL, NULL, NULL, NULL, NULL, N'12', N'12', N'12', N'DIR-1586243597-ST-1591724932', NULL, NULL, N'dasd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'12', CAST(N'2020-07-01T00:00:00.000' AS DateTime), N'12', 0, 1, NULL, 2, CAST(N'2020-07-05T01:44:18.283' AS DateTime), NULL, NULL, 0, N'DIR-1586243597', NULL, CAST(N'2020-07-24T01:31:25.613' AS DateTime))
GO
INSERT [dbo].[I_WeaponsInfo] ([WeaponsInfoId], [WeaponsTypeId], [NameOfWeaponsId], [TrackingNo], [WeaponsModel], [RegistrationNo], [ManufactureYear], [FiscalYearId], [OriginCountryId], [ManufactureCountryId], [Purpose], [ProcurementYear], [WarrantyPeriod], [PriceTypeId], [UnitPrice], [Quantity], [QuantityCategoryId], [TotalPrice], [LocalAgentId], [PrincipalAgentId], [ManufactureAgentId], [Image], [DepotId], [ProcurementCatId], [WareHouseId], [BinLocationId], [TechnicalSpec], [Weight], [Dimention], [MaximumRange], [EffectiveRange], [MuzzeleVelocity], [BarrelLife], [OperatingTemp], [StoringTemp], [PreservatingTemp], [StatusId], [DateAfterAcceptance], [WorkOrderNumber], [Remarks], [MissilTypeId], [SerialNumber], [ShelfLifeOfWeapon], [ShelfLifeOfLauncher], [PreparationTimeId], [CombatDuration], [Caliber], [AmmunitationTypeId], [LotNumberId], [ProofFiringStatus], [ProofFiringDate], [Humidity], [IsUse], [IsActive], [IsMaintaince], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [Brand], [LastBackupDate]) VALUES (N'DIR-1586243597-W-1593892064-W-1', N'1042020WEAP139', N'DIR-1586243597-GN-1593891943', N'1', N'DIR-1586243597-MOD-1592234744', N'Lot-2', N'DIR-1586243597-FIS-1591707323', NULL, N'DIR-1586243597-CON-1591723556', N'DIR-1586243597-CON-1591723556', NULL, N'2018', N'12', N'14-4-2020PRTP', N'1', CAST(200 AS Decimal(18, 0)), NULL, N'200', N'DIR-1586243597-LA-1591725257', NULL, NULL, N'uploads/DIR-15862435971042020WEAP139DIR-1586243597-GN-1593891943image.jpeg', N'DIR-1586243597-SHIP-1591697358', NULL, N'DIR-1586243597-WAR-1591698878', N'DIR-1586243597-BIN-1591705722', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'12', N'12', N'12', N'DIR-1586243597-ST-1591724932', NULL, NULL, N'Others', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'12', CAST(N'2020-07-01T00:00:00.000' AS DateTime), N'12', 0, 1, NULL, 2, CAST(N'2020-07-05T01:47:44.147' AS DateTime), NULL, NULL, 0, N'DIR-1586243597', NULL, CAST(N'2020-07-24T01:31:25.613' AS DateTime))
GO
INSERT [dbo].[I_WeaponsInfo] ([WeaponsInfoId], [WeaponsTypeId], [NameOfWeaponsId], [TrackingNo], [WeaponsModel], [RegistrationNo], [ManufactureYear], [FiscalYearId], [OriginCountryId], [ManufactureCountryId], [Purpose], [ProcurementYear], [WarrantyPeriod], [PriceTypeId], [UnitPrice], [Quantity], [QuantityCategoryId], [TotalPrice], [LocalAgentId], [PrincipalAgentId], [ManufactureAgentId], [Image], [DepotId], [ProcurementCatId], [WareHouseId], [BinLocationId], [TechnicalSpec], [Weight], [Dimention], [MaximumRange], [EffectiveRange], [MuzzeleVelocity], [BarrelLife], [OperatingTemp], [StoringTemp], [PreservatingTemp], [StatusId], [DateAfterAcceptance], [WorkOrderNumber], [Remarks], [MissilTypeId], [SerialNumber], [ShelfLifeOfWeapon], [ShelfLifeOfLauncher], [PreparationTimeId], [CombatDuration], [Caliber], [AmmunitationTypeId], [LotNumberId], [ProofFiringStatus], [ProofFiringDate], [Humidity], [IsUse], [IsActive], [IsMaintaince], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [Brand], [LastBackupDate]) VALUES (N'DIR-1586243597-W-1593945032-W-1', N'1042020WEAP140', N'DIR-1586243597-GN-1593944919', N'1', N'DIR-1586243597-MOD-1593944947', N'Reg -3', N'DIR-1586243597-FIS-1591707323', NULL, N'DIR-1586243597-CON-1591723556', N'DIR-1586243597-CON-1591723556', N'dd', N'2018', N'wedasd', NULL, N'120000', CAST(1 AS Decimal(18, 0)), NULL, N'120000', N'DIR-1586243597-LA-1591725257', NULL, NULL, N'uploads/DIR-15862435971042020WEAP140DIR-1586243597-GN-1593944919image.jpeg', N'DIR-1586243597-SHIP-1591697358', NULL, N'DIR-1586243597-WAR-1591698878', N'DIR-1586243597-BIN-1591705779', N'sdasd', NULL, NULL, NULL, NULL, NULL, NULL, N'12', N'12', NULL, N'DIR-1586243597-ST-1591724911', CAST(N'2020-07-06T00:00:00.000' AS DateTime), NULL, N'asdasd', NULL, NULL, N'121', N'121', N'1742020216PMPrepA', N'1213', NULL, NULL, NULL, N'3123', CAST(N'2020-07-08T00:00:00.000' AS DateTime), N'12', 0, 1, NULL, 2, CAST(N'2020-07-05T16:30:32.037' AS DateTime), NULL, NULL, 0, N'DIR-1586243597', NULL, CAST(N'2020-07-24T01:31:25.613' AS DateTime))
GO
INSERT [dbo].[I_WeaponsInfo] ([WeaponsInfoId], [WeaponsTypeId], [NameOfWeaponsId], [TrackingNo], [WeaponsModel], [RegistrationNo], [ManufactureYear], [FiscalYearId], [OriginCountryId], [ManufactureCountryId], [Purpose], [ProcurementYear], [WarrantyPeriod], [PriceTypeId], [UnitPrice], [Quantity], [QuantityCategoryId], [TotalPrice], [LocalAgentId], [PrincipalAgentId], [ManufactureAgentId], [Image], [DepotId], [ProcurementCatId], [WareHouseId], [BinLocationId], [TechnicalSpec], [Weight], [Dimention], [MaximumRange], [EffectiveRange], [MuzzeleVelocity], [BarrelLife], [OperatingTemp], [StoringTemp], [PreservatingTemp], [StatusId], [DateAfterAcceptance], [WorkOrderNumber], [Remarks], [MissilTypeId], [SerialNumber], [ShelfLifeOfWeapon], [ShelfLifeOfLauncher], [PreparationTimeId], [CombatDuration], [Caliber], [AmmunitationTypeId], [LotNumberId], [ProofFiringStatus], [ProofFiringDate], [Humidity], [IsUse], [IsActive], [IsMaintaince], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [Brand], [LastBackupDate]) VALUES (N'DIR-1586243597-W-1599839254-W-2', N'1042020WEAP139', N'DIR-1586243597-GN-1592234689', N'2', N'DIR-1586243597-MOD-1592234744', N'reg2', N'DIR-1586243597-FIS-1591707323', NULL, N'DIR-1586243597-CON-1591723556', N'DIR-1586243597-CON-1591723556', NULL, N'2017', N'eqwe', N'14-4-2020PRTP', N'12', CAST(100 AS Decimal(18, 0)), NULL, N'1200', N'DIR-1586243597-LA-1591725335', NULL, NULL, N'uploads/DIR-15862435971042020WEAP139DIR-1586243597-GN-1592234689http:..placehold.it.180', N'DIR-1586243597-SHIP-1591697358', NULL, N'DIR-1586243597-WAR-1591698878', N'DIR-1586243597-BIN-1591705722', N'dasd', NULL, NULL, NULL, NULL, NULL, NULL, N'sda', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(N'2020-09-11T21:47:34.843' AS DateTime), NULL, NULL, 0, N'DIR-1586243597', NULL, NULL)
GO
INSERT [dbo].[I_WeaponsInfo] ([WeaponsInfoId], [WeaponsTypeId], [NameOfWeaponsId], [TrackingNo], [WeaponsModel], [RegistrationNo], [ManufactureYear], [FiscalYearId], [OriginCountryId], [ManufactureCountryId], [Purpose], [ProcurementYear], [WarrantyPeriod], [PriceTypeId], [UnitPrice], [Quantity], [QuantityCategoryId], [TotalPrice], [LocalAgentId], [PrincipalAgentId], [ManufactureAgentId], [Image], [DepotId], [ProcurementCatId], [WareHouseId], [BinLocationId], [TechnicalSpec], [Weight], [Dimention], [MaximumRange], [EffectiveRange], [MuzzeleVelocity], [BarrelLife], [OperatingTemp], [StoringTemp], [PreservatingTemp], [StatusId], [DateAfterAcceptance], [WorkOrderNumber], [Remarks], [MissilTypeId], [SerialNumber], [ShelfLifeOfWeapon], [ShelfLifeOfLauncher], [PreparationTimeId], [CombatDuration], [Caliber], [AmmunitationTypeId], [LotNumberId], [ProofFiringStatus], [ProofFiringDate], [Humidity], [IsUse], [IsActive], [IsMaintaince], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [Brand], [LastBackupDate]) VALUES (N'DIR-1586243597-W-1600021010-W-3', N'1042020WEAP137', N'DIR-1586243597-GN-1591706778', N'3', N'DIR-1586243597-MOD-1591706023', N'reg120', N'DIR-1586243597-FIS-1591707323', NULL, N'DIR-1586243597-CON-1591723556', NULL, NULL, NULL, NULL, NULL, NULL, CAST(1 AS Decimal(18, 0)), NULL, NULL, NULL, NULL, NULL, N'uploads/DIR-15862435971042020WEAP137DIR-1586243597-GN-1591706778http:..placehold.it.180', N'DIR-1586243597-SHIP-1591697358', N'PROD-1591700343', N'DIR-1586243597-WAR-1591698878', N'DIR-1586243597-BIN-1591705722', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DIR-1586243597-ST-1591724911', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, 1586280264, CAST(N'2020-09-14T00:16:50.437' AS DateTime), NULL, NULL, 0, N'DIR-1586243597', NULL, NULL)
GO
INSERT [dbo].[I_WeaponsInfo] ([WeaponsInfoId], [WeaponsTypeId], [NameOfWeaponsId], [TrackingNo], [WeaponsModel], [RegistrationNo], [ManufactureYear], [FiscalYearId], [OriginCountryId], [ManufactureCountryId], [Purpose], [ProcurementYear], [WarrantyPeriod], [PriceTypeId], [UnitPrice], [Quantity], [QuantityCategoryId], [TotalPrice], [LocalAgentId], [PrincipalAgentId], [ManufactureAgentId], [Image], [DepotId], [ProcurementCatId], [WareHouseId], [BinLocationId], [TechnicalSpec], [Weight], [Dimention], [MaximumRange], [EffectiveRange], [MuzzeleVelocity], [BarrelLife], [OperatingTemp], [StoringTemp], [PreservatingTemp], [StatusId], [DateAfterAcceptance], [WorkOrderNumber], [Remarks], [MissilTypeId], [SerialNumber], [ShelfLifeOfWeapon], [ShelfLifeOfLauncher], [PreparationTimeId], [CombatDuration], [Caliber], [AmmunitationTypeId], [LotNumberId], [ProofFiringStatus], [ProofFiringDate], [Humidity], [IsUse], [IsActive], [IsMaintaince], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [Brand], [LastBackupDate]) VALUES (N'DIR-1586243597-W-1600021390-W-3', N'1042020WEAP139', N'DIR-1586243597-GN-1592234689', N'3', N'DIR-1586243597-MOD-1592234744', N'lot-2329', N'', NULL, N'DIR-1586243597-CON-1591723556', NULL, NULL, NULL, NULL, NULL, NULL, CAST(1 AS Decimal(18, 0)), NULL, NULL, NULL, NULL, NULL, N'uploads/DIR-15862435971042020WEAP139DIR-1586243597-GN-1592234689http:..placehold.it.180', N'DIR-1586243597-SHIP-1591697358', NULL, N'DIR-1586243597-WAR-1591698878', N'DIR-1586243597-BIN-1591705722', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DIR-1586243597-ST-1591724932', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, 1586280264, CAST(N'2020-09-14T00:23:10.570' AS DateTime), NULL, NULL, 0, N'DIR-1586243597', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[I_WeaponsInfotracking] ON 
GO
INSERT [dbo].[I_WeaponsInfotracking] ([WeaponTracking], [WeaponId], [DepotId], [ProcQuantity]) VALUES (2, N'DIR-1586243597-W-1600021390-W-3', N'DIR-1586243597-SHIP-1591697358', 1)
GO
SET IDENTITY_INSERT [dbo].[I_WeaponsInfotracking] OFF
GO
INSERT [dbo].[M_Agent] ([LocalAgentId], [Code], [SupplierName], [Address], [EnlistmintType], [Email], [ContractNumber], [Country], [AgentTypeId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-LA-1591725257', N'LA-17ZZH', N'Infinity Technology International Ltd', N'Mirpur Dhaka', N'1041202EST', N'Infinitytechltd.com', N'2678098765', N'DIR-1586243597-CON-1591723556', N'0942020944Ag', 1, 2, CAST(N'2020-06-09T23:54:17.457' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.167' AS DateTime))
GO
INSERT [dbo].[M_Agent] ([LocalAgentId], [Code], [SupplierName], [Address], [EnlistmintType], [Email], [ContractNumber], [Country], [AgentTypeId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-LA-1591725335', N'LA-35CPO', N'LS Comunications', N'dhaka', N'1041202EST', N'sdfghfh', N'1234567890', N'DIR-1586243597-CON-1591723556', N'0942020944Ag', 1, 2, CAST(N'2020-06-09T23:55:35.563' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.167' AS DateTime))
GO
INSERT [dbo].[M_AgentEnlistment] ([EnlistmentTypeId], [EnlistmentType], [IsActive]) VALUES (N'1041202EST', N'Yes', 1)
GO
INSERT [dbo].[M_AgentEnlistment] ([EnlistmentTypeId], [EnlistmentType], [IsActive]) VALUES (N'1041203EST', N'No', 1)
GO
INSERT [dbo].[M_AgentType] ([AgentTypeId], [AgentType], [IsActive]) VALUES (N'0942020944Ag', N'Local', 1)
GO
INSERT [dbo].[M_AgentType] ([AgentTypeId], [AgentType], [IsActive]) VALUES (N'0942020945Ag', N'Principal', 1)
GO
INSERT [dbo].[M_AgentType] ([AgentTypeId], [AgentType], [IsActive]) VALUES (N'0942020946Ag', N'Manufacture', 1)
GO
SET IDENTITY_INSERT [dbo].[M_Area] ON 
GO
INSERT [dbo].[M_Area] ([AreaId], [AreaName], [IsActive]) VALUES (1, N'Dhaka', 1)
GO
INSERT [dbo].[M_Area] ([AreaId], [AreaName], [IsActive]) VALUES (2, N'CTG', 1)
GO
INSERT [dbo].[M_Area] ([AreaId], [AreaName], [IsActive]) VALUES (3, N'Khulna', 1)
GO
SET IDENTITY_INSERT [dbo].[M_Area] OFF
GO
INSERT [dbo].[M_Authorirty] ([AuthorityId], [AuthorityCode], [AuthorityName], [AreaId], [Contract], [Email], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-AUT-1591671461', N'AUT-41UZA', N'Comban1', 1, N'Contract', N'email', 1, 2, CAST(N'2020-06-09T08:57:41.060' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.170' AS DateTime))
GO
INSERT [dbo].[M_Authorirty] ([AuthorityId], [AuthorityCode], [AuthorityName], [AreaId], [Contract], [Email], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-AUT-1591674809', N'AUT-29XRL', N'Comkul', 3, N'test', N'test', 1, 2, CAST(N'2020-06-09T09:53:29.357' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.170' AS DateTime))
GO
INSERT [dbo].[M_Authorirty] ([AuthorityId], [AuthorityCode], [AuthorityName], [AreaId], [Contract], [Email], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-AUT-1591675040', N'AUT-20GML', N'comdhit', 2, N'test', N'test', 1, 2, CAST(N'2020-06-09T09:57:20.757' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.170' AS DateTime))
GO
INSERT [dbo].[M_Authorirty] ([AuthorityId], [AuthorityCode], [AuthorityName], [AreaId], [Contract], [Email], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-AUT-1591675196', N'AUT-56SSN', N'Admin Dhaka', 1, N'test', N'test', 1, 2, CAST(N'2020-06-09T09:59:56.117' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.170' AS DateTime))
GO
INSERT [dbo].[M_CapabilityOfWeapons] ([CapabilityOfWeaponsID], [CapabilityCode], [CapabilityName], [Telephone], [Email], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-CAP-1591696209', N'CAP-9RBQ', N'store', N'34567', N'fghjkfyfty', 1, 2, CAST(N'2020-09-06T00:00:00.000' AS DateTime), 2, CAST(N'2020-06-14T03:35:46.610' AS DateTime), 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.173' AS DateTime))
GO
INSERT [dbo].[M_Composite] ([CompositeId], [CompositeCode], [CompositeName], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'COMP-1592236762', N'C-1', N'Composite One', 1, 2, CAST(N'2020-06-15T21:59:22.817' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.177' AS DateTime))
GO
INSERT [dbo].[M_Country] ([CountryNameId], [CountryCode], [CountryName], [ShortName], [DollerType], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-CON-1591723556', N'CON-56CGM', N'Bangladesh', N'BD', N'Taka', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:25:56.707' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.190' AS DateTime))
GO
INSERT [dbo].[M_Country] ([CountryNameId], [CountryCode], [CountryName], [ShortName], [DollerType], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-CON-1591723820', N'CON-20SUY', N'India', N'India', N'Rupi', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:30:20.083' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.190' AS DateTime))
GO
INSERT [dbo].[M_Country] ([CountryNameId], [CountryCode], [CountryName], [ShortName], [DollerType], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-CON-1591723873', N'CON-13QHH', N'Canada', N'canada', N'Dollar', CAST(N'2020-02-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:31:13.573' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.190' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[M_DepotShipCategory] ON 
GO
INSERT [dbo].[M_DepotShipCategory] ([CategoryId], [CategoryName], [IsActive]) VALUES (1, N'Office', 1)
GO
INSERT [dbo].[M_DepotShipCategory] ([CategoryId], [CategoryName], [IsActive]) VALUES (2, N'Ship', 1)
GO
INSERT [dbo].[M_DepotShipCategory] ([CategoryId], [CategoryName], [IsActive]) VALUES (3, N'Other', 1)
GO
SET IDENTITY_INSERT [dbo].[M_DepotShipCategory] OFF
GO
INSERT [dbo].[M_FiscalYear] ([FiscalYearId], [FiscalYearCode], [Name], [ShortName], [StartDate], [EndDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-FIS-1591707323', N'FIS-23TSY', N'2017-2018', N'2017-2018', CAST(N'2017-07-01T00:00:00.000' AS DateTime), CAST(N'2020-03-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-09-06T00:00:00.000' AS DateTime), 2, CAST(N'2020-07-26T17:23:14.940' AS DateTime), 0, N'DIR-1586243597', NULL)
GO
INSERT [dbo].[M_FiscalYear] ([FiscalYearId], [FiscalYearCode], [Name], [ShortName], [StartDate], [EndDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-FIS-1592083749', N'FIS-9DGC', N'2018-2019', N'18-19', CAST(N'2020-06-01T00:00:00.000' AS DateTime), CAST(N'2020-06-18T00:00:00.000' AS DateTime), 1, 2, NULL, 2, CAST(N'2020-06-14T19:40:03.507' AS DateTime), 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.193' AS DateTime))
GO
INSERT [dbo].[M_IndentStatus] ([IndentStatusId], [IndentStatus], [IsActive]) VALUES (N'862020INst1136', N'Processing', 0)
GO
INSERT [dbo].[M_IndentStatus] ([IndentStatusId], [IndentStatus], [IsActive]) VALUES (N'862020INst1137', N'Cancel', 1)
GO
INSERT [dbo].[M_IndentStatus] ([IndentStatusId], [IndentStatus], [IsActive]) VALUES (N'862020INst1138', N'Change', 1)
GO
INSERT [dbo].[M_IndentStatus] ([IndentStatusId], [IndentStatus], [IsActive]) VALUES (N'862020INst1139', N'Performed', 1)
GO
INSERT [dbo].[M_IndentType] ([IndentTypeId], [IndentTypeName], [IsActive]) VALUES (N'INDE862020141', N'Issue', 1)
GO
INSERT [dbo].[M_IndentType] ([IndentTypeId], [IndentTypeName], [IsActive]) VALUES (N'INDE862020142', N'Received', 1)
GO
INSERT [dbo].[M_MaintainceStatus(c)] ([MaintainceStatusId], [Status], [IsActive]) VALUES (N'STS-2842020-437-1', N'Serviceable', 1)
GO
INSERT [dbo].[M_MaintainceStatus(c)] ([MaintainceStatusId], [Status], [IsActive]) VALUES (N'STS-2842020-437-2', N'Un Serviceable', 1)
GO
INSERT [dbo].[M_MaintainceStatus(c)] ([MaintainceStatusId], [Status], [IsActive]) VALUES (N'STS-2842020-437-3', N'Damage', 1)
GO
INSERT [dbo].[M_MaintainceType] ([MaintainceId], [MaintainceType], [IsActive]) VALUES (N'2342020544', N'Monthly', 1)
GO
INSERT [dbo].[M_MaintainceType] ([MaintainceId], [MaintainceType], [IsActive]) VALUES (N'2342020545', N'Quarterly', 1)
GO
INSERT [dbo].[M_MaintainceType] ([MaintainceId], [MaintainceType], [IsActive]) VALUES (N'2342020546', N'Half yearly ', 1)
GO
INSERT [dbo].[M_MaintainceType] ([MaintainceId], [MaintainceType], [IsActive]) VALUES (N'2342020547', N'Yearly', 1)
GO
SET IDENTITY_INSERT [dbo].[M_Menu] ON 
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (33, 0, NULL, N'User Management ', N'icon-user', NULL, NULL, 1, 33, NULL, NULL, 1, CAST(N'2020-04-02T14:33:56.017' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (1034, 33, NULL, N'Menu Setup', NULL, NULL, N'Menu', 1, 33, NULL, NULL, 1, CAST(N'2020-03-24T02:11:48.287' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (1035, 33, NULL, N'User Privileges', NULL, NULL, N'UserPrivileges', 1, 33, 3, CAST(N'2018-07-16T13:34:00.507' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (1100, 0, NULL, N'Basic Setup', N'icon-settings', NULL, NULL, 1, 1100, NULL, NULL, 1, CAST(N'2020-05-11T12:22:39.207' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (1125, 33, NULL, N'User Setup', NULL, NULL, N'User', 1, 33, 2, CAST(N'2019-09-09T16:32:04.363' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6183, 33, NULL, N'Role Setup', NULL, NULL, N'RoleSetup', 1, 33, 2, CAST(N'2020-03-27T22:08:34.500' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6184, 1100, NULL, N'Fiscal Year Setup', NULL, NULL, N'FiscalYearSetup', 1, 1100, 2, CAST(N'2020-03-29T00:51:33.460' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6185, 6196, NULL, N'Admin Authority Information', NULL, NULL, N'AuthoritySetup', 1, 6196, NULL, NULL, 1, CAST(N'2020-06-09T10:05:49.970' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6186, 1100, NULL, N'Capability Of Weapons ', NULL, NULL, N'CapabilityOfWeapons', 1, 1100, 2, CAST(N'2020-03-30T17:51:33.110' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6187, 1100, NULL, N'Gun Model / Mark/ Type', NULL, NULL, N'GunModelType', 1, 1100, NULL, NULL, 1, CAST(N'2020-06-09T18:37:49.990' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6188, 1100, NULL, N'Name of Gun/ Ammunition/ web equipment', NULL, NULL, N'NameOfGun', 1, 1100, NULL, NULL, 1, CAST(N'2020-06-09T18:38:56.053' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6189, 1100, NULL, N'Country Setup', NULL, NULL, N'CountrySetup', 1, 1100, 2, CAST(N'2020-03-31T04:01:09.797' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6190, 1100, NULL, N'Agent/Supplier Setup', NULL, NULL, N'LocalAgentSetup', 1, 1100, NULL, NULL, 1, CAST(N'2020-04-10T00:14:46.053' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6191, 1100, NULL, N'Procurement Category Setup', NULL, NULL, N'ProcurementCategorySetup', 1, 1100, 2, CAST(N'2020-03-31T21:08:36.207' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6192, 1100, NULL, N'Quantity Setup', NULL, NULL, N'QuantitySetup', 1, 1100, 2, CAST(N'2020-03-31T21:51:59.803' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6195, 1100, NULL, N'Status Information Setup', NULL, NULL, N'StatusInformation', 1, 1100, 2, CAST(N'2020-04-01T05:32:47.347' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6196, 0, NULL, N'Organization Setup', N'glyphicon glyphicon-briefcase', NULL, NULL, 1, 6196, NULL, NULL, 1, CAST(N'2020-04-02T14:37:34.353' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6197, 0, NULL, N' Warehouse Management', N'glyphicon glyphicon-shopping-cart', NULL, NULL, 1, 6197, NULL, NULL, 1, CAST(N'2020-05-11T12:19:37.933' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6198, 6196, NULL, N'Directorate information', NULL, NULL, N'DirectorateInfo', 1, 6196, NULL, NULL, 1, CAST(N'2020-06-09T10:04:59.767' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6199, 6196, NULL, N'Ship Or Depot Information', NULL, NULL, N'ShipDepotInfo', 1, 6196, NULL, NULL, 1, CAST(N'2020-06-09T16:13:31.207' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6200, 6197, NULL, N'Warehouse Information', NULL, NULL, N'WarHouseInfo', 1, 6197, 2, CAST(N'2020-04-05T06:12:48.850' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6201, 6197, NULL, N'Bin Location Information', NULL, NULL, N'BinLocation', 1, 6197, NULL, NULL, 1, CAST(N'2020-06-09T16:47:54.137' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6202, 0, NULL, N'Inventory Management', N'glyphicon glyphicon-screenshot', NULL, NULL, 1, 6202, NULL, NULL, 1, CAST(N'2020-05-11T12:20:13.073' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6203, 6202, NULL, N'Gun/Ammunition Entry', NULL, NULL, N'WeaponsEntry', 1, 6202, NULL, NULL, 1, CAST(N'2020-06-09T18:53:17.733' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6204, 6202, NULL, N'Gun/Ammo Maintaince', NULL, NULL, N'GunAmmoMaintaince', 1, 6202, 2, CAST(N'2020-04-21T11:50:28.880' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6205, 6202, NULL, N'Status After Maintaince', NULL, NULL, N'StatusAfterMaintaince', 1, 6202, 2, CAST(N'2020-04-28T18:12:48.827' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6206, 0, NULL, N'Training Management', N'icon-star', NULL, NULL, 1, 6206, NULL, NULL, 1, CAST(N'2020-05-11T12:20:47.690' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6207, 6206, NULL, N'Trainee Person Bio Setup', NULL, NULL, N'TraineePersonBioSetup', 1, 6206, 2, CAST(N'2020-04-29T18:21:30.287' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6208, 6206, NULL, N'Training Info Add', NULL, NULL, N'TrainingInfo', 1, 6206, 2, CAST(N'2020-04-30T00:35:12.487' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6209, 6202, NULL, N'Inspaction', NULL, NULL, N'Inspaction', 1, 6202, 2, CAST(N'2020-05-03T22:02:42.573' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6210, 0, NULL, N'Procuremnet Management', N'glyphicon glyphicon-random', NULL, NULL, 1, 6210, NULL, NULL, 1, CAST(N'2020-05-11T12:24:50.440' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6211, 6210, NULL, N' Issue Item', NULL, NULL, N'Indent', 1, 6210, NULL, NULL, 1, CAST(N'2020-06-07T21:30:56.653' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6212, 6210, NULL, N' Cancel/Performed Indent ', NULL, NULL, N'IndentReceivedOrCancel', 1, 6210, 2, CAST(N'2020-05-19T08:25:12.723' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6213, 0, NULL, N'Reporting', N'glyphicon glyphicon-print', NULL, NULL, 1, 6213, 2, CAST(N'2020-05-19T08:31:22.203' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6214, 1100, NULL, N'Product Category', NULL, NULL, N'ProductCategory', 1, 1100, 2, CAST(N'2020-05-29T17:00:50.600' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6215, 1100, NULL, N'Cmposite Code Setup', NULL, NULL, N'CompositeCodeMaster', 1, 1100, 2, CAST(N'2020-06-01T22:26:55.327' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6216, 6210, NULL, N'Received Indent', NULL, NULL, N'IndentAccept', 1, 6210, 2, CAST(N'2020-06-27T20:48:16.067' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6217, 6202, NULL, N'Set For Maintaince', NULL, NULL, N'SetGunAmmoMaintaince', 1, 6202, NULL, NULL, 1, CAST(N'2020-06-29T02:04:04.443' AS DateTime))
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (6218, 33, NULL, N'Backup', NULL, NULL, N'BackupPlan', 1, 33, 2, CAST(N'2020-07-02T01:01:41.020' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (7218, 33, NULL, N'Restore Data', NULL, NULL, N'RestorePlan', 1, 33, 2, CAST(N'2020-07-03T18:40:57.880' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (7219, 6210, NULL, N'Indent History', NULL, NULL, N'IndentHistory', 1, 6210, 2, CAST(N'2020-09-11T13:24:08.273' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[M_Menu] ([Id], [ParentId], [SubParentId], [MenuName], [MenuClass], [MenuId], [MenuUrl], [IsActive], [SortingOrderHelper], [SetUpUserId], [SetUpDateTime], [UpdateUserId], [UpdateDateTime]) VALUES (7221, 6210, NULL, N'Indent Return', NULL, NULL, N'IndentReturn', 1, 6210, NULL, NULL, 1, CAST(N'2020-09-14T12:09:05.143' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[M_Menu] OFF
GO
INSERT [dbo].[M_MissilePrepType] ([MissilePrepTimeId], [MissilePrepTime], [IsActive]) VALUES (N'1742020216PMPrep', N'Peace', 1)
GO
INSERT [dbo].[M_MissilePrepType] ([MissilePrepTimeId], [MissilePrepTime], [IsActive]) VALUES (N'1742020216PMPrepA', N'War', 1)
GO
INSERT [dbo].[M_NameOfWeapon] ([NameOfGunId], [NameOfGunCode], [WeaponsTypeId], [NameOfGun], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-GN-1591706778', N'GN-18ACL', N'1042020WEAP137', N'12/12 caliber', N'12/12 caliber', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T18:46:18.720' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.197' AS DateTime))
GO
INSERT [dbo].[M_NameOfWeapon] ([NameOfGunId], [NameOfGunCode], [WeaponsTypeId], [NameOfGun], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-GN-1591706801', N'GN-41CFQ', N'1042020WEAP137', N'12/15 caliber', N'12/15 caliber', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T18:46:41.057' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.197' AS DateTime))
GO
INSERT [dbo].[M_NameOfWeapon] ([NameOfGunId], [NameOfGunCode], [WeaponsTypeId], [NameOfGun], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-GN-1592234689', N'GN-49TXH', N'1042020WEAP139', N'7.62*49 NATO', N'Nato7.62', CAST(N'2020-06-01T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-15T21:24:49.197' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.197' AS DateTime))
GO
INSERT [dbo].[M_NameOfWeapon] ([NameOfGunId], [NameOfGunCode], [WeaponsTypeId], [NameOfGun], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-GN-1593891943', N'GN-43TAB', N'1042020WEAP139', N'5.56*39', N'NATO Bullet', CAST(N'2020-07-01T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-07-05T01:45:43.943' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-24T01:31:25.670' AS DateTime))
GO
INSERT [dbo].[M_NameOfWeapon] ([NameOfGunId], [NameOfGunCode], [WeaponsTypeId], [NameOfGun], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-GN-1593944919', N'GN-39IGQ', N'1042020WEAP140', N'XASM-3', N'Project x', CAST(N'2020-07-05T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-07-05T16:28:39.763' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-24T01:31:25.670' AS DateTime))
GO
INSERT [dbo].[M_PriceType] ([PriceTypeId], [PriceType], [IsActive]) VALUES (N'14-4-2020PRTP', N'Doller', 1)
GO
INSERT [dbo].[M_PriceType] ([PriceTypeId], [PriceType], [IsActive]) VALUES (N'15-4-2020PRTP', N'Taka', 1)
GO
INSERT [dbo].[M_ProcurementCategory] ([ProcurementId], [ProcurementCode], [ProcurementName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-PRO-1591723938', N'PRO-18KAH', N'Tender', CAST(N'2020-06-01T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-09-06T00:00:00.000' AS DateTime), 2, CAST(N'2020-06-09T23:32:35.733' AS DateTime), 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.200' AS DateTime))
GO
INSERT [dbo].[M_ProcurementCategory] ([ProcurementId], [ProcurementCode], [ProcurementName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-PRO-1591723973', N'PRO-53BEF', N'Certification', CAST(N'2020-02-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:32:53.950' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.200' AS DateTime))
GO
INSERT [dbo].[M_ProcurementCategory] ([ProcurementId], [ProcurementCode], [ProcurementName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-PRO-1591723994', N'PRO-14BXA', N'Paper Transaction', CAST(N'2020-04-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:33:14.687' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.200' AS DateTime))
GO
INSERT [dbo].[M_ProductCategory] ([ProductCategoryId], [ProductCtegoryName], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'PROD-1591700343', N'12/12', 1, 2, CAST(N'2020-06-09T16:59:03.943' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.203' AS DateTime))
GO
INSERT [dbo].[M_ProductCategory] ([ProductCategoryId], [ProductCtegoryName], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'PROD-1591700364', N'12/13', 1, 2, CAST(N'2020-06-09T16:59:24.920' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.203' AS DateTime))
GO
INSERT [dbo].[M_QuantityCategory] ([QuantityId], [QuantityCode], [QuantityName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-QU-1591724509', N'QU-49AYY', N'KG', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:41:49.487' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.207' AS DateTime))
GO
INSERT [dbo].[M_QuantityCategory] ([QuantityId], [QuantityCode], [QuantityName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-QU-1591724564', N'QU-44RQW', N'Gram', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:42:44.717' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.207' AS DateTime))
GO
INSERT [dbo].[M_QuantityCategory] ([QuantityId], [QuantityCode], [QuantityName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-QU-1591724579', N'QU-59TFH', N'Pound', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:42:59.597' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.207' AS DateTime))
GO
INSERT [dbo].[M_QuantityCategory] ([QuantityId], [QuantityCode], [QuantityName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-QU-1591724612', N'QU-32IHR', N'Unit', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:43:32.327' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.207' AS DateTime))
GO
INSERT [dbo].[M_QuantityCategory] ([QuantityId], [QuantityCode], [QuantityName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-QU-1591724627', N'QU-47UBL', N'Dorjon', CAST(N'2020-02-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:43:47.267' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.207' AS DateTime))
GO
INSERT [dbo].[M_QuantityCategory] ([QuantityId], [QuantityCode], [QuantityName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-QU-1591724653', N'QU-13JUY', N'Pis', CAST(N'2020-03-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:44:13.570' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.207' AS DateTime))
GO
INSERT [dbo].[M_RankSetup] ([RankSetupId], [RankName], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'29apr2020803', N'Rank1', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[M_RankSetup] ([RankSetupId], [RankName], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'29apr2020804', N'Rank2', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[M_StatusInformation] ([StatusId], [StatusCode], [StatusName], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-ST-1591724911', N'ST-31CIX', N'Serviceable', N'Serviceable', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:48:31.887' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.217' AS DateTime))
GO
INSERT [dbo].[M_StatusInformation] ([StatusId], [StatusCode], [StatusName], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-ST-1591724932', N'ST-52PYN', N'Un Serviceable', N'US', CAST(N'2020-02-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:48:52.927' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.217' AS DateTime))
GO
INSERT [dbo].[M_StatusInformation] ([StatusId], [StatusCode], [StatusName], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-ST-1591724952', N'ST-12ZEM', N' Defect', N' Defect', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:49:12.530' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.217' AS DateTime))
GO
INSERT [dbo].[M_StatusInformation] ([StatusId], [StatusCode], [StatusName], [ShortName], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-ST-1591724994', N'ST-54CKO', N' Other', N' Other', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T23:49:54.760' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.217' AS DateTime))
GO
INSERT [dbo].[M_TraningOrg] ([TraningOrgId], [OrgName], [IsActive]) VALUES (N'29-4-2020-827-1', N'Army', 1)
GO
INSERT [dbo].[M_TraningOrg] ([TraningOrgId], [OrgName], [IsActive]) VALUES (N'29-4-2020-827-2', N'Navy', 1)
GO
INSERT [dbo].[M_TraningOrg] ([TraningOrgId], [OrgName], [IsActive]) VALUES (N'29-4-2020-827-3', N'Air Force', 1)
GO
SET IDENTITY_INSERT [dbo].[M_TypeOfShip] ON 
GO
INSERT [dbo].[M_TypeOfShip] ([ShipTypeId], [TypeName], [IsActive]) VALUES (1, N'CO', 1)
GO
INSERT [dbo].[M_TypeOfShip] ([ShipTypeId], [TypeName], [IsActive]) VALUES (2, N'EXO', 1)
GO
INSERT [dbo].[M_TypeOfShip] ([ShipTypeId], [TypeName], [IsActive]) VALUES (3, N'GO', 1)
GO
SET IDENTITY_INSERT [dbo].[M_TypeOfShip] OFF
GO
INSERT [dbo].[M_WareHouseType] ([WareHouseTypeId], [WarHouseType], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (N'1', N' S=Store', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[M_WareHouseType] ([WareHouseTypeId], [WarHouseType], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (N'2', N'W=Warehouse', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[M_WareHouseType] ([WareHouseTypeId], [WarHouseType], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (N'3', N'R=Repair', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[M_WeaponsModelType] ([GunModelId], [GunModelCode], [GunModelName], [ShortName], [WeaponsTypeId], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-MOD-1591706023', N'MOD-43WXO', N'Small', N'small', N'1042020WEAP137', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T18:33:43.203' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.220' AS DateTime))
GO
INSERT [dbo].[M_WeaponsModelType] ([GunModelId], [GunModelCode], [GunModelName], [ShortName], [WeaponsTypeId], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-MOD-1591706041', N'MOD-1FYW', N'Big', N'Big', N'1042020WEAP137', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T18:34:01.857' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.220' AS DateTime))
GO
INSERT [dbo].[M_WeaponsModelType] ([GunModelId], [GunModelCode], [GunModelName], [ShortName], [WeaponsTypeId], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-MOD-1591706072', N'MOD-32BBK', N'Large', N'Large', N'1042020WEAP137', CAST(N'2020-01-06T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-09T18:34:32.067' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.220' AS DateTime))
GO
INSERT [dbo].[M_WeaponsModelType] ([GunModelId], [GunModelCode], [GunModelName], [ShortName], [WeaponsTypeId], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-MOD-1592234744', N'MOD-44FBK', N'7.62 Assult', N'Assult NATO Standard', N'1042020WEAP139', CAST(N'2020-06-01T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-06-15T21:25:44.607' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.220' AS DateTime))
GO
INSERT [dbo].[M_WeaponsModelType] ([GunModelId], [GunModelCode], [GunModelName], [ShortName], [WeaponsTypeId], [CreateDate], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-MOD-1593944947', N'MOD-7LXB', N'Anti Ship', N'Ship Killer', N'1042020WEAP140', CAST(N'2020-07-05T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-07-05T16:29:07.020' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-24T01:31:25.777' AS DateTime))
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP137', N'Gun', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP138', N'Spare Parts', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP139', N'Ammunition', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP140', N'Missile ', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP141', N'Torpedo', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP142', N'Mine', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP143', N'RDC', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP144', N'LDC', 1)
GO
INSERT [dbo].[M_WeaponsType] ([WeaponsTypeId], [WeaponsType], [IsActive]) VALUES (N'1042020WEAP145', N' Web Equipment ', 1)
GO
INSERT [dbo].[O_DirectorateInfo] ([DirectorateID], [AdminAuthorityId], [DirectorateCode], [DirectorateName], [Address], [TelephoneNumber], [FaxNumber], [WebAddress], [Logo], [AreaId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [LastBackupDate]) VALUES (N'DIR-1586243597', N'DIR-1586243597-AUT-1591675196', N'DIR-22DFQ', N'DNAI&S', N'Navy Headquarter', N'1234567', N'1234567', N'2345678', N'uploads/DNAI&Simage.jpeg', 1, 1, 2, CAST(N'2020-09-06T00:00:00.000' AS DateTime), 2, CAST(N'2020-06-09T10:02:08.590' AS DateTime), 1, CAST(N'2020-07-03T22:34:36.333' AS DateTime))
GO
INSERT [dbo].[O_DirectorateInfo] ([DirectorateID], [AdminAuthorityId], [DirectorateCode], [DirectorateName], [Address], [TelephoneNumber], [FaxNumber], [WebAddress], [Logo], [AreaId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [LastBackupDate]) VALUES (N'DIR-1591677165', N'DIR-1586243597-AUT-1591675040', N'DIR-45STS', N'BNS ULKA', N'Chittagong', NULL, NULL, NULL, N'uploads/BNS ULKAhttp:..placehold.it.180', 2, 1, 2, CAST(N'2020-06-09T00:00:00.000' AS DateTime), 2, CAST(N'2020-06-09T10:33:11.117' AS DateTime), 1, CAST(N'2020-07-03T22:34:36.333' AS DateTime))
GO
INSERT [dbo].[O_DirectorateInfo] ([DirectorateID], [AdminAuthorityId], [DirectorateCode], [DirectorateName], [Address], [TelephoneNumber], [FaxNumber], [WebAddress], [Logo], [AreaId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [LastBackupDate]) VALUES (N'DIR-1591677267', N'DIR-1586243597-AUT-1591675040', N'DIR-27ZNO', N'BNS BATHIYARI', N'Potenga', NULL, NULL, NULL, N'uploads/BNS BATHIYARIhttp:..placehold.it.180', 2, 1, 2, CAST(N'2020-06-09T10:34:27.810' AS DateTime), NULL, NULL, 1, CAST(N'2020-07-03T22:34:36.333' AS DateTime))
GO
INSERT [dbo].[O_DirectorateInfo] ([DirectorateID], [AdminAuthorityId], [DirectorateCode], [DirectorateName], [Address], [TelephoneNumber], [FaxNumber], [WebAddress], [Logo], [AreaId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [LastBackupDate]) VALUES (N'DIR-1591677295', N'DIR-1586243597-AUT-1591675040', N'DIR-55MZD', N'NASD', N'Issakhan', NULL, NULL, NULL, N'uploads/NASDhttp:..placehold.it.180', 2, 1, 2, CAST(N'2020-06-09T10:34:55.587' AS DateTime), NULL, NULL, 1, CAST(N'2020-07-03T22:34:36.333' AS DateTime))
GO
INSERT [dbo].[O_ShipOrDepotInfo] ([ShipOrDepotId], [ShipOrDepotCode], [DirectorateId], [ShipDepotCategory], [ShipDepotName], [DateOfCommmisson], [WTCallSign], [CapabilityOfWeaponsId], [TypeOfShip], [Telephone], [Email], [FaxNo], [WebAddress], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-SHIP-1591677412', N'SHIP-52XJH', N'DIR-1586243597', 1, N'NASD_Store', CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'f30', N'DIR-1586243597-CAP-1591696209', 1, N'23456', N'sdghk', N'dfgh', N'dfghgfjg', 1, 2, CAST(N'2020-06-09T10:36:52.727' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.227' AS DateTime))
GO
INSERT [dbo].[O_ShipOrDepotInfo] ([ShipOrDepotId], [ShipOrDepotCode], [DirectorateId], [ShipDepotCategory], [ShipDepotName], [DateOfCommmisson], [WTCallSign], [CapabilityOfWeaponsId], [TypeOfShip], [Telephone], [Email], [FaxNo], [WebAddress], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-SHIP-1591696151', N'SHIP-11EYY', N'DIR-1586243597', 1, N'DNAI&S_Store', CAST(N'2020-02-06T00:00:00.000' AS DateTime), N'f60', N'DIR-1586243597-CAP-1591696209', 1, N'12345678', N'sdfgh', N'ghjk', N'sdfgh', 1, 2, CAST(N'2020-06-09T15:49:11.673' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.227' AS DateTime))
GO
INSERT [dbo].[O_ShipOrDepotInfo] ([ShipOrDepotId], [ShipOrDepotCode], [DirectorateId], [ShipDepotCategory], [ShipDepotName], [DateOfCommmisson], [WTCallSign], [CapabilityOfWeaponsId], [TypeOfShip], [Telephone], [Email], [FaxNo], [WebAddress], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-SHIP-1591697358', N'SHIP-18KEV', N'DIR-1586243597', 2, N'BNS Ulka_Store', CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'd45', N'DIR-1586243597-CAP-1591696209', 1, N'9876543', N'fnghfcfg', N'xfcghdf', N'dfgdf', 1, 2, CAST(N'2020-06-09T16:09:18.893' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.227' AS DateTime))
GO
INSERT [dbo].[O_WareHouse] ([WareHouseId], [ProgramName], [ProcessDate], [WareHouseTypeId], [WareHouseCode], [WareHouseName], [Address1], [Address2], [UnitShipId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-WAR-1591698878', N'Building-1', CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'1', N'1', N'Building-1', N'left', N'left', N'DIR-1586243597-SHIP-1591697358', 1, 2, CAST(N'2020-06-09T16:34:38.800' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.230' AS DateTime))
GO
INSERT [dbo].[O_WareHouse] ([WareHouseId], [ProgramName], [ProcessDate], [WareHouseTypeId], [WareHouseCode], [WareHouseName], [Address1], [Address2], [UnitShipId], [IsActive], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime], [IsBackup], [DerectorateId], [LastBackupDate]) VALUES (N'DIR-1586243597-WAR-1591699099', N'Building-2', CAST(N'2020-02-06T00:00:00.000' AS DateTime), N'2', N'2', N'Building-2', N'Right', N'Right', N'DIR-1586243597-SHIP-1591697358', 1, 2, CAST(N'2020-06-09T16:38:19.217' AS DateTime), NULL, NULL, 1, N'DIR-1586243597', CAST(N'2020-07-04T01:16:02.230' AS DateTime))
GO
INSERT [dbo].[UserLogin] ([Id], [FirstName], [LastName], [EmpIdNumber], [EmployeePhoneNo], [EmpImage], [DirectorateId], [Email], [Password], [PhoneNo], [UserRole], [IsActive], [UserName], [LastLoginDate], [SessionKey], [SetUpBy], [SetUpDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (2, N'Super', N'Admin', N'1', NULL, N'uploads/emloyeeimg/1image.jpeg', N'DIR-1586243597', N'info@info.com', N'1A-F4-E5-5F-04-B9-37-0A-E7-2B-1A-89-7B-07-48-0D', N'01672184004', 1, 1, N'sa', NULL, N'PBqXTQjO6x', NULL, NULL, 2, CAST(N'2020-04-07T22:30:31.817' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserPermission] ON 
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13168, 1, 1035, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13169, 1, 1125, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13170, 1, 6183, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13171, 1, 6218, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13172, 1, 7218, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13173, 1, 1034, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13174, 1, 33, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13175, 1, 6184, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13176, 1, 6186, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13177, 1, 6189, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13178, 1, 6191, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13179, 1, 6192, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13180, 1, 6195, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13181, 1, 6214, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13182, 1, 6215, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13183, 1, 6190, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13184, 1, 1100, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13185, 1, 6187, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13186, 1, 6188, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13187, 1, 6196, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13188, 1, 6198, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13189, 1, 6185, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13190, 1, 6199, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13191, 1, 6200, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13192, 1, 6197, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13193, 1, 6201, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13194, 1, 6204, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13195, 1, 6205, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13196, 1, 6209, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13197, 1, 6202, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13198, 1, 6203, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13199, 1, 6217, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13200, 1, 6207, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13201, 1, 6208, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13202, 1, 6206, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13203, 1, 6212, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13204, 1, 7219, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13205, 1, 7220, 1, 1, 1)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13206, 1, 6216, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13207, 1, 6210, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13208, 1, 6211, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13209, 1, 6213, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13294, 1002, 1035, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13295, 1002, 1125, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13296, 1002, 6183, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13297, 1002, 6218, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13298, 1002, 7218, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13299, 1002, 1034, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13300, 1002, 33, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13301, 1002, 6184, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13302, 1002, 6186, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13303, 1002, 6189, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13304, 1002, 6191, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13305, 1002, 6192, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13306, 1002, 6195, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13307, 1002, 6214, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13308, 1002, 6215, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13309, 1002, 6190, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13310, 1002, 1100, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13311, 1002, 6187, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13312, 1002, 6188, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13313, 1002, 6196, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13314, 1002, 6198, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13315, 1002, 6185, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13316, 1002, 6199, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13317, 1002, 6200, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13318, 1002, 6197, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13319, 1002, 6201, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13320, 1002, 6204, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13321, 1002, 6205, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13322, 1002, 6209, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13323, 1002, 6202, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13324, 1002, 6203, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13325, 1002, 6217, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13326, 1002, 6207, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13327, 1002, 6208, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13328, 1002, 6206, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13329, 1002, 6212, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13330, 1002, 7219, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13331, 1002, 6216, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13332, 1002, 6210, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13333, 1002, 6211, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13334, 1002, 7221, 0, 0, 0)
GO
INSERT [dbo].[UserPermission] ([PermId], [RoleId], [MenuId], [IsEdit], [IsDelete], [IsCreate]) VALUES (13335, 1002, 6213, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[UserPermission] OFF
GO
INSERT [dbo].[UserRole] ([RoleId], [UserRoleName], [SetUpBy], [SetUpDateTime], [IsActive], [UpdatedBy], [UpdatedDateTime]) VALUES (1, N'sa', NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[UserRole] ([RoleId], [UserRoleName], [SetUpBy], [SetUpDateTime], [IsActive], [UpdatedBy], [UpdatedDateTime]) VALUES (1002, N'Admin', NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[UserRole] ([RoleId], [UserRoleName], [SetUpBy], [SetUpDateTime], [IsActive], [UpdatedBy], [UpdatedDateTime]) VALUES (1586280816, N'User', 2, CAST(N'2020-04-07T23:33:36.627' AS DateTime), 1, NULL, NULL)
GO
/****** Object:  StoredProcedure [dbo].[SessionHelper]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SessionHelper]
	@empId [int]
WITH EXECUTE AS CALLER
AS
BEGIN

 SELECT 
 ISNULL(e.EmpImage,'') AS EmpImage,
 e.EmpIdNumber
 FROM Emp_BasicInfo e WHERE e.EmpId=@empId


END








GO
/****** Object:  StoredProcedure [dbo].[sp_generate_updates]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_generate_updates] (
    @fullquery              nvarchar(max) = '',
    @ignore_field_input     nvarchar(MAX) = '',
    @PK_COLUMN_NAME         nvarchar(MAX) = ''
)
AS

SET NOCOUNT ON
SET QUOTED_IDENTIFIER ON

IF OBJECT_ID('tempdb..#ignore','U') IS NOT NULL     DROP TABLE #ignore
DECLARE @stringsplit_table               TABLE (col nvarchar(255), dtype  nvarchar(255)) -- table to store the primary keys or identity key
DECLARE @PK_condition                    nvarchar(512), -- placeholder for WHERE pk_field1 = pk_value1 AND pk_field2 = pk_value2 AND ...
        @pkstring                        NVARCHAR(512),  -- sting to store the primary keys or the idendity key
        @table_name                      nvarchar(512), -- (left) table name, including schema
        @table_N_where_clause            nvarchar(max), -- tablename 
        @table_alias                     nvarchar(512), -- holds the (left) table alias if one available, else @table_name
        @table_schema                    NVARCHAR(30),  -- schema of @table_name
        @update_list1                    NVARCHAR(MAX), -- placeholder for SET fields section of update
        @update_list2                    NVARCHAR(MAX), -- placeholder for SET fields section of update value comming from other tables in the join, other than the main table to update => updateof base table possible with inner join
        @list_all_cols                   BIT = 0,       -- placeholder for values for the insert into table VALUES command
        @select_list                     NVARCHAR(MAX), -- placeholder for SELECT fields of (left) table
        @COLUMN_NAME                     NVARCHAR(255), -- will hold column names of the (left) table
        @sql                             NVARCHAR(MAX), -- sql statement variable
        @getdate                         NVARCHAR(17),  -- transform getdate() to YYYYMMDDHHMMSSMMM
        @tmp_table                       NVARCHAR(255), -- will hold the name of a physical temp table
        @pk_separator                    NVARCHAR(1),   -- separator used in @PK_COLUMN_NAME if provided (only checking obvious ones ,;|-)
        @COLUMN_NAME_DATA_TYPE           NVARCHAR(100), -- needed for insert statements to convert to right text string
        @own_pk                          BIT = 0        -- check if table has PK (0) or if provided PK will be used (1)




set @ignore_field_input=replace(replace(replace(@ignore_field_input,' ',''),'[',''),']','')
set @PK_COLUMN_NAME=    replace(replace(replace(@PK_COLUMN_NAME,    ' ',''),'[',''),']','')

-- first we remove all linefeeds from the user query
set @fullquery=replace(replace(replace(@fullquery,char(10),''),char(13),' '),'  ',' ')
set @table_N_where_clause=@fullquery
if charindex ('order by' , @table_N_where_clause) > 0
    print ' WARNING:        ORDER BY NOT ALLOWED IN UPDATE ...'
if @PK_COLUMN_NAME <> ''
    select ' WARNING:        IF you select your own primary keys, make double sure before doing the update statements below!! '
--print @table_N_where_clause
if charindex ('select ' , @table_N_where_clause) = 0
    set @table_N_where_clause= 'select * from ' + @table_N_where_clause
if charindex ('select ' , @table_N_where_clause) > 0
    --exec (@table_N_where_clause)
	---------------------------------------------------------this is for full table show

set @table_N_where_clause=rtrim(ltrim(substring(@table_N_where_clause,CHARINDEX(' from ', @table_N_where_clause )+6, 4000)))
--print @table_N_where_clause 
set @table_name=left(@table_N_where_clause,CHARINDEX(' ', @table_N_where_clause )-1)


IF CHARINDEX('where ', @table_N_where_clause) > 0             SELECT @table_alias = LTRIM(RTRIM(REPLACE(REPLACE(SUBSTRING(@table_N_where_clause,1, CHARINDEX('where ', @table_N_where_clause )-1),'(nolock)',''),@table_name,'')))
IF CHARINDEX('join ',  @table_alias) > 0                      SELECT @table_alias = SUBSTRING(@table_alias, 1, CHARINDEX(' ', @table_alias)-1) -- until next space
IF LEN(@table_alias) = 0                                      SELECT @table_alias = @table_name
IF (charindex (' *' , @fullquery) > 0 or charindex (@table_alias+'.*' , @fullquery) > 0 )     set @list_all_cols=1
/*       
       print @fullquery     
       print @table_alias
       print @table_N_where_clause
       print @table_name
*/


-- Prepare PK condition
        SELECT @table_schema = CASE WHEN CHARINDEX('.',@table_name) > 0 THEN LEFT(@table_name, CHARINDEX('.',@table_name)-1) ELSE 'dbo' END

        SELECT @PK_condition = ISNULL(@PK_condition + ' AND ', '') + QUOTENAME('pk_'+COLUMN_NAME) + ' = ' + QUOTENAME('pk_'+COLUMN_NAME,'{')
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
        AND TABLE_NAME = REPLACE(@table_name,@table_schema+'.','') 
        AND TABLE_SCHEMA = @table_schema

        SELECT @pkstring = ISNULL(@pkstring + ', ', '') + @table_alias + '.' + QUOTENAME(COLUMN_NAME) + ' AS pk_' + COLUMN_NAME
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE i1
        WHERE OBJECTPROPERTY(OBJECT_ID(i1.CONSTRAINT_SCHEMA + '.' + QUOTENAME(i1.CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
        AND i1.TABLE_NAME = REPLACE(@table_name,@table_schema+'.','') 
        AND i1.TABLE_SCHEMA = @table_schema

            -- if no primary keys exist then we try for identity columns
                IF @PK_condition is null SELECT @PK_condition = ISNULL(@PK_condition + ' AND ', '') + QUOTENAME('pk_'+COLUMN_NAME) + ' = ' + QUOTENAME('pk_'+COLUMN_NAME,'{')
                FROM  INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMNPROPERTY(object_id(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 
                AND TABLE_NAME = REPLACE(@table_name,@table_schema+'.','') 
                AND TABLE_SCHEMA = @table_schema

                IF @pkstring is null SELECT @pkstring = ISNULL(@pkstring + ', ', '') + @table_alias + '.' + QUOTENAME(COLUMN_NAME) + ' AS pk_' + COLUMN_NAME
                FROM  INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMNPROPERTY(object_id(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 
                AND TABLE_NAME = REPLACE(@table_name,@table_schema+'.','') 
                AND TABLE_SCHEMA = @table_schema
-- Same but in form of a table

        INSERT INTO @stringsplit_table
        SELECT 'pk_'+i1.COLUMN_NAME as col, i2.DATA_TYPE as dtype
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE i1
        inner join INFORMATION_SCHEMA.COLUMNS i2
        on  i1.TABLE_NAME = i2.TABLE_NAME AND i1.TABLE_SCHEMA =  i2.TABLE_SCHEMA
        WHERE OBJECTPROPERTY(OBJECT_ID(i1.CONSTRAINT_SCHEMA + '.' + QUOTENAME(i1.CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
        AND i1.TABLE_NAME = REPLACE(@table_name,@table_schema+'.','') 
        AND i1.TABLE_SCHEMA = @table_schema

                -- if no primary keys exist then we try for identity columns
                IF 0=(select count(*) from @stringsplit_table) INSERT INTO @stringsplit_table
                SELECT 'pk_'+i2.COLUMN_NAME as col, i2.DATA_TYPE as dtype
                FROM INFORMATION_SCHEMA.COLUMNS i2
                WHERE COLUMNPROPERTY(object_id(i2.TABLE_SCHEMA+'.'+i2.TABLE_NAME), i2.COLUMN_NAME, 'IsIdentity') = 1 
                AND i2.TABLE_NAME = REPLACE(@table_name,@table_schema+'.','') 
                AND i2.TABLE_SCHEMA = @table_schema

-- NOW handling the primary key given as parameter to the main batch

SELECT @pk_separator = ',' -- take this as default, we'll check lower if it's a different one
IF (@PK_condition IS NULL OR @PK_condition = '') AND @PK_COLUMN_NAME <> ''
BEGIN
    IF CHARINDEX(';', @PK_COLUMN_NAME) > 0
        SELECT @pk_separator = ';'
    ELSE IF CHARINDEX('|', @PK_COLUMN_NAME) > 0
        SELECT @pk_separator = '|'
    ELSE IF CHARINDEX('-', @PK_COLUMN_NAME) > 0
        SELECT @pk_separator = '-'

    SELECT @PK_condition = NULL -- make sure to make it NULL, in case it was ''
    INSERT INTO @stringsplit_table
    SELECT LTRIM(RTRIM(x.value)) , 'datetime'  FROM STRING_SPLIT(@PK_COLUMN_NAME, @pk_separator) x  
    SELECT @PK_condition = ISNULL(@PK_condition + ' AND ', '') + QUOTENAME(x.col) + ' = ' + replace(QUOTENAME(x.col,'{'),'{','{pk_')
      FROM @stringsplit_table x

    SELECT @PK_COLUMN_NAME = NULL -- make sure to make it NULL, in case it was ''
    SELECT @PK_COLUMN_NAME = ISNULL(@PK_COLUMN_NAME + ', ', '') + QUOTENAME(x.col) + ' as pk_' + x.col
      FROM @stringsplit_table x
    --print 'pkcolumns  '+ isnull(@PK_COLUMN_NAME,'')
    update @stringsplit_table set col='pk_' + col
    SELECT @own_pk = 1
END
ELSE IF (@PK_condition IS NULL OR @PK_condition = '') AND @PK_COLUMN_NAME = ''
BEGIN
    RAISERROR('No Primary key or Identity column available on table. Add some columns as the third parameter when calling this SP to make your own temporary PK., also remove  [] from tablename',17,1)
END


-- IF there are no primary keys or an identity key in the table active, then use the given columns as a primary key


if isnull(@pkstring,'')   = ''  set    @pkstring  = @PK_COLUMN_NAME
IF ISNULL(@pkstring, '') <> ''  SELECT @fullquery = REPLACE(@fullquery, 'SELECT ','SELECT ' + @pkstring + ',' )
--print @pkstring




-- ignore fields for UPDATE STATEMENT (not ignored for the insert statement,  in iserts statement we ignore only identity Columns and the columns provided with the main stored proc )
-- Place here all fields that you know can not be converted to nvarchar() values correctly, an thus should not be scripted for updates)
-- for insert we will take these fields along, although they will be incorrectly represented!!!!!!!!!!!!!.
SELECT           ignore_field = 'uniqueidXXXX' INTO #ignore 
UNION ALL SELECT ignore_field = 'UPDATEMASKXXXX'
UNION ALL SELECT ignore_field = 'UIDXXXXX'
UNION ALL SELECT value FROM  string_split(@ignore_field_input,@pk_separator)




SELECT @getdate = REPLACE(REPLACE(REPLACE(REPLACE(CONVERT(NVARCHAR(30), GETDATE(), 121), '-', ''), ' ', ''), ':', ''), '.', '')
SELECT @tmp_table = 'Release_DATA__' + @getdate + '__' + REPLACE(@table_name,@table_schema+'.','') 

SET @sql = replace( @fullquery,  ' from ',  ' INTO ' + @tmp_table +' from ')
----print (@sql)
exec (@sql)



SELECT @sql = N'alter table ' + @tmp_table + N'  add update_stmt1  nvarchar(max), update_stmt2 nvarchar(max) , update_stmt3 nvarchar(max)'
EXEC (@sql)

-- Prepare update field list (only columns from the temp table are taken if they also exist in the base table to update)
SELECT @update_list1 = ISNULL(@update_list1 + ', ', '') + 
                      CASE WHEN C1.COLUMN_NAME = 'ModifiedBy' THEN '[ModifiedBy] = left(right(replace(CONVERT(VARCHAR(19),[Modified],121),''''-'''',''''''''),19) +''''-''''+right(SUSER_NAME(),30),50)'
                           WHEN C1.COLUMN_NAME = 'Modified' THEN '[Modified] = GETDATE()'
                           ELSE QUOTENAME(C1.COLUMN_NAME) + ' = ' + QUOTENAME(C1.COLUMN_NAME,'{')
                      END
FROM INFORMATION_SCHEMA.COLUMNS c1
inner join INFORMATION_SCHEMA.COLUMNS c2
on c1.COLUMN_NAME =c2.COLUMN_NAME and c2.TABLE_NAME = REPLACE(@table_name,@table_schema+'.','')  AND c2.TABLE_SCHEMA = @table_schema
WHERE c1.TABLE_NAME = @tmp_table --REPLACE(@table_name,@table_schema+'.','') 
AND QUOTENAME(c1.COLUMN_NAME) NOT IN (SELECT QUOTENAME(ignore_field) FROM #ignore) -- eliminate binary, image etc value here
AND COLUMNPROPERTY(object_id(c2.TABLE_SCHEMA+'.'+c2.TABLE_NAME), c2.COLUMN_NAME, 'IsIdentity') <> 1
AND NOT EXISTS (SELECT 1 
                  FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE ku 
                 WHERE 1 = 1
                   AND ku.TABLE_NAME = c2.TABLE_NAME
                   AND ku.TABLE_SCHEMA = c2.TABLE_SCHEMA
                   AND ku.COLUMN_NAME = c2.COLUMN_NAME
                   AND OBJECTPROPERTY(OBJECT_ID(ku.CONSTRAINT_SCHEMA + '.' + QUOTENAME(ku.CONSTRAINT_NAME)), 'IsPrimaryKey') = 1)
AND NOT EXISTS (SELECT 1 FROM @stringsplit_table x WHERE x.col = c2.COLUMN_NAME AND @own_pk = 1)

-- Prepare update field list  (here we only take columns that commence with a #, as this is our queue for doing the update that comes from an inner joined table)
SELECT @update_list2 = ISNULL(@update_list2 + ', ', '') +  QUOTENAME(replace( C1.COLUMN_NAME,'#','')) + ' = ' + QUOTENAME(C1.COLUMN_NAME,'{')
FROM INFORMATION_SCHEMA.COLUMNS c1
WHERE c1.TABLE_NAME = @tmp_table --AND c1.TABLE_SCHEMA = @table_schema
AND QUOTENAME(c1.COLUMN_NAME) NOT IN (SELECT QUOTENAME(ignore_field) FROM #ignore) -- eliminate binary, image etc value here
AND c1.COLUMN_NAME like '#%'

-- similar for select list, but take all fields
SELECT @select_list = ISNULL(@select_list + ', ', '') + QUOTENAME(COLUMN_NAME)
FROM INFORMATION_SCHEMA.COLUMNS c
WHERE TABLE_NAME = REPLACE(@table_name,@table_schema+'.','') 
AND TABLE_SCHEMA = @table_schema
AND COLUMNPROPERTY(object_id(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') <> 1  -- Identity columns are filled automatically by MSSQL, not needed at Insert statement
AND QUOTENAME(c.COLUMN_NAME) NOT IN (SELECT QUOTENAME(ignore_field) FROM #ignore) -- eliminate binary, image etc value here


SELECT @PK_condition = REPLACE(@PK_condition, '[pk_', '[')
set @select_list='if not exists (select * from '+  REPLACE(@table_name,@table_schema+'.','') +'  where '+  @PK_condition +')  INSERT INTO '+ REPLACE(@table_name,@table_schema+'.','')   + '('+ @select_list  + ') VALUES (' + replace(replace(@select_list,'[','{'),']','}') + ')'
SELECT @sql = N'UPDATE ' + @tmp_table + ' set update_stmt1 = ''' + @select_list + '''' 
if @list_all_cols=1 EXEC (@sql)



--print 'select==========  ' + @select_list
--print 'update==========  ' + @update_list1


SELECT @sql = N'UPDATE ' + @tmp_table + N'
set update_stmt2 = CONVERT(NVARCHAR(MAX),''UPDATE ' + @table_name + 
                                          N' SET ' + @update_list1 + N''' + ''' +
                                          N' WHERE ' + @PK_condition + N''') ' 

EXEC (@sql)
--print @sql



SELECT @sql = N'UPDATE ' + @tmp_table + N'
set update_stmt3 = CONVERT(NVARCHAR(MAX),''UPDATE ' + @table_name + 
                                          N' SET ' + @update_list2 + N''' + ''' +
                                          N' WHERE ' + @PK_condition + N''') ' 

EXEC (@sql)
--print @sql


-- LOOPING OVER ALL base tables column for the INSERT INTO .... VALUES
DECLARE c_columns CURSOR FAST_FORWARD READ_ONLY FOR
    SELECT COLUMN_NAME, DATA_TYPE
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = (CASE WHEN @list_all_cols=0 THEN @tmp_table ELSE REPLACE(@table_name,@table_schema+'.','') END )
    AND TABLE_SCHEMA = @table_schema
        UNION--pned
    SELECT col, 'datetime' FROM @stringsplit_table

OPEN c_columns
FETCH NEXT FROM c_columns INTO @COLUMN_NAME, @COLUMN_NAME_DATA_TYPE
WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT @sql = 
    CASE WHEN @COLUMN_NAME_DATA_TYPE IN ('char','varchar','nchar','nvarchar')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')) ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('float','real','money','smallmoney')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],126)),   '''''''','''''''''''') + '''''''', ''NULL'')) '
        WHEN @COLUMN_NAME_DATA_TYPE IN ('uniqueidentifier')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')) ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('text','ntext')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')) ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('xxxx','yyyy')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')) ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('binary','varbinary')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')) ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('XML','xml')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],0)),     '''''''','''''''''''') + '''''''', ''NULL'')) ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('datetime','smalldatetime')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],121)),   '''''''','''''''''''') + '''''''', ''NULL'')) '
    ELSE  
                  N'UPDATE ' + @tmp_table + N' SET update_stmt1 = REPLACE(update_stmt1, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')) '
    END
    ----PRINT @sql
    EXEC (@sql)
    FETCH NEXT FROM c_columns INTO @COLUMN_NAME, @COLUMN_NAME_DATA_TYPE
END
CLOSE c_columns
DEALLOCATE c_columns

--SELECT col FROM @stringsplit_table -- these are the primary keys

-- LOOPING OVER ALL temp tables column for the Update values
DECLARE c_columns CURSOR FAST_FORWARD READ_ONLY FOR
    SELECT COLUMN_NAME,DATA_TYPE
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME =  @tmp_table --    AND TABLE_SCHEMA = @table_schema
       UNION--pned
    SELECT col, 'datetime' FROM @stringsplit_table

OPEN c_columns
FETCH NEXT FROM c_columns INTO @COLUMN_NAME, @COLUMN_NAME_DATA_TYPE
WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT @sql = 
    CASE WHEN @COLUMN_NAME_DATA_TYPE IN ('char','varchar','nchar','nvarchar')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')) ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('float','real','money','smallmoney')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],126)),   '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],126)),   '''''''','''''''''''') + '''''''', ''NULL'')) '
        WHEN @COLUMN_NAME_DATA_TYPE IN ('uniqueidentifier')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL''))  ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('text','ntext')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL''))  ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('xxxx','yyyy')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL''))  ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('binary','varbinary')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL''))  ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('XML','xml')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],0)),     '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],0)),     '''''''','''''''''''') + '''''''', ''NULL''))  ' 
        WHEN @COLUMN_NAME_DATA_TYPE IN ('datetime','smalldatetime')
            THEN  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],121)),   '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'],121)),   '''''''','''''''''''') + '''''''', ''NULL''))  ' 
    ELSE    
                  N'UPDATE ' + @tmp_table + N' SET update_stmt2 = REPLACE(update_stmt2, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL'')), update_stmt3 = REPLACE(update_stmt3, ''{' + @COLUMN_NAME + N'}'', ISNULL('''''''' + REPLACE(RTRIM(CONVERT(NVARCHAR(MAX),[' + @COLUMN_NAME + N'])),       '''''''','''''''''''') + '''''''', ''NULL''))  ' 
    END
    EXEC (@sql)
    ----print @sql
    FETCH NEXT FROM c_columns INTO @COLUMN_NAME, @COLUMN_NAME_DATA_TYPE
END
CLOSE c_columns
DEALLOCATE c_columns

SET @sql = 'Select * from  ' + @tmp_table + ';'
--exec (@sql)

SELECT @sql = N'
IF OBJECT_ID(''' + @tmp_table + N''', ''U'') IS NOT NULL
BEGIN
       SELECT   ''USE ' + DB_NAME()  + '''  as executelist 
              UNION ALL
       SELECT   ''GO ''  as executelist 
              UNION ALL
       SELECT   '' /*PRESCRIPT CHECK  */              ' + replace(@fullquery,'''','''''')+''' as executelist 
              UNION ALL
       SELECT update_stmt1 as executelist FROM ' + @tmp_table + N' where update_stmt1 is not null
              UNION ALL
       SELECT update_stmt2 as executelist FROM ' + @tmp_table + N' where update_stmt2 is not null
              UNION ALL
       SELECT isnull(update_stmt3, '' add more columns inn query please'')  as executelist FROM ' + @tmp_table + N' where update_stmt3 is not null
              UNION ALL
       SELECT ''--EXEC usp_AddInstalledScript 5, 5, 1, 1, 1, ''''' + @tmp_table + '.sql'''', 2 ''  as executelist
              UNION ALL 
       SELECT   '' /*VERIFY WITH:  */              ' + replace(@fullquery,'''','''''')+''' as executelist 
              UNION ALL
       SELECT ''-- SCRIPT LOCATION:      F:\CopyPaste\++Distributionpoint++\Release_Management\' + @tmp_table + '.sql''  as executelist   
END'
exec (@sql)

SET @sql = 'DROP TABLE ' + @tmp_table + ';'
exec (@sql)
GO
/****** Object:  StoredProcedure [dbo].[spGetAllSelectedMenuAndSubMenu]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllSelectedMenuAndSubMenu]
	@roleId [int]
WITH EXECUTE AS CALLER
AS
BEGIN
SELECT m.Id,m.ParentId,m.MenuName,up.MenuId as Selected 
FROM M_Menu m
LEFT JOIN UserPermission up ON m.Id=up.MenuId AND up.RoleId=@roleId
ORDER BY m.SortingOrderHelper,m.UpdateDateTime
END






GO
/****** Object:  StoredProcedure [dbo].[spLoadWeaponDetails]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLoadWeaponDetails]
	@weaponsInfoId varchar(100)
WITH EXECUTE AS CALLER
AS
BEGIN
SELECT 
nameOfw.NameOfGun,
main.LastMaintainceDate,
ISNULL(main.MaintainceYear,'NO DATA') AS MaintainceYear,
ISNULL(main.MaintainceDetails,'NO DATA') AS MaintainceDetails,
ware.WareHouseName,
bin.RowIdNo,
bin.SelfIdNo
FROM I_WeaponsInfo wi 
left join M_NameOfWeapon nameOfw on nameOfw.NameOfGunId=wi.NameOfWeaponsId
left join I_MaintenanceInfo main on main.ItemId=wi.WeaponsInfoId
left join O_WareHouse ware on ware.WareHouseId=wi.WareHouseId
left join I_BinLocation bin on bin.BinLocationId=wi.BinLocationId

WHERE wi.WeaponsInfoId=@weaponsInfoId;
END






GO
/****** Object:  StoredProcedure [dbo].[spNotVerifiedAddress]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spNotVerifiedAddress]
WITH EXECUTE AS CALLER
AS
BEGIN
SELECT
tblSetupDivision.DivId,
tblSetupDivision.DivName,
tblSetupDivision.EntryBy EByDiv,
tblSetupDivision.RecStatus DivRecSt,
tblSetupDivision.IsVerified DivIsVf,
tblSetupDistrict.DisId,
tblSetupDistrict.DisName,
tblSetupDistrict.EntryBy EByDis,
tblSetupDistrict.RecStatus DisRecSt,
tblSetupDistrict.IsVerified DisIsVf,
tblSetupUpazila.UpzId,
tblSetupUpazila.UpzName,
tblSetupUpazila.EntryBy EByUpz,
tblSetupUpazila.RecStatus UpzRecSt,
tblSetupUpazila.IsVerified UpzIsVf,
tblSetupPoliceStation.PsId,
tblSetupPoliceStation.PsName,
tblSetupPoliceStation.EntryBy EByPs,
tblSetupPoliceStation.RecStatus PsRecSt,
tblSetupPoliceStation.IsVerified PsIsVf,
tblSetupPostOffice.PoId,
tblSetupPostOffice.PoName,
tblSetupPostOffice.EntryBy EByPo,
tblSetupPostOffice.RecStatus PoRecSt,
tblSetupPostOffice.IsVerified PoIsVf,
tblSetupVillage.VilId,
tblSetupVillage.VilName,
tblSetupVillage.EntryBy EByVil,
tblSetupVillage.RecStatus VilRecSt,
tblSetupVillage.IsVerified VilIsVf
FROM
tblSetupVillage
Full JOIN tblSetupPostOffice ON tblSetupVillage.PoId=tblSetupPostOffice.PoId
Full JOIN tblSetupPoliceStation ON tblSetupPoliceStation.PsId=tblSetupPostOffice.PsId
Full JOIN tblSetupUpazila ON tblSetupUpazila.UpzId=tblSetupPoliceStation.UpzId
Full JOIN tblSetupDistrict ON tblSetupDistrict.DisId=tblSetupUpazila.DisId
Full JOIN tblSetupDivision ON tblSetupDistrict.DivId=tblSetupDivision.DivId
Where tblSetupDivision.RecStatus !=3 OR tblSetupDistrict.RecStatus !=3 OR tblSetupUpazila.RecStatus !=3 OR tblSetupPoliceStation.RecStatus !=3 OR tblSetupPostOffice.RecStatus !=3

END








GO
/****** Object:  StoredProcedure [dbo].[spRoleWiseMenu]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRoleWiseMenu]
	@roleId [int]
WITH EXECUTE AS CALLER
AS
BEGIN

--SELECT m.Id,m.ParentId,m.MenuUrl,m.SubParentId,m.MenuClass,m.MenuId,m.MenuName
--FROM M_Menu m WHERE m.ParentId=0
--UNION ALL
select t2.Id,t2.ParentId,t2.MenuUrl,t2.SubParentId,t2.MenuClass,t2.MenuId,t2.MenuName from UserPermission t1
inner join M_Menu t2 on t1.MenuId=t2.Id
where t1.RoleId=@roleId
END








GO
/****** Object:  StoredProcedure [dbo].[spSetTabelBackUpStatusToTrue]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSetTabelBackUpStatusToTrue] 
@tableName NVARCHAR(128) 

AS 
BEGIN 
 SET NOCOUNT ON;
 DECLARE @Sql NVARCHAR(MAX);
 DECLARE @count INT

 SET @Sql=N'UPDATE' + QUOTENAME(@tableName)+N'SET IsBackup=1,LastBackupDate=GETDATE() WHERE IsBackup=0;'

 EXECUTE sp_executesql @Sql

END







GO
/****** Object:  StoredProcedure [dbo].[spVerifiedAddress]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spVerifiedAddress]
WITH EXECUTE AS CALLER
AS
BEGIN
SELECT
tblSetupDivision.DivId,
tblSetupDivision.DivName,
tblSetupDivision.EntryBy EByDiv,
tblSetupDivision.RecStatus DivRecSt,
tblSetupDivision.IsVerified DivIsVf,
tblSetupDistrict.DisId,
tblSetupDistrict.DisName,
tblSetupDistrict.EntryBy EByDis,
tblSetupDistrict.RecStatus DisRecSt,
tblSetupDistrict.IsVerified DisIsVf,
tblSetupUpazila.UpzId,
tblSetupUpazila.UpzName,
tblSetupUpazila.EntryBy EByUpz,
tblSetupUpazila.RecStatus UpzRecSt,
tblSetupUpazila.IsVerified UpzIsVf,
tblSetupPoliceStation.PsId,
tblSetupPoliceStation.PsName,
tblSetupPoliceStation.EntryBy EByPs,
tblSetupPoliceStation.RecStatus PsRecSt,
tblSetupPoliceStation.IsVerified PsIsVf,
tblSetupPostOffice.PoId,
tblSetupPostOffice.PoName,
tblSetupPostOffice.EntryBy EByPo,
tblSetupPostOffice.RecStatus PoRecSt,
tblSetupPostOffice.IsVerified PoIsVf,
tblSetupVillage.VilId,
tblSetupVillage.VilName,
tblSetupVillage.EntryBy EByVil,
tblSetupVillage.RecStatus VilRecSt,
tblSetupVillage.IsVerified VilIsVf
FROM
tblSetupVillage
Full JOIN tblSetupPostOffice ON tblSetupVillage.PoId=tblSetupPostOffice.PoId
Full JOIN tblSetupPoliceStation ON tblSetupPoliceStation.PsId=tblSetupPostOffice.PsId
Full JOIN tblSetupUpazila ON tblSetupUpazila.UpzId=tblSetupPoliceStation.UpzId
Full JOIN tblSetupDistrict ON tblSetupDistrict.DisId=tblSetupUpazila.DisId
Full JOIN tblSetupDivision ON tblSetupDistrict.DivId=tblSetupDivision.DivId
Where tblSetupDivision.RecStatus =3 OR tblSetupDistrict.RecStatus =3 OR tblSetupUpazila.RecStatus =3 OR tblSetupPoliceStation.RecStatus =3 OR tblSetupPostOffice.RecStatus =3

END








GO
/****** Object:  Trigger [dbo].[InsertOnWeaponTable]    Script Date: 03-Apr-22 2:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Akib>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[InsertOnWeaponTable] ON  [dbo].[I_WeaponsInfo]
   AFTER INSERT 
AS 

DECLARE @WeaponId varchar(50)
DECLARE @DepotId varchar(50)
DECLARE @Quantity int

SET @WeaponId=(select WeaponsInfoId from inserted);
SET @DepotId=(select DepotId from inserted);
SET @Quantity=(select Quantity from inserted);

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON
	INSERT INTO dbo.I_WeaponsInfotracking(WeaponId,DepotId,ProcQuantity) 
	select @WeaponId,@DepotId,@Quantity
END

GO
ALTER TABLE [dbo].[I_WeaponsInfo] ENABLE TRIGGER [InsertOnWeaponTable]
GO
USE [master]
GO
ALTER DATABASE [BNAMS] SET  READ_WRITE 
GO
