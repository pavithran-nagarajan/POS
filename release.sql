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
    WHERE [MigrationId] = N'20260728130109_CreateTableUserAccount'
)
BEGIN
    CREATE TABLE [user_account] (
        [user_id] int NOT NULL IDENTITY,
        [company_id] int NOT NULL,
        [user_name] varchar(50) NOT NULL,
        [password_hash] varchar(256) NOT NULL,
        [user_pin_hash] varchar(256) NOT NULL,
        [bit_super_admin] bit NOT NULL DEFAULT CAST(0 AS bit),
        [staff_name] nvarchar(100) NULL,
        [email_address] varchar(254) NULL,
        [mobile_no_country_code] varchar(4) NULL,
        [mobile_no] varchar(15) NULL,
        [bit_blocked] bit NOT NULL DEFAULT CAST(0 AS bit),
        [bit_active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [created_by] int NOT NULL,
        [create_datetime] datetime2 NOT NULL,
        [modified_by] int NULL,
        [modified_datetime] datetime2 NULL,
        CONSTRAINT [PK_user_account] PRIMARY KEY ([user_id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260728130109_CreateTableUserAccount'
)
BEGIN
    CREATE INDEX [ix_user_account_company_id] ON [user_account] ([company_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260728130109_CreateTableUserAccount'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260728130109_CreateTableUserAccount', N'10.0.10');
END;

COMMIT;
GO

