IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Properties] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Location] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [PricePerNight] decimal(18,2) NOT NULL,
    [PricePerHour] decimal(18,2) NOT NULL,
    [TotalSpots] int NOT NULL,
    [Bedrooms] int NOT NULL,
    [Bathrooms] int NOT NULL,
    [Rating] float NOT NULL,
    [HasSmartParking] bit NOT NULL,
    [ImageUrl] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Properties] PRIMARY KEY ([Id])
);

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [Email] nvarchar(450) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NULL,
    [CarPlateNumber] nvarchar(max) NULL,
    [AccountType] nvarchar(max) NOT NULL,
    [Role] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

CREATE TABLE [ParkingSpots] (
    [Id] int NOT NULL IDENTITY,
    [SpotNumber] nvarchar(max) NOT NULL,
    [Zone] nvarchar(max) NULL,
    [Location] nvarchar(max) NULL,
    [Status] nvarchar(max) NOT NULL,
    [PricePerHour] decimal(18,2) NOT NULL,
    [PricePerNight] decimal(18,2) NOT NULL,
    [PropertyId] int NOT NULL,
    CONSTRAINT [PK_ParkingSpots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ParkingSpots_Properties_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Properties] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Reservations] (
    [Id] int NOT NULL IDENTITY,
    [ParkingSpotId] int NOT NULL,
    [PropertyId] int NOT NULL,
    [UserId] int NOT NULL,
    [CarPlateNumber] nvarchar(max) NULL,
    [StartTime] datetime2 NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [TotalPrice] decimal(18,2) NOT NULL,
    [QrCodeData] nvarchar(max) NULL,
    [Status] nvarchar(max) NOT NULL,
    [BookingType] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UserEmail] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservations_ParkingSpots_ParkingSpotId] FOREIGN KEY ([ParkingSpotId]) REFERENCES [ParkingSpots] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reservations_Properties_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Properties] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reservations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bathrooms', N'Bedrooms', N'CreatedAt', N'Description', N'HasSmartParking', N'ImageUrl', N'Location', N'Name', N'Price', N'PricePerHour', N'PricePerNight', N'Rating', N'Title', N'TotalSpots') AND [object_id] = OBJECT_ID(N'[Properties]'))
    SET IDENTITY_INSERT [Properties] ON;
INSERT INTO [Properties] ([Id], [Bathrooms], [Bedrooms], [CreatedAt], [Description], [HasSmartParking], [ImageUrl], [Location], [Name], [Price], [PricePerHour], [PricePerNight], [Rating], [Title], [TotalSpots])
VALUES (1, 3, 4, '2026-04-30T00:00:00.0000000', N'Smart Villa with private parking', CAST(1 AS bit), N'https://images.unsplash.com/photo-1506521781263-d8422e82f27a', N'Beverly Hills, Cairo', N'Luxury Modern Villa', 1250.0, 150.0, 1250.0, 4.9000000000000004E0, N'Luxury Modern Villa', 90);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bathrooms', N'Bedrooms', N'CreatedAt', N'Description', N'HasSmartParking', N'ImageUrl', N'Location', N'Name', N'Price', N'PricePerHour', N'PricePerNight', N'Rating', N'Title', N'TotalSpots') AND [object_id] = OBJECT_ID(N'[Properties]'))
    SET IDENTITY_INSERT [Properties] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'PricePerHour', N'PricePerNight', N'PropertyId', N'SpotNumber', N'Status', N'Zone') AND [object_id] = OBJECT_ID(N'[ParkingSpots]'))
    SET IDENTITY_INSERT [ParkingSpots] ON;
INSERT INTO [ParkingSpots] ([Id], [Location], [PricePerHour], [PricePerNight], [PropertyId], [SpotNumber], [Status], [Zone])
VALUES (1, N'Ground Floor', 5.0, 50.0, 1, N'A1', N'Available', N'A'),
(2, N'Ground Floor', 5.0, 50.0, 1, N'A2', N'Available', N'A'),
(3, N'Ground Floor', 5.0, 50.0, 1, N'A3', N'Available', N'A'),
(4, N'Ground Floor', 5.0, 50.0, 1, N'A4', N'Available', N'A'),
(5, N'Ground Floor', 5.0, 50.0, 1, N'A5', N'Available', N'A'),
(6, N'Ground Floor', 5.0, 50.0, 1, N'A6', N'Available', N'A'),
(7, N'Ground Floor', 5.0, 50.0, 1, N'A7', N'Available', N'A'),
(8, N'Ground Floor', 5.0, 50.0, 1, N'A8', N'Available', N'A'),
(9, N'Ground Floor', 5.0, 50.0, 1, N'A9', N'Available', N'A'),
(10, N'Ground Floor', 5.0, 50.0, 1, N'A10', N'Available', N'A'),
(11, N'Ground Floor', 5.0, 50.0, 1, N'A11', N'Available', N'A'),
(12, N'Ground Floor', 5.0, 50.0, 1, N'A12', N'Available', N'A'),
(13, N'Ground Floor', 5.0, 50.0, 1, N'A13', N'Available', N'A'),
(14, N'Ground Floor', 5.0, 50.0, 1, N'A14', N'Available', N'A'),
(15, N'Ground Floor', 5.0, 50.0, 1, N'A15', N'Available', N'A'),
(16, N'Ground Floor', 5.0, 50.0, 1, N'A16', N'Available', N'A'),
(17, N'Ground Floor', 5.0, 50.0, 1, N'A17', N'Available', N'A'),
(18, N'Ground Floor', 5.0, 50.0, 1, N'A18', N'Available', N'A'),
(19, N'Ground Floor', 5.0, 50.0, 1, N'A19', N'Available', N'A'),
(20, N'Ground Floor', 5.0, 50.0, 1, N'A20', N'Available', N'A'),
(21, N'Ground Floor', 5.0, 50.0, 1, N'A21', N'Available', N'A'),
(22, N'Ground Floor', 5.0, 50.0, 1, N'A22', N'Available', N'A'),
(23, N'Ground Floor', 5.0, 50.0, 1, N'A23', N'Available', N'A'),
(24, N'Ground Floor', 5.0, 50.0, 1, N'A24', N'Available', N'A'),
(25, N'Ground Floor', 5.0, 50.0, 1, N'A25', N'Available', N'A'),
(26, N'Ground Floor', 5.0, 50.0, 1, N'A26', N'Available', N'A'),
(27, N'Ground Floor', 5.0, 50.0, 1, N'A27', N'Available', N'A'),
(28, N'Ground Floor', 5.0, 50.0, 1, N'A28', N'Available', N'A'),
(29, N'Ground Floor', 5.0, 50.0, 1, N'A29', N'Available', N'A'),
(30, N'Ground Floor', 5.0, 50.0, 1, N'A30', N'Available', N'A'),
(31, N'First Floor', 10.0, 80.0, 1, N'B1', N'Available', N'B'),
(32, N'First Floor', 10.0, 80.0, 1, N'B2', N'Available', N'B'),
(33, N'First Floor', 10.0, 80.0, 1, N'B3', N'Available', N'B'),
(34, N'First Floor', 10.0, 80.0, 1, N'B4', N'Available', N'B'),
(35, N'First Floor', 10.0, 80.0, 1, N'B5', N'Available', N'B'),
(36, N'First Floor', 10.0, 80.0, 1, N'B6', N'Available', N'B'),
(37, N'First Floor', 10.0, 80.0, 1, N'B7', N'Available', N'B'),
(38, N'First Floor', 10.0, 80.0, 1, N'B8', N'Available', N'B'),
(39, N'First Floor', 10.0, 80.0, 1, N'B9', N'Available', N'B'),
(40, N'First Floor', 10.0, 80.0, 1, N'B10', N'Available', N'B'),
(41, N'First Floor', 10.0, 80.0, 1, N'B11', N'Available', N'B'),
(42, N'First Floor', 10.0, 80.0, 1, N'B12', N'Available', N'B');
INSERT INTO [ParkingSpots] ([Id], [Location], [PricePerHour], [PricePerNight], [PropertyId], [SpotNumber], [Status], [Zone])
VALUES (43, N'First Floor', 10.0, 80.0, 1, N'B13', N'Available', N'B'),
(44, N'First Floor', 10.0, 80.0, 1, N'B14', N'Available', N'B'),
(45, N'First Floor', 10.0, 80.0, 1, N'B15', N'Available', N'B'),
(46, N'First Floor', 10.0, 80.0, 1, N'B16', N'Available', N'B'),
(47, N'First Floor', 10.0, 80.0, 1, N'B17', N'Available', N'B'),
(48, N'First Floor', 10.0, 80.0, 1, N'B18', N'Available', N'B'),
(49, N'First Floor', 10.0, 80.0, 1, N'B19', N'Available', N'B'),
(50, N'First Floor', 10.0, 80.0, 1, N'B20', N'Available', N'B'),
(51, N'First Floor', 10.0, 80.0, 1, N'B21', N'Available', N'B'),
(52, N'First Floor', 10.0, 80.0, 1, N'B22', N'Available', N'B'),
(53, N'First Floor', 10.0, 80.0, 1, N'B23', N'Available', N'B'),
(54, N'First Floor', 10.0, 80.0, 1, N'B24', N'Available', N'B'),
(55, N'First Floor', 10.0, 80.0, 1, N'B25', N'Available', N'B'),
(56, N'First Floor', 10.0, 80.0, 1, N'B26', N'Available', N'B'),
(57, N'First Floor', 10.0, 80.0, 1, N'B27', N'Available', N'B'),
(58, N'First Floor', 10.0, 80.0, 1, N'B28', N'Available', N'B'),
(59, N'First Floor', 10.0, 80.0, 1, N'B29', N'Available', N'B'),
(60, N'First Floor', 10.0, 80.0, 1, N'B30', N'Available', N'B'),
(61, N'VIP Section', 15.0, 120.0, 1, N'C1', N'Available', N'C'),
(62, N'VIP Section', 15.0, 120.0, 1, N'C2', N'Available', N'C'),
(63, N'VIP Section', 15.0, 120.0, 1, N'C3', N'Available', N'C'),
(64, N'VIP Section', 15.0, 120.0, 1, N'C4', N'Available', N'C'),
(65, N'VIP Section', 15.0, 120.0, 1, N'C5', N'Available', N'C'),
(66, N'VIP Section', 15.0, 120.0, 1, N'C6', N'Available', N'C'),
(67, N'VIP Section', 15.0, 120.0, 1, N'C7', N'Available', N'C'),
(68, N'VIP Section', 15.0, 120.0, 1, N'C8', N'Available', N'C'),
(69, N'VIP Section', 15.0, 120.0, 1, N'C9', N'Available', N'C'),
(70, N'VIP Section', 15.0, 120.0, 1, N'C10', N'Available', N'C'),
(71, N'VIP Section', 15.0, 120.0, 1, N'C11', N'Available', N'C'),
(72, N'VIP Section', 15.0, 120.0, 1, N'C12', N'Available', N'C'),
(73, N'VIP Section', 15.0, 120.0, 1, N'C13', N'Available', N'C'),
(74, N'VIP Section', 15.0, 120.0, 1, N'C14', N'Available', N'C'),
(75, N'VIP Section', 15.0, 120.0, 1, N'C15', N'Available', N'C'),
(76, N'VIP Section', 15.0, 120.0, 1, N'C16', N'Available', N'C'),
(77, N'VIP Section', 15.0, 120.0, 1, N'C17', N'Available', N'C'),
(78, N'VIP Section', 15.0, 120.0, 1, N'C18', N'Available', N'C'),
(79, N'VIP Section', 15.0, 120.0, 1, N'C19', N'Available', N'C'),
(80, N'VIP Section', 15.0, 120.0, 1, N'C20', N'Available', N'C'),
(81, N'VIP Section', 15.0, 120.0, 1, N'C21', N'Available', N'C'),
(82, N'VIP Section', 15.0, 120.0, 1, N'C22', N'Available', N'C'),
(83, N'VIP Section', 15.0, 120.0, 1, N'C23', N'Available', N'C'),
(84, N'VIP Section', 15.0, 120.0, 1, N'C24', N'Available', N'C');
INSERT INTO [ParkingSpots] ([Id], [Location], [PricePerHour], [PricePerNight], [PropertyId], [SpotNumber], [Status], [Zone])
VALUES (85, N'VIP Section', 15.0, 120.0, 1, N'C25', N'Available', N'C'),
(86, N'VIP Section', 15.0, 120.0, 1, N'C26', N'Available', N'C'),
(87, N'VIP Section', 15.0, 120.0, 1, N'C27', N'Available', N'C'),
(88, N'VIP Section', 15.0, 120.0, 1, N'C28', N'Available', N'C'),
(89, N'VIP Section', 15.0, 120.0, 1, N'C29', N'Available', N'C'),
(90, N'VIP Section', 15.0, 120.0, 1, N'C30', N'Available', N'C');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'PricePerHour', N'PricePerNight', N'PropertyId', N'SpotNumber', N'Status', N'Zone') AND [object_id] = OBJECT_ID(N'[ParkingSpots]'))
    SET IDENTITY_INSERT [ParkingSpots] OFF;

CREATE INDEX [IX_ParkingSpots_PropertyId] ON [ParkingSpots] ([PropertyId]);

CREATE INDEX [IX_Reservations_ParkingSpotId] ON [Reservations] ([ParkingSpotId]);

CREATE INDEX [IX_Reservations_PropertyId] ON [Reservations] ([PropertyId]);

CREATE INDEX [IX_Reservations_UserId] ON [Reservations] ([UserId]);

CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260430225621_InitialCreate', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
ALTER TABLE [Users] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260430230133_AddCreatedAtToUser', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260503204208_UpdateReservationSystem', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260503204334_SyncReservationLogic', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260503204452_UpdateQrAndReservation', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260503204601_UpdateReservationSchema', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260503204854_IncreaseQrSize', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var nvarchar(max);
SELECT @var = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservations]') AND [c].[name] = N'UserEmail');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Reservations] DROP CONSTRAINT ' + @var + ';');
ALTER TABLE [Reservations] DROP COLUMN [UserEmail];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260503213633_UpdateReservationSchemaFinal', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260503224816_UpdateModelsForNewUI', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260512170826_AddPaymentsTable', N'10.0.7');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260512172952_FixReservationNullableId', N'10.0.7');

COMMIT;
GO

