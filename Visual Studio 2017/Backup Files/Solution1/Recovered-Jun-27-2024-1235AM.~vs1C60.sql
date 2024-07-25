CREATE DATABASE EmilyAgriEnergy;


-- Create Farmers table
CREATE TABLE Farmers (
    FarmerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Location NVARCHAR(100),
    RegistrationDate DATE NOT NULL DEFAULT GETDATE()
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    FarmerID INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50),
    ProductionDate DATE,
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2),
    AvailableQuantity INT,
    CONSTRAINT FK_FarmerID FOREIGN KEY (FarmerID) REFERENCES Farmers(FarmerID)
);

-- Create AspNetUsers table for ASP.NET Identity
CREATE TABLE AspNetUsers (
    Id NVARCHAR(128) PRIMARY KEY,
    UserName NVARCHAR(256),
    NormalizedUserName NVARCHAR(256),
    Email NVARCHAR(256),
    NormalizedEmail NVARCHAR(256),
    EmailConfirmed BIT,
    PasswordHash NVARCHAR(MAX),
    SecurityStamp NVARCHAR(MAX),
    ConcurrencyStamp NVARCHAR(MAX),
    PhoneNumber NVARCHAR(20),
    PhoneNumberConfirmed BIT,
    TwoFactorEnabled BIT,
    LockoutEnd DATETIMEOFFSET(7),
    LockoutEnabled BIT,
    AccessFailedCount INT,
    Discriminator NVARCHAR(128) NOT NULL
);
