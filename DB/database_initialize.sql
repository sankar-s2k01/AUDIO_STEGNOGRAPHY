-- Drop existing tables if they exist
IF OBJECT_ID('dbo.AudioFiles', 'U') IS NOT NULL
    DROP TABLE dbo.AudioFiles;

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;

-- Create Users table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Create AudioFiles table
CREATE TABLE AudioFiles (
    AudioFileId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    FileName NVARCHAR(255) NOT NULL,
    FileData VARBINARY(MAX) NOT NULL,
    AuthorMessage NVARCHAR(MAX),
    Password NVARCHAR(255),
    CreatedAt DATETIME NOT NULL
);


