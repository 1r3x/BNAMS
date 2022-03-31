USE [BNAMS]
GO
/****** Object:  Table [dbo].[HR_TraineePersonBio]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[HR_TraningInformation]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[I_BinLocation]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[I_Indent]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[I_MaintenanceInfo]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[I_StatusAfterMaintaince]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[I_WeaponsInfo]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[I_WeaponsInfotracking]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_Agent]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_AgentEnlistment]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_AgentType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_Area]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_Authorirty]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_CapabilityOfWeapons]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_Composite]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_Country]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_DepotShipCategory]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_FiscalYear]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_IndentStatus]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_IndentType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_MaintainceStatus(c)]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_MaintainceType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_Menu]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_MissilePrepType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_NameOfWeapon]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_PriceType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_ProcurementCategory]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_ProductCategory]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_QuantityCategory]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_RankSetup]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_StatusInformation]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_TraningOrg]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_TypeOfShip]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_WareHouseType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_WeaponsModelType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[M_WeaponsType]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[O_DirectorateInfo]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[O_ShipOrDepotInfo]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[O_WareHouse]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[UserLogin]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[UserPermission]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Table [dbo].[W_Inspection]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SessionHelper]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_generate_updates]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetAllSelectedMenuAndSubMenu]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spLoadWeaponDetails]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spNotVerifiedAddress]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spRoleWiseMenu]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spSetTabelBackUpStatusToTrue]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spVerifiedAddress]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
/****** Object:  Trigger [dbo].[InsertOnWeaponTable]    Script Date: 07-Nov-21 10:48:36 PM ******/
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
