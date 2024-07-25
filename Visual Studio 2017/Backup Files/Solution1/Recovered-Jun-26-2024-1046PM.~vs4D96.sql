-- Use the newly created database
USE AgriDb;

-- Create Farmers table
CREATE TABLE Farmers (
    Id INT PRIMARY KEY IDENTITY,
    UserId NVARCHAR(450) NOT NULL,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    ContactNumber NVARCHAR(20),
    Location NVARCHAR(200),
    CONSTRAINT FK_Farmers_AspNetUsers FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);

-- Create Products table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    FarmerId INT NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Category NVARCHAR(100),
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2),
    AvailableQuantity INT,
    CONSTRAINT FK_Products_Farmers FOREIGN KEY (FarmerId) REFERENCES Farmers(Id)
);

-- Create Green Energy Solutions table (Optional)
CREATE TABLE GreenEnergySolutions (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Category NVARCHAR(100),
    Price DECIMAL(18, 2)
);

-- Create Collaboration Projects table (Optional)
CREATE TABLE CollaborationProjects (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    StartDate DATE,
    EndDate DATE,
    Status NVARCHAR(50)
);

-- Add additional tables as needed for your specific requirements

-- Commit the changes
COMMIT;
