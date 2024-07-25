
-- Create Database
CREATE DATABASE EmsFinalPoeDb;

-- Create Farmers Table
CREATE TABLE Farmers (
    FarmerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL
);
GO

-- Create Products Table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    FarmerID INT NOT NULL,
    FOREIGN KEY (FarmerID) REFERENCES Farmers(FarmerID)
);
GO

-- Create Employees Table
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL
);
GO

-- Create ASP.NET Identity Tables
-- Create table for ASP.NET Identity users
CREATE TABLE AspNetUsers (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    UserName NVARCHAR(50) NULL,
    NormalizedUserName NVARCHAR(50) NULL,
    Email NVARCHAR(50) NULL,
    NormalizedEmail NVARCHAR(50) NULL,
    EmailConfirmed BIT NOT NULL,
    PasswordHash NVARCHAR(MAX) NULL,
    SecurityStamp NVARCHAR(MAX) NULL,
    ConcurrencyStamp NVARCHAR(MAX) NULL,
    PhoneNumber NVARCHAR(MAX) NULL,
    PhoneNumberConfirmed BIT NOT NULL,
    TwoFactorEnabled BIT NOT NULL,
    LockoutEnd DATETIMEOFFSET NULL,
    LockoutEnabled BIT NOT NULL,
    AccessFailedCount INT NOT NULL
);
GO

-- Create table for ASP.NET Identity roles
CREATE TABLE AspNetRoles (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50) NULL,
    NormalizedName NVARCHAR(256) NULL,
    ConcurrencyStamp NVARCHAR(MAX) NULL
);
GO

-- Create table for ASP.NET Identity user claims
CREATE TABLE AspNetUserClaims (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX) NULL,
    ClaimValue NVARCHAR(MAX) NULL,
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);
GO

-- Create table for ASP.NET Identity user roles
CREATE TABLE AspNetUserRoles (
    UserId NVARCHAR(450) NOT NULL,
    RoleId NVARCHAR(450) NOT NULL,
    PRIMARY KEY (UserId, RoleId),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id)
);
GO

-- Create table for ASP.NET Identity role claims
CREATE TABLE AspNetRoleClaims (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    RoleId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX) NULL,
    ClaimValue NVARCHAR(MAX) NULL,
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id)
);
GO

-- Create table for ASP.NET Identity user logins
CREATE TABLE AspNetUserLogins (
    LoginProvider NVARCHAR(450) NOT NULL,
    ProviderKey NVARCHAR(450) NOT NULL,
    ProviderDisplayName NVARCHAR(MAX) NULL,
    UserId NVARCHAR(450) NOT NULL,
    PRIMARY KEY (LoginProvider, ProviderKey),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);
GO

-- Create table for ASP.NET Identity user tokens
CREATE TABLE AspNetUserTokens (
    UserId NVARCHAR(450) NOT NULL,
    LoginProvider NVARCHAR(450) NOT NULL,
    Name NVARCHAR(450) NOT NULL,
    Value NVARCHAR(MAX) NULL,
    PRIMARY KEY (UserId, LoginProvider, Name),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);
GO

-- Insert Initial Data
-- Insert initial farmers
INSERT INTO Farmers (FirstName, LastName, Email, PhoneNumber) VALUES ('John', 'Doe', 'john.doe@example.com', '1234567890');
INSERT INTO Farmers (FirstName, LastName, Email, PhoneNumber) VALUES ('Jane', 'Smith', 'jane.smith@example.com', '0987654321');
GO

-- Insert initial products
INSERT INTO Products (ProductName, Category, Price, FarmerID) VALUES ('Wheat', 'Grains', 100.00, 1);
INSERT INTO Products (ProductName, Category, Price, FarmerID) VALUES ('Corn', 'Grains', 50.00, 2);
GO

-- Insert initial employees
INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber) VALUES ('Alice', 'Johnson', 'alice.johnson@example.com', '1231231234');
INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber) VALUES ('Bob', 'Brown', 'bob.brown@example.com', '3213214321');
GO
