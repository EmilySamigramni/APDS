CREATE DATABASE AgriEnergyConnect;



CREATE TABLE Farmers (
    FarmerID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255),
    ContactInfo NVARCHAR(255)
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    FarmerID INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(100),
    ProductionDate DATE,
    FOREIGN KEY (FarmerID) REFERENCES Farmers(FarmerID)
);

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('Farmer', 'Employee'))
);

CREATE TABLE TheProducts (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    FarmerId INT NOT NULL,
);


INSERT INTO Farmers (Name, Location, ContactInfo)
VALUES
('John Doe', 'Farmville', 'john.doe@example.com'),
('Jane Smith', 'Greenville', 'jane.smith@example.com'),
('Emily Johnson', 'Countryside', 'emily.johnson@example.com');

INSERT INTO Products (FarmerID, Name, Category, ProductionDate)
VALUES
(1, 'Organic Apples', 'Fruit', '2023-05-15'),
(1, 'Carrots', 'Vegetable', '2023-06-10'),
(2, 'Free-range Eggs', 'Poultry', '2023-06-05'),
(3, 'Wheat', 'Grain', '2023-07-20');

INSERT INTO Users (Username, PasswordHash, Role)
VALUES
('farmer1', 'hashed_password1', 'Farmer'),
('farmer2', 'hashed_password2', 'Farmer'),
('employee1', 'hashed_password3', 'Employee');

SELECT * FROM [dbo].[AspNetUsers];

CREATE TABLE NewProd (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);

CREATE TABLE ProductsTable (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);
