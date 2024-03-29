/****** Object:  Database [lokalmusic-backend]    Script Date: 3/22/2021 12:17:01 PM ******/
CREATE DATABASE [lokalmusic-backend]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [lokalmusic-backend] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [lokalmusic-backend] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET ARITHABORT OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lokalmusic-backend] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lokalmusic-backend] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [lokalmusic-backend] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lokalmusic-backend] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [lokalmusic-backend] SET  MULTI_USER 
GO
ALTER DATABASE [lokalmusic-backend] SET ENCRYPTION ON
GO
ALTER DATABASE [lokalmusic-backend] SET QUERY_STORE = ON
GO
ALTER DATABASE [lokalmusic-backend] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Album]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumId] [int] NOT NULL,
	[ProducerFirstName] [varchar](128) NOT NULL,
	[ProducerLastName] [varchar](128) NOT NULL,
	[DateReleased] [datetime] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[AlbumId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](128) NOT NULL,
	[LastName] [varchar](128) NOT NULL,
	[ArtistName] [varchar](128) NOT NULL,
	[ArtistBio] [varchar](256) NOT NULL,
	[StreetAddress] [varchar](256) NOT NULL,
	[City] [varchar](128) NOT NULL,
	[Province] [varchar](128) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[PayPalEmail] [varchar](128) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ArtistId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtistPayment]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistPayment](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[TransactionFee] [smallmoney] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[NetTotal] [smallmoney] NOT NULL,
 CONSTRAINT [PK_ArtistPayment] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__ArtistPa__D796AAB4A491F00C] UNIQUE NONCLUSTERED 
(
	[InvoiceId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](128) NOT NULL,
	[LastName] [varchar](128) NOT NULL,
	[Email] [varchar](128) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CustomerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](128) NOT NULL,
	[LastName] [varchar](128) NOT NULL,
	[PositionId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AmountPaid] [smallmoney] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[PaymentProvider] [varchar](128) NOT NULL,
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [varchar](64) NOT NULL,
	[ManagedBy] [int] NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](128) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[ListingPrice] [smallmoney] NOT NULL,
	[ProductType] [varchar](12) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[ProductOrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[AmountSoldFor] [smallmoney] NOT NULL,
 CONSTRAINT [PK_ProductOrder] PRIMARY KEY CLUSTERED 
(
	[ProductOrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ProductOrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPayment]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPayment](
	[InvoiceId] [int] NOT NULL,
	[ProductOrderId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[TrackId] [int] NOT NULL,
	[Genre] [varchar](64) NOT NULL,
	[TrackFileName] [varchar](256) NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TrackId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TrackFileName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WithdrawnArtist]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WithdrawnArtist](
	[ArtistId] [int] NOT NULL,
	[WithdrawalDate] [datetime] NOT NULL,
	[Reason] [varchar](256) NOT NULL,
 CONSTRAINT [PK_WithdrawnArtist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ArtistId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WithdrawnProduct]    Script Date: 3/22/2021 12:17:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WithdrawnProduct](
	[ProductId] [int] NOT NULL,
	[WithdrawalDate] [datetime] NOT NULL,
	[Reason] [varchar](255) NOT NULL,
 CONSTRAINT [PK_WithdrawnProduct_1] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Withdraw__B40CC6CCA7E11C95] UNIQUE NONCLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Album] ADD  DEFAULT ('') FOR [ProducerFirstName]
GO
ALTER TABLE [dbo].[Album] ADD  DEFAULT ('') FOR [ProducerLastName]
GO
ALTER TABLE [dbo].[Artist] ADD  DEFAULT ('') FOR [ArtistBio]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ('') FOR [Genre]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Product] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Product]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Customer]
GO
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [FK_Position_Position] FOREIGN KEY([ManagedBy])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [FK_Position_Position]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Artist]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_OrderInfo] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([OrderId])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_OrderInfo]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_Product]
GO
ALTER TABLE [dbo].[ProductPayment]  WITH CHECK ADD  CONSTRAINT [FK_ProductPayment_ArtistPayment] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[ArtistPayment] ([InvoiceId])
GO
ALTER TABLE [dbo].[ProductPayment] CHECK CONSTRAINT [FK_ProductPayment_ArtistPayment]
GO
ALTER TABLE [dbo].[ProductPayment]  WITH CHECK ADD  CONSTRAINT [FK_ProductPayment_ProductOrder] FOREIGN KEY([ProductOrderId])
REFERENCES [dbo].[ProductOrder] ([ProductOrderId])
GO
ALTER TABLE [dbo].[ProductPayment] CHECK CONSTRAINT [FK_ProductPayment_ProductOrder]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Album]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Product] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Product]
GO
ALTER TABLE [dbo].[WithdrawnArtist]  WITH CHECK ADD  CONSTRAINT [FK_WithdrawnArtist_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])
GO
ALTER TABLE [dbo].[WithdrawnArtist] CHECK CONSTRAINT [FK_WithdrawnArtist_Artist]
GO
ALTER TABLE [dbo].[WithdrawnProduct]  WITH CHECK ADD  CONSTRAINT [FK_WithdrawnProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[WithdrawnProduct] CHECK CONSTRAINT [FK_WithdrawnProduct_Product]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD CHECK  (([DateReleased]<=getdate()))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  ((len([ArtistName])>(0)))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  ((len([City])>(0)))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  (([Email] like '_%@_%._%'))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  ((len([FirstName])>(0)))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  ((len([LastName])>(0)))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  (([PayPalEmail] like '_%@_%._%'))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  ((len([Province])>(0)))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  (([RegistrationDate]<=getdate()))
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD CHECK  ((len([StreetAddress])>(0)))
GO
ALTER TABLE [dbo].[ArtistPayment]  WITH CHECK ADD CHECK  (([NetTotal]>(0)))
GO
ALTER TABLE [dbo].[ArtistPayment]  WITH CHECK ADD  CONSTRAINT [CK__ArtistPay__Payme__73501C2F] CHECK  (([PaymentDate]<=getdate()))
GO
ALTER TABLE [dbo].[ArtistPayment] CHECK CONSTRAINT [CK__ArtistPay__Payme__73501C2F]
GO
ALTER TABLE [dbo].[ArtistPayment]  WITH CHECK ADD  CONSTRAINT [CK__ArtistPay__Trans__725BF7F6] CHECK  (([TransactionFee]>(0)))
GO
ALTER TABLE [dbo].[ArtistPayment] CHECK CONSTRAINT [CK__ArtistPay__Trans__725BF7F6]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD CHECK  (([Email] like '_%@_%._%'))
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD CHECK  ((len([FirstName])>(0)))
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD CHECK  ((len([LastName])>(0)))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  ((len([FirstName])>(0)))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  ((len([LastName])>(0)))
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD CHECK  (([AmountPaid]>(0)))
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD CHECK  (([OrderDate]<=getdate()))
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD CHECK  ((len([PaymentProvider])>(0)))
GO
ALTER TABLE [dbo].[Position]  WITH CHECK ADD CHECK  ((len([PositionName])>(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([DateAdded]<=getdate()))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([ListingPrice]>(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  ((len([ProductName])>(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([ProductType]='Track' OR [ProductType]='Album'))
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD CHECK  (([AmountSoldFor]>(0)))
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD CHECK  ((len([TrackFileName])>(0)))
GO
ALTER TABLE [dbo].[WithdrawnArtist]  WITH CHECK ADD CHECK  ((len([Reason])>(0)))
GO
ALTER TABLE [dbo].[WithdrawnArtist]  WITH CHECK ADD CHECK  (([WithdrawalDate]<=getdate()))
GO
ALTER TABLE [dbo].[WithdrawnProduct]  WITH CHECK ADD  CONSTRAINT [CK__Withdrawn__Reaso__02925FBF] CHECK  ((len([Reason])>(0)))
GO
ALTER TABLE [dbo].[WithdrawnProduct] CHECK CONSTRAINT [CK__Withdrawn__Reaso__02925FBF]
GO
ALTER TABLE [dbo].[WithdrawnProduct]  WITH CHECK ADD  CONSTRAINT [CK__Withdrawn__Withd__019E3B86] CHECK  (([WithdrawalDate]<=getdate()))
GO
ALTER TABLE [dbo].[WithdrawnProduct] CHECK CONSTRAINT [CK__Withdrawn__Withd__019E3B86]
GO
ALTER DATABASE [lokalmusic-backend] SET  READ_WRITE 
GO
