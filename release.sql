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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260727150504_CreateTableUserAccount'
)
BEGIN
    CREATE TABLE [User_Account] (
        [User_ID] bigint NOT NULL IDENTITY,
        [User_ID_GUID] uniqueidentifier NOT NULL,
        [User_Name] nvarchar(50) NOT NULL,
        [Password_Hash] nvarchar(256) NOT NULL,
        [User_PIN_Hash] nvarchar(256) NOT NULL,
        [Bit_Super_Admin] bit NOT NULL DEFAULT CAST(0 AS bit),
        [Staff_Name] nvarchar(100) NOT NULL,
        [Email_Address] nvarchar(254) NOT NULL,
        [Mobile_No_Country_Code] nvarchar(4) NOT NULL,
        [Mobile_No] nvarchar(15) NOT NULL,
        [Bit_Blocked] bit NOT NULL DEFAULT CAST(0 AS bit),
        [Bit_Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [Created_By] bigint NOT NULL,
        [Created_DateTime] datetime2 NOT NULL,
        [Modified_By] bigint NULL,
        [Modified_DateTime] datetime2 NULL,
        CONSTRAINT [PK_User_Account] PRIMARY KEY ([User_ID])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260727150504_CreateTableUserAccount'
)
BEGIN
    CREATE UNIQUE INDEX [IX_User_Account_User_ID_GUID] ON [User_Account] ([User_ID_GUID]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260727150504_CreateTableUserAccount'
)
BEGIN
    CREATE UNIQUE INDEX [IX_User_Account_User_Name] ON [User_Account] ([User_Name]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260727150504_CreateTableUserAccount'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260727150504_CreateTableUserAccount', N'10.0.10');
END;

COMMIT;
GO

