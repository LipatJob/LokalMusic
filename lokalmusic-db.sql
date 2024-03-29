/****** Object:  Database [lokalmusic-db]    Script Date: 3/22/2021 12:23:01 PM ******/
CREATE DATABASE [lokalmusic-db]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [lokalmusic-db] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [lokalmusic-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lokalmusic-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lokalmusic-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lokalmusic-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lokalmusic-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [lokalmusic-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lokalmusic-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lokalmusic-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lokalmusic-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lokalmusic-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lokalmusic-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lokalmusic-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lokalmusic-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lokalmusic-db] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [lokalmusic-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lokalmusic-db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [lokalmusic-db] SET  MULTI_USER 
GO
ALTER DATABASE [lokalmusic-db] SET ENCRYPTION ON
GO
ALTER DATABASE [lokalmusic-db] SET QUERY_STORE = ON
GO
ALTER DATABASE [lokalmusic-db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[UserStatusId] [int] NOT NULL,
	[ProfileImageId] [int] NULL,
	[Email] [varchar](100) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NULL,
	[DateRegistered] [date] NOT NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
 CONSTRAINT [PK__UserInfo__1788CC4C9F5E8E27] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__UserInfo__536C85E4395DEC71] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__UserInfo__A9D10534CEAC4AA0] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatus](
	[UserStatusId] [int] IDENTITY(1,1) NOT NULL,
	[UserStatusName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__UserStat__A33F543A58DB9DD8] PRIMARY KEY CLUSTERED 
(
	[UserStatusId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__UserStat__60DF70E85C137CEB] UNIQUE NONCLUSTERED 
(
	[UserStatusName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ActiveUserInfo]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ActiveUserInfo]
	AS 
	SELECT * 
	FROM [UserInfo] 
	WHERE UserStatusId =   (SELECT UserStatusId
							FROM UserStatus
							WHERE UserStatusName = 'ACTIVE' )
GO
/****** Object:  UserDefinedFunction [dbo].[GetMonthsBetween]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetMonthsBetween]
(
	@StartDate DATE,
	@EndDate DATE
)
RETURNS TABLE AS RETURN
(
WITH Dates(Date) AS
(
    SELECT DATEADD(DAY, 0, DATEDIFF(DAY, 0, @StartDate)) AS Date
    UNION ALL
    SELECT DATEADD(MONTH, 1, Date) AS Date
    FROM Dates
    WHERE Date < @EndDate
)
SELECT
    d.Date AS DateStart,
    CAST(EOMONTH(d.Date) AS DATETIME) AS DateEnd
FROM Dates d
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetWeeksBetween]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetWeeksBetween]
(
	@StartDate DATE,
	@EndDate DATE
)
RETURNS TABLE AS RETURN
(
WITH Dates(Date) AS
(
    SELECT DATEADD(DAY, 0, DATEDIFF(DAY, 0, @StartDate)) AS Date
    UNION ALL
    SELECT DATEADD(WEEK, 1, Date) AS Date
    FROM Dates
    WHERE Date < @EndDate
)
SELECT
    d.Date AS DateStart,
    DATEADD(DAY, -1, DATEADD(WEEK, 1, d.Date)) AS DateEnd
FROM Dates d
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetYearsBetween]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetYearsBetween]
(
	@StartDate DATE,
	@EndDate DATE
)
RETURNS TABLE AS RETURN
(
WITH Dates(Date) AS
(
    SELECT DATEADD(DAY, 0, DATEDIFF(DAY, 0, @StartDate)) AS Date
    UNION ALL
    SELECT DATEADD(YEAR, 1, Date) AS Date
    FROM Dates
    WHERE Date < @EndDate
)
SELECT
    d.Date AS DateStart,
	DATEADD(DAY, -1, DATEADD(YEAR, DATEDIFF(YEAR,0, d.Date) + 1, 0)) AS DateEnd
FROM Dates d
)
GO
/****** Object:  Table [dbo].[Album]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumId] [int] NOT NULL,
	[AlbumCoverID] [int] NOT NULL,
	[Description] [varchar](2000) NULL,
	[DateReleased] [date] NULL,
	[ProducerName] [varchar](100) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK__Album__97B4BE3754337554] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtistInfo]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistInfo](
	[UserId] [int] NOT NULL,
	[ArtistName] [varchar](100) NOT NULL,
	[Location] [varchar](100) NULL,
	[Bio] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtistPayment]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistPayment](
	[InvoiceNumber] [int] IDENTITY(1,1) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[TransactionFee] [smallmoney] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_ArtistPayment] PRIMARY KEY CLUSTERED 
(
	[InvoiceNumber] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileInfo]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileInfo](
	[FileId] [int] IDENTITY(1,1) NOT NULL,
	[FileTypeId] [int] NOT NULL,
	[FileName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__FileInfo__6F0F98BF2FC420B3] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileType]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileType](
	[FileTypeId] [int] IDENTITY(1,1) NOT NULL,
	[FileTypeName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__FileType__0896759E56391B6F] PRIMARY KEY CLUSTERED 
(
	[FileTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__FileType__2A63AD8418CAFF4C] UNIQUE NONCLUSTERED 
(
	[FileTypeName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Genre__0385057ED802D08F] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Genre__BBE1C33979EBEDE3] UNIQUE NONCLUSTERED 
(
	[GenreName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[AmountPaid] [smallmoney] NOT NULL,
	[PaymentProvider] [varchar](200) NOT NULL,
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[ProductStatusId] [int] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Product__B40CC6CDF7473743] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[ProductOrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ProductPrice] [smallmoney] NOT NULL,
 CONSTRAINT [PK_ProductOrder] PRIMARY KEY CLUSTERED 
(
	[ProductOrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPayment]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPayment](
	[InvoiceNumber] [int] NOT NULL,
	[ProductOrderId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStatus]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStatus](
	[ProductStatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__ProductS__2082058B1B11CDD2] PRIMARY KEY CLUSTERED 
(
	[ProductStatusId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__ProductS__05E7698A804BD1C4] UNIQUE NONCLUSTERED 
(
	[StatusName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ProductTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__ProductT__A1312F6E48DFB32F] PRIMARY KEY CLUSTERED 
(
	[ProductTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__ProductT__D4E7DFA8763B4CFA] UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[TrackId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[TrackFileID] [int] NOT NULL,
	[ClipFileID] [int] NOT NULL,
	[TrackDuration] [time](7) NOT NULL,
	[Description] [varchar](2000) NULL,
	[ClipDuration] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCart]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCart](
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](100) NOT NULL,
 CONSTRAINT [PK__UserType__40D2D816BFC19BA0] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__UserType__D4E7DFA8CCCA9926] UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK__Album__AlbumCove__114A936A] FOREIGN KEY([AlbumCoverID])
REFERENCES [dbo].[FileInfo] ([FileId])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK__Album__AlbumCove__114A936A]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK__Album__AlbumId__123EB7A3] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK__Album__AlbumId__123EB7A3]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_UserInfo] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfo] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_UserInfo]
GO
ALTER TABLE [dbo].[ArtistInfo]  WITH CHECK ADD  CONSTRAINT [FK__CreatorIn__UserI__1332DBDC] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfo] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ArtistInfo] CHECK CONSTRAINT [FK__CreatorIn__UserI__1332DBDC]
GO
ALTER TABLE [dbo].[ArtistPayment]  WITH CHECK ADD  CONSTRAINT [FK_ArtistPayment_ArtistInfo_UserId_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[ArtistInfo] ([UserId])
GO
ALTER TABLE [dbo].[ArtistPayment] CHECK CONSTRAINT [FK_ArtistPayment_ArtistInfo_UserId_ArtistId]
GO
ALTER TABLE [dbo].[FileInfo]  WITH CHECK ADD  CONSTRAINT [FK__FileInfo__FileTy__14270015] FOREIGN KEY([FileTypeId])
REFERENCES [dbo].[FileType] ([FileTypeId])
GO
ALTER TABLE [dbo].[FileInfo] CHECK CONSTRAINT [FK__FileInfo__FileTy__14270015]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_UserInfo_UserId_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[UserInfo] ([UserId])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_UserInfo_UserId_CustomerId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Product__151B244E] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductType] ([ProductTypeId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Product__151B244E]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Product__160F4887] FOREIGN KEY([ProductStatusId])
REFERENCES [dbo].[ProductStatus] ([ProductStatusId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Product__160F4887]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_OrderInfo_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([OrderId])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_OrderInfo_OrderId]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_Product_ProductId]
GO
ALTER TABLE [dbo].[ProductPayment]  WITH CHECK ADD  CONSTRAINT [FK_ProductPayment_ArtistPayment_InvoiceNumber] FOREIGN KEY([InvoiceNumber])
REFERENCES [dbo].[ArtistPayment] ([InvoiceNumber])
GO
ALTER TABLE [dbo].[ProductPayment] CHECK CONSTRAINT [FK_ProductPayment_ArtistPayment_InvoiceNumber]
GO
ALTER TABLE [dbo].[ProductPayment]  WITH CHECK ADD  CONSTRAINT [FK_ProductPayment_ProductOrder_ProductOrderId] FOREIGN KEY([ProductOrderId])
REFERENCES [dbo].[ProductOrder] ([ProductOrderId])
GO
ALTER TABLE [dbo].[ProductPayment] CHECK CONSTRAINT [FK_ProductPayment_ProductOrder_ProductOrderId]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK__Track__AlbumId__17036CC0] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK__Track__AlbumId__17036CC0]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK__Track__ClipFileI__17F790F9] FOREIGN KEY([ClipFileID])
REFERENCES [dbo].[FileInfo] ([FileId])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK__Track__ClipFileI__17F790F9]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK__Track__GenreId__18EBB532] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([GenreId])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK__Track__GenreId__18EBB532]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK__Track__TrackFile__19DFD96B] FOREIGN KEY([TrackFileID])
REFERENCES [dbo].[FileInfo] ([FileId])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK__Track__TrackFile__19DFD96B]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK__Track__TrackId__1AD3FDA4] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK__Track__TrackId__1AD3FDA4]
GO
ALTER TABLE [dbo].[UserCart]  WITH CHECK ADD  CONSTRAINT [FK__UserCart__Produc__1EA48E88] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[UserCart] CHECK CONSTRAINT [FK__UserCart__Produc__1EA48E88]
GO
ALTER TABLE [dbo].[UserCart]  WITH CHECK ADD  CONSTRAINT [FK__UserCart__UserId__1F98B2C1] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfo] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCart] CHECK CONSTRAINT [FK__UserCart__UserId__1F98B2C1]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK__UserInfo__Profil__208CD6FA] FOREIGN KEY([ProfileImageId])
REFERENCES [dbo].[FileInfo] ([FileId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK__UserInfo__Profil__208CD6FA]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK__UserInfo__UserSt__2180FB33] FOREIGN KEY([UserStatusId])
REFERENCES [dbo].[UserStatus] ([UserStatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK__UserInfo__UserSt__2180FB33]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK__UserInfo__UserTy__22751F6C] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([UserTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK__UserInfo__UserTy__22751F6C]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 3/22/2021 12:23:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
ALTER DATABASE [lokalmusic-db] SET  READ_WRITE 
GO
