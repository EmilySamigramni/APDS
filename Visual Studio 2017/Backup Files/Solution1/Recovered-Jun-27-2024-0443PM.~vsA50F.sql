Create Database TheAgri;

CREATE TABLE Farmers (
    FarmerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    FarmerID INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50),
    ProductionDate DATE,
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2) NOT NULL,
    AvailableQuantity INT NOT NULL,
    CONSTRAINT FK_Products_Farmers FOREIGN KEY (FarmerID) REFERENCES Farmers(FarmerID)
);

