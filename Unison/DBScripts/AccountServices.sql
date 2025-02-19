if exists (select * from sysobjects where id = object_id(N'[dbo].[CalendarSchedules]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CalendarSchedules]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[AccountServices]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AccountServices]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ADDRESS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ADDRESS]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[BillingCycles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BillingCycles]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[CITY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CITY]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[CUSTOMER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CUSTOMER]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[DateTest]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DateTest]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[EMPLOYEE_OLD]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMPLOYEE_OLD]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[EmployeeGroups]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EmployeeGroups]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[EmployeesBase]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EmployeesBase]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[EMPLOYEETYPE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMPLOYEETYPE]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[HolidayRoutes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[HolidayRoutes]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[Holidays]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Holidays]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ImportAcctTOP]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImportAcctTOP]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ImportB2-0]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImportB2-0]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ImportB2-2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImportB2-2]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ImportFDailyRate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImportFDailyRate]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ImportFDBCONDay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImportFDBCONDay]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ImportFInstruction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImportFInstruction]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ImportTopSID]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImportTopSID]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[IncreaseRatesAcct]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IncreaseRatesAcct]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[IncreasesService]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IncreasesService]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ListingsTemplates]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ListingsTemplates]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[LISTLAYOUTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LISTLAYOUTS]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[NoticeFormats]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[NoticeFormats]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[Notices]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Notices]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[PACKAGETYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PACKAGETYPES]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ROUTECALENDER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ROUTECALENDER]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ROUTECANCEL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ROUTECANCEL]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ROUTECHARGE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ROUTECHARGE]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ROUTES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ROUTES]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ROUTESCHEDULE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ROUTESCHEDULE]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[RUNS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RUNS]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[RUNSCALENDAR]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RUNSCALENDAR]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ServiceGroupMembers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ServiceGroupMembers]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ServiceGroups]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ServiceGroups]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[SERVICEOFFICES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SERVICEOFFICES]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[SERVICES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SERVICES]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ServiceSchedules]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ServiceSchedules]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[ServiceTypes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ServiceTypes]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[STATE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[STATE]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[SUBROUTE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SUBROUTE]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[TimeFrames]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TimeFrames]
GO

CREATE TABLE [dbo].[AccountServices] (
	[ROWID] [int] IDENTITY (1, 1) NOT NULL ,
	[ID] [smallint] NULL ,
	[AccountID] [int] NOT NULL ,
	[OfficeID] [int] NOT NULL ,
	[CompName] [varchar] (40) NOT NULL ,
	[Street] [varchar] (50) NOT NULL ,
	[CityName] [varchar] (50) NOT NULL ,
	[STATE] [varchar] (2) NOT NULL ,
	[ZipCode] [varchar] (10) NOT NULL ,
	[PHONE1] [varchar] (16) NOT NULL ,
	[PHONE2] [varchar] (16) NOT NULL ,
	[Remarks] [varchar] (100) NOT NULL ,
	[StartDate] [datetime] NULL ,
	[EndDate] [datetime] NULL ,
	[OpenTime] [varchar] (8) NOT NULL ,
	[CloseTime] [varchar] (8) NOT NULL ,
	[DoorKey] [bit] NOT NULL ,
	[BoxKey] [bit] NOT NULL ,
	[InternalRef] [varchar] (20) NOT NULL ,
	[AccountRef] [varchar] (20) NOT NULL ,
	[TimeFrameID] [int] NOT NULL ,
	[ServiceID] [int] NOT NULL ,
	[ServiceTypeID] [int] NOT NULL ,
	[PackageID] [int] NOT NULL ,
	[Charge] [decimal](6, 2) NOT NULL ,
	[DailyAvgChg] [decimal](6, 2) NOT NULL ,
	[InfoSID] [int] NOT NULL ,
	[SchedType] [varchar] (1) NOT NULL ,
	[NonPrintRemark] [varchar] (255) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ADDRESS] (
	[ID] [int] NOT NULL ,
	[OWNERID] [int] NOT NULL ,
	[NAME] [nvarchar] (40) NULL ,
	[CONTACT] [nvarchar] (40) NULL ,
	[STREET] [nvarchar] (40) NULL ,
	[STATECODE] [nvarchar] (2) NULL ,
	[CITYID] [int] NULL ,
	[ZIPCODE] [nvarchar] (16) NULL ,
	[ZIPPLUS] [nvarchar] (8) NULL ,
	[PHONE] [nvarchar] (16) NULL ,
	[FAX] [nvarchar] (16) NULL ,
	[PAGER] [nvarchar] (16) NULL ,
	[EXTENSION] [nvarchar] (4) NULL ,
	[DIRECTION] [nvarchar] (120) NULL ,
	[EMAIL] [nvarchar] (40) NULL ,
	[CREATEDATE] [nvarchar] (8) NULL ,
	[LASTACTIVEDATE] [nvarchar] (8) NULL ,
	[OWNERTYPE] [nvarchar] (1) NULL ,
	[SYSTEMID] [int] NULL ,
	[PIN] [int] NULL ,
	[MAPCODE] [nvarchar] (16) NULL ,
	[CITYNAME] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BillingCycles] (
	[Code] [varchar] (1) NOT NULL ,
	[Name] [varchar] (30) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CITY] (
	[ID] [int] NOT NULL ,
	[NAME] [nvarchar] (32) NULL ,
	[ZIPCODE] [nvarchar] (5) NULL ,
	[ZIPPLUS] [nvarchar] (8) NULL ,
	[STATECODE] [nvarchar] (2) NULL ,
	[LATITUDE] [float] NULL ,
	[LONGITUDE] [float] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CUSTOMER] (
	[ID] [int] NOT NULL ,
	[NAME] [varchar] (40) NOT NULL ,
	[CONTACT] [varchar] (40) NOT NULL ,
	[STREET] [varchar] (40) NOT NULL ,
	[CITYID] [int] NULL ,
	[CITYNAME] [varchar] (50) NOT NULL ,
	[STATE] [varchar] (2) NOT NULL ,
	[ZIPCODE] [varchar] (10) NOT NULL ,
	[PHONE1] [varchar] (16) NULL ,
	[PHONE2] [varchar] (16) NOT NULL ,
	[FAX] [varchar] (16) NOT NULL ,
	[PAGER] [varchar] (16) NOT NULL ,
	[EXTENSION] [varchar] (4) NOT NULL ,
	[EMAIL] [varchar] (50) NOT NULL ,
	[Web] [varchar] (30) NOT NULL ,
	[CREATEDATE] [datetime] NULL ,
	[LASTBillDate] [datetime] NULL ,
	[BCycleCode] [varchar] (1) NOT NULL ,
	[CREDITLIMIT] [float] NOT NULL ,
	[COMMENTS] [varchar] (255) NOT NULL ,
	[DISCOUNTRATE] [float] NOT NULL ,
	[SALESID] [int] NOT NULL ,
	[APPLYRATEINCREASE] [float] NOT NULL ,
	[GRACEPERIOD] [smallint] NOT NULL ,
	[TAXRATE] [float] NOT NULL ,
	[FuelSURCHARGE] [float] NOT NULL ,
	[INCREASEDATE] [datetime] NULL ,
	[INCREASERATE] [float] NOT NULL ,
	[FINANCECHARGE] [float] NOT NULL ,
	[Status] [bit] NOT NULL ,
	[AcctGroupID] [int] NOT NULL ,
	[SubjHoliday] [bit] NOT NULL ,
	[bNAME] [varchar] (40) NOT NULL ,
	[bCONTACT] [varchar] (40) NOT NULL ,
	[bSTREET] [varchar] (40) NOT NULL ,
	[bCITYID] [int] NOT NULL ,
	[bCITYNAME] [varchar] (50) NOT NULL ,
	[bSTATE] [varchar] (2) NOT NULL ,
	[bZIPCODE] [varchar] (10) NOT NULL ,
	[bPHONE1] [varchar] (16) NOT NULL ,
	[bPHONE2] [varchar] (16) NOT NULL ,
	[bFAX] [varchar] (16) NOT NULL ,
	[bEMAIL] [varchar] (50) NOT NULL ,
	[SamePayAddress] [bit] NOT NULL ,
	[NRVNU] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DateTest] (
	[VDate] [datetime] NULL ,
	[iDate] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMPLOYEE_OLD] (
	[ID] [int] NOT NULL ,
	[NAME] [nvarchar] (40) NULL ,
	[DATEOFBIRTH] [nvarchar] (8) NULL ,
	[DEPARTMENTID] [int] NULL ,
	[STREET] [nvarchar] (40) NULL ,
	[DIRECTION] [nvarchar] (40) NULL ,
	[CITYID] [int] NULL ,
	[STATECODE] [nvarchar] (2) NULL ,
	[ZIPCODE] [nvarchar] (16) NULL ,
	[ZIPPLUS] [nvarchar] (8) NULL ,
	[PHONE] [nvarchar] (16) NULL ,
	[PAGER] [nvarchar] (16) NULL ,
	[PASSWORD] [nvarchar] (8) NULL ,
	[EQUIPMENT] [nvarchar] (40) NULL ,
	[COMMENTS] [nvarchar] (40) NULL ,
	[HIREDATE] [nvarchar] (8) NULL ,
	[TERMDATE] [nvarchar] (8) NULL ,
	[POSITION] [nvarchar] (40) NULL ,
	[SSN] [nvarchar] (16) NULL ,
	[DLN] [nvarchar] (16) NULL ,
	[SALARY] [float] NULL ,
	[COMMISSION] [float] NULL ,
	[TYPE] [nvarchar] (1) NULL ,
	[EMAIL] [nvarchar] (40) NULL ,
	[INSURANCE] [nvarchar] (40) NULL ,
	[SYSTEMID] [int] NULL ,
	[PIN] [int] NULL ,
	[PAGERMODELID] [int] NULL ,
	[CITYNAME] [varchar] (40) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EmployeeGroups] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (30) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EmployeesBase] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[FirstName] [varchar] (30) NOT NULL ,
	[MiddleName] [varchar] (30) NOT NULL ,
	[LastName] [varchar] (30) NOT NULL ,
	[Status] [varchar] (1) NOT NULL ,
	[EmplGroupID] [int] NOT NULL ,
	[CreateDate] [datetime] NULL ,
	[StatusDate] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMPLOYEETYPE] (
	[EMPTYPE] [nvarchar] (1) NOT NULL ,
	[EMPDESCRIPTION] [nvarchar] (32) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[HolidayRoutes] (
	[HDate] [datetime] NOT NULL ,
	[AccountID] [int] NOT NULL ,
	[ServiceID] [int] NOT NULL ,
	[HCharge] [decimal](5, 2) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Holidays] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[HDate] [datetime] NULL ,
	[Charge] [decimal](5, 2) NOT NULL ,
	[Description] [varchar] (30) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImportAcctTOP] (
	[LastBILLDate] [varchar] (255) NULL ,
	[YTD.COL] [varchar] (255) NULL ,
	[AC#] [varchar] (255) NULL ,
	[NAME] [varchar] (255) NULL ,
	[CONTACT] [varchar] (255) NULL ,
	[ADDRESS] [varchar] (255) NULL ,
	[CITY] [varchar] (255) NULL ,
	[STATE] [varchar] (255) NULL ,
	[ZIP] [varchar] (255) NULL ,
	[TYPE] [varchar] (255) NULL ,
	[BC] [varchar] (255) NULL ,
	[CONSOLIDATED] [varchar] (255) NULL ,
	[PHONE] [varchar] (255) NULL ,
	[FAX] [varchar] (255) NULL ,
	[LASTINCDate] [varchar] (255) NULL ,
	[FuelSur] [varchar] (255) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImportB2-0] (
	[CUST#NO] [nvarchar] (255) NULL ,
	[SEQ#NO] [nvarchar] (255) NULL ,
	[STOP#DESCRIP] [nvarchar] (255) NULL ,
	[STREET#NO] [nvarchar] (255) NULL ,
	[STREET#NAME] [nvarchar] (255) NULL ,
	[ADDR#2] [nvarchar] (255) NULL ,
	[CITY] [nvarchar] (255) NULL ,
	[STATE] [nvarchar] (255) NULL ,
	[ZIP5] [nvarchar] (255) NULL ,
	[PHONE] [nvarchar] (255) NULL ,
	[START#DATE] [nvarchar] (255) NULL ,
	[END#DATE] [nvarchar] (255) NULL ,
	[CHARGES] [float] NULL ,
	[AREA] [nvarchar] (255) NULL ,
	[ROUTE] [nvarchar] (255) NULL ,
	[STOP] [nvarchar] (255) NULL ,
	[TIME#DUE] [nvarchar] (255) NULL ,
	[DAY] [nvarchar] (255) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImportB2-2] (
	[Cust#No] [nvarchar] (255) NULL ,
	[Seq#No] [nvarchar] (255) NULL ,
	[Type] [nvarchar] (255) NULL ,
	[Seq] [nvarchar] (255) NULL ,
	[Description] [nvarchar] (255) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImportFDailyRate] (
	[Custseq] [nvarchar] (255) NULL ,
	[Day] [nvarchar] (255) NULL ,
	[Charge] [float] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImportFDBCONDay] (
	[CUST#SEQ] [nvarchar] (255) NULL ,
	[DAY] [nvarchar] (255) NULL ,
	[AREARTE] [nvarchar] (255) NULL ,
	[STOP] [nvarchar] (255) NULL ,
	[TIME#DUE] [nvarchar] (255) NULL ,
	[END#DATE] [nvarchar] (255) NULL ,
	[CHARGES] [float] NULL ,
	[STOP#DESCRIP] [nvarchar] (255) NULL ,
	[STREET#NO] [nvarchar] (255) NULL ,
	[STREET#NAME] [nvarchar] (255) NULL ,
	[ADDR#2] [nvarchar] (255) NULL ,
	[CITY] [nvarchar] (255) NULL ,
	[ZIP5] [nvarchar] (255) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImportFInstruction] (
	[Cust#Seq] [nvarchar] (255) NULL ,
	[SERVICE#DESC] [nvarchar] (255) NULL ,
	[Type] [nvarchar] (255) NULL ,
	[Seq] [nvarchar] (255) NULL ,
	[Description] [nvarchar] (255) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImportTopSID] (
	[AC#] [varchar] (255) NULL ,
	[SID] [varchar] (255) NULL ,
	[Name] [varchar] (255) NULL ,
	[Street1] [varchar] (255) NULL ,
	[Street2] [varchar] (255) NULL ,
	[City] [varchar] (255) NULL ,
	[SDate] [varchar] (255) NULL ,
	[MoCost] [varchar] (255) NULL ,
	[EDate] [varchar] (255) NULL ,
	[Stime] [varchar] (255) NULL ,
	[Br] [varchar] (255) NULL ,
	[Rte#] [varchar] (255) NULL ,
	[Stp#] [varchar] (255) NULL ,
	[Mon] [varchar] (255) NULL ,
	[Tue] [varchar] (255) NULL ,
	[Wed] [varchar] (255) NULL ,
	[Thu] [varchar] (255) NULL ,
	[Fri] [varchar] (255) NULL ,
	[Sat] [varchar] (255) NULL ,
	[Sun] [varchar] (255) NULL ,
	[WkCost] [varchar] (255) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IncreaseRatesAcct] (
	[IncDate] [datetime] NOT NULL ,
	[AccountID] [int] NOT NULL ,
	[Rate] [decimal](6, 2) NOT NULL ,
	[Applied] [bit] NOT NULL ,
	[Comment] [varchar] (255) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IncreasesService] (
	[IncDate] [datetime] NOT NULL ,
	[AccountID] [int] NOT NULL ,
	[SID] [int] NOT NULL ,
	[FinalAmount] [decimal](6, 2) NOT NULL ,
	[Applied] [bit] NOT NULL ,
	[Comment] [varchar] (255) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ListingsTemplates] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ListName] [varchar] (20) NOT NULL ,
	[NAME] [varchar] (20) NOT NULL ,
	[Template] [varbinary] (8000) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LISTLAYOUTS] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[USERID] [int] NOT NULL ,
	[FORMNAME] [varchar] (30) NOT NULL ,
	[LAYOUT] [varbinary] (8000) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NoticeFormats] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) NOT NULL ,
	[FileName] [varchar] (255) NOT NULL ,
	[FileImage] [image] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Notices] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[FormatID] [int] NOT NULL ,
	[HDate] [datetime] NOT NULL ,
	[AccountID] [int] NOT NULL ,
	[AccountName] [varchar] (40) NOT NULL ,
	[Responded] [bit] NOT NULL ,
	[RespDate] [datetime] NULL ,
	[NeedService] [bit] NOT NULL ,
	[NoService] [bit] NOT NULL ,
	[RespOperID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PACKAGETYPES] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[NAME] [varchar] (30) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ROUTECALENDER] (
	[ROUTEID] [nvarchar] (7) NOT NULL ,
	[ROUTEDATE] [nvarchar] (8) NULL ,
	[ROUTEFLAG] [nvarchar] (1) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ROUTECANCEL] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[CUSTOMERID] [int] NULL ,
	[SERVICENO] [int] NULL ,
	[PDTYPE] [char] (1) NULL ,
	[WDATE] [char] (8) NULL ,
	[REASON] [varchar] (40) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ROUTECHARGE] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[CUSTOMERID] [int] NULL ,
	[SERVICENO] [int] NULL ,
	[CHARGEDATE] [varchar] (8) NULL ,
	[WEIGHTA] [int] NULL ,
	[WEIGHTG] [int] NULL ,
	[CHARGEA] [money] NULL ,
	[CHARGEG] [money] NULL ,
	[TOTALCHARGE] [money] NULL ,
	[INVOICEID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ROUTES] (
	[OFFICEID] [int] NOT NULL ,
	[ID] [varchar] (4) NOT NULL ,
	[NAME] [varchar] (40) NULL ,
	[DRIVERID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ROUTESCHEDULE] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ROUTESERVICEID] [int] NULL ,
	[OFFICEID] [int] NULL ,
	[ROUTEID] [char] (6) NULL ,
	[STIME] [char] (4) NULL ,
	[CTIME] [char] (4) NULL ,
	[CHARGE] [char] (10) NULL ,
	[STOPNO] [varchar] (50) NULL ,
	[WDAY] [int] NULL ,
	[WDATE] [varchar] (8) NULL ,
	[PDTYPE] [varchar] (1) NULL ,
	[WCTYPE] [varchar] (1) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RUNS] (
	[CUSTOMERID] [int] NOT NULL ,
	[SERVICEID] [int] NOT NULL ,
	[CALLER] [nvarchar] (40) NULL ,
	[ADDRESSID] [int] NULL ,
	[STARTDATE] [nvarchar] (8) NULL ,
	[ENDDATE] [nvarchar] (8) NULL ,
	[OPENTIME] [nvarchar] (4) NULL ,
	[CLOSETIME] [nvarchar] (4) NULL ,
	[PKGTYPEID] [int] NULL ,
	[ACTIONTYPE] [nvarchar] (1) NULL ,
	[DOORKEY] [nvarchar] (1) NULL ,
	[BOXKEY] [nvarchar] (1) NULL ,
	[SERVICECLASS] [nvarchar] (1) NULL ,
	[SERVICECHARGE] [float] NULL ,
	[INTREFERENCE] [nvarchar] (16) NULL ,
	[REFERENCENO] [nvarchar] (16) NULL ,
	[WEIGHTLIMITG] [int] NULL ,
	[WEIGHTCHARGEG] [float] NULL ,
	[WEIGHTLIMITA] [int] NULL ,
	[WEIGHTCHARGEA] [int] NULL ,
	[SCHEDULE] [nvarchar] (1) NULL ,
	[INSTRUCTIONS] [nvarchar] (120) NULL ,
	[MON] [nvarchar] (50) NULL ,
	[TUE] [nvarchar] (50) NULL ,
	[WED] [nvarchar] (50) NULL ,
	[THU] [nvarchar] (50) NULL ,
	[FRI] [nvarchar] (50) NULL ,
	[SAT] [nvarchar] (50) NULL ,
	[SUN] [nvarchar] (50) NULL ,
	[SYSTEMID] [int] NULL ,
	[HOLPERYEAR] [nvarchar] (2) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RUNSCALENDAR] (
	[CUSTOMERID] [int] NOT NULL ,
	[SERVICEID] [int] NOT NULL ,
	[ROUTEDATE] [nvarchar] (8) NULL ,
	[OFFICEID] [int] NULL ,
	[ROUTEID] [int] NULL ,
	[ROUTETIME] [nvarchar] (4) NULL ,
	[CHARGE] [float] NULL ,
	[STOPNO] [nvarchar] (3) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ServiceGroupMembers] (
	[AccountID] [int] NOT NULL ,
	[SID] [int] NOT NULL ,
	[SGroupID] [int] NOT NULL ,
	[Comment] [varchar] (255) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ServiceGroups] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (20) NOT NULL ,
	[Comment] [varchar] (255) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SERVICEOFFICES] (
	[ID] [int] NOT NULL ,
	[NAME] [varchar] (50) NULL ,
	[STREET] [varchar] (60) NULL ,
	[CITY] [varchar] (40) NULL ,
	[STATE] [varchar] (2) NULL ,
	[ZIPCODE] [varchar] (10) NULL ,
	[PHONE1] [varchar] (10) NULL ,
	[PHONE2] [varchar] (10) NULL ,
	[FAX] [varchar] (10) NULL ,
	[EMAIL] [varchar] (40) NULL ,
	[WEB] [varchar] (30) NULL ,
	[Territory] [varchar] (1) NULL ,
	[RegionID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SERVICES] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[NAME] [varchar] (30) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ServiceSchedules] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[AccountID] [int] NOT NULL ,
	[SID] [smallint] NOT NULL ,
	[Day] [tinyint] NOT NULL ,
	[ServiceDate] [datetime] NULL ,
	[RouteNo] [varchar] (4) NOT NULL ,
	[StopNo] [tinyint] NOT NULL ,
	[OfficeID] [int] NOT NULL ,
	[STime] [datetime] NOT NULL ,
	[CTime] [datetime] NOT NULL ,
	[Charge] [decimal](6, 2) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ServiceTypes] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (4) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[STATE] (
	[CODE] [nvarchar] (2) NOT NULL ,
	[NAME] [nvarchar] (32) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SUBROUTE] (
	[ROUTEID] [nvarchar] (7) NOT NULL ,
	[CUSTOMERID] [int] NULL ,
	[ADDRESSID] [int] NULL ,
	[PUADDRESSID] [int] NULL ,
	[DLADDRESSID] [int] NULL ,
	[AMOUNT] [float] NULL ,
	[STARTDATE] [nvarchar] (8) NOT NULL ,
	[TERMDATE] [nvarchar] (8) NULL ,
	[ESTPUTIME] [nvarchar] (4) NULL ,
	[ESTDLTIME] [nvarchar] (4) NULL ,
	[PIECES] [int] NULL ,
	[WEIGHT] [int] NULL ,
	[POUNDS] [int] NULL ,
	[OUNCES] [int] NULL ,
	[DRIVERID] [int] NULL ,
	[CARRIERID] [int] NULL ,
	[CARRIERTYPE] [nvarchar] (1) NULL ,
	[SERVICECLASS] [nvarchar] (1) NULL ,
	[RTFLAG] [nvarchar] (1) NULL ,
	[DAY01] [nvarchar] (1) NULL ,
	[DAY02] [nvarchar] (1) NULL ,
	[DAY03] [nvarchar] (1) NULL ,
	[DAY04] [nvarchar] (1) NULL ,
	[DAY05] [nvarchar] (1) NULL ,
	[DAY06] [nvarchar] (1) NULL ,
	[DAY07] [nvarchar] (1) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TimeFrames] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (3) NOT NULL 
) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER  ON    SET ANSI_NULLS  ON 
GO

CREATE VIEW dbo.CalendarSchedules
AS
SELECT AccountID, SID, ServiceDate AS SvcDate, 
    SUBSTRING(DATENAME(dw, ServiceDate), 1, 3) AS [Day], 
    OfficeID AS Ofc, RouteNo AS Rte, STime AS STm, 
    CTime AS CTm, StopNo AS Stp, Charge AS Chg
FROM ServiceSchedules
WHERE Servicedate IS NOT NULL

GO
SET QUOTED_IDENTIFIER  OFF    SET ANSI_NULLS  ON 
GO

