--01.Database Introduction - Exercise (13-15, 23-24)
--Exercise 13: Movies Database
CREATE DATABASE [Movies]

GO

USE [Movies]
CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(max)
)

CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY,
	[GenreName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(max)
)

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(max)
)

CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY,
	[Title] VARCHAR(50) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] DECIMAL(5,2) NOT NULL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] DECIMAL(5,2),
	[Notes] VARCHAR(max)
)

GO

INSERT INTO [Directors] ([Id], [DirectorName], [Notes])
VALUES
(1, 'Christopher Nolan', 'Known for complex storytelling'),
(2, 'Steven Spielberg', 'Legendary Hollywood director'),
(3, 'Quentin Tarantino', 'Famous for nonlinear plots'),
(4, 'Martin Scorsese', 'Crime and drama specialist'),
(5, 'James Cameron', 'Sci-fi and blockbuster films');

INSERT INTO [Genres] ([Id], [GenreName], [Notes])
VALUES
(1, 'Action', 'High energy films'),
(2, 'Drama', 'Emotional storytelling'),
(3, 'Comedy', 'Humor based movies'),
(4, 'Sci-Fi', 'Science fiction films'),
(5, 'Thriller', 'Suspense and tension');

INSERT INTO [Categories] ([Id], [CategoryName], [Notes])
VALUES
(1, 'Blockbuster', 'High budget films'),
(2, 'Indie', 'Independent productions'),
(3, 'Classic', 'Older well-known films'),
(4, 'Family', 'Suitable for all ages'),
(5, 'Horror', 'Scary movies');

INSERT INTO [Movies] 
([Id], [Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
(1, 'Inception', 1, 2010, 148.00, 4, 1, 8.80, 'Mind-bending sci-fi thriller'),
(2, 'Jurassic Park', 2, 1993, 127.00, 1, 1, 8.10, 'Dinosaurs brought to life'),
(3, 'Pulp Fiction', 3, 1994, 154.00, 2, 2, 8.90, 'Nonlinear crime story'),
(4, 'The Wolf of Wall Street', 4, 2013, 180.00, 2, 1, 8.20, 'Based on true story'),
(5, 'Avatar', 5, 2009, 162.00, 4, 1, 7.80, 'Sci-fi visual masterpiece');
GO
--Exercise 14: Car Rental Database
CREATE DATABASE [CarRental]

GO
USE [CarRental]

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY
	,
	[CategoryName] VARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(10,2) NOT NULL,
	[WeeklyRate] DECIMAL(10,2) NOT NULL,
	[MonthlyRate] DECIMAL(10,2) NOT NULL,
	[WeekendRate] DECIMAL(10,2) NOT NULL
)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY,
	[PlateNumber] VARCHAR(50) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(100) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] VARBINARY(max),
	[Condition] VARCHAR(50) NOT NULL,
	[Available] BIT NOT NULL
)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(100) NOT NULL,
	[Notes] VARCHAR(max)
)

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] VARCHAR(100) NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[City] VARCHAR(100) NOT NULL,
	[ZIPCode] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(max)
)

CREATE TABLE [RentalOrders] (
	[Id] INT PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[CarId] INT NOT NULL,
	[TankLevel] DECIMAL(5,2) NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[TaxRate] DECIMAL(5,2) NOT NULL,
	[OrderStatus] BIT NOT NULL,
	[Notes] VARCHAR(max),
)

GO

INSERT INTO [Categories]
VALUES
(1, 'Economy', 30.00, 180.00, 600.00, 50.00),
(2, 'Standard', 50.00, 300.00, 1000.00, 80.00),
(3, 'Luxury', 120.00, 700.00, 2500.00, 200.00);

INSERT INTO [Cars]
VALUES
(1, 'CA1234AA', 'Toyota', 'Corolla', 2018, 1, 4, NULL, 'Good', 1),
(2, 'CB5678BB', 'BMW', '320i', 2021, 2, 4, NULL, 'Excellent', 1),
(3, 'CC9999CC', 'Mercedes', 'S-Class', 2022, 3, 4, NULL, 'New', 0);

INSERT INTO [Employees]
VALUES
(1, 'Ivan', 'Petrov', 'Manager', 'Experienced employee'),
(2, 'Maria', 'Ivanova', 'Sales Rep', 'Handles customers'),
(3, 'Georgi', 'Dimitrov', 'Assistant', NULL);

INSERT INTO [Customers]
VALUES
(1, 123456789, 'Peter Ivanov', 'Sofia 12', 'Sofia', '1000', NULL),
(2, 987654321, 'Anna Georgieva', 'Plovdiv 5', 'Plovdiv', '4000', NULL),
(3, 555666777, 'Nikolay Stefanov', 'Varna 9', 'Varna', '9000', NULL);

INSERT INTO [RentalOrders]
VALUES
(1, 1, 1, 1, 0.80, 10000, 10500, 500, '2026-01-01', '2026-01-05', 4, 20.00, 1, 'Completed'),
(2, 2, 2, 2, 0.50, 20000, 20800, 800, '2026-02-01', '2026-02-07', 6, 20.00, 0, 'Active'),
(3, 3, 3, 3, 1.00, 30000, 30250, 250, '2026-03-01', '2026-03-03', 2, 20.00, 1, 'Finished');
GO
--Exercise 15: Hotel Database
CREATE DATABASE [Hotel]
GO

USE [Hotel]
GO

CREATE TABLE [Employees] (
    [Id] INT PRIMARY KEY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [Title] VARCHAR(100) NOT NULL,
    [Notes] VARCHAR(MAX)
);

CREATE TABLE [Customers] (
    [AccountNumber] INT PRIMARY KEY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(20),
    [EmergencyName] VARCHAR(100),
    [EmergencyNumber] VARCHAR(20),
    [Notes] VARCHAR(MAX)
);

CREATE TABLE [RoomStatus] (
    [RoomStatus] VARCHAR(50) PRIMARY KEY,
    [Notes] VARCHAR(MAX)
);

CREATE TABLE [RoomTypes] (
    [RoomType] VARCHAR(50) PRIMARY KEY,
    [Notes] VARCHAR(MAX)
);

CREATE TABLE [BedTypes] (
    [BedType] VARCHAR(50) PRIMARY KEY,
    [Notes] VARCHAR(MAX)
);

CREATE TABLE [Rooms] (
    [RoomNumber] INT PRIMARY KEY,
    [RoomType] VARCHAR(50) NOT NULL,
    [BedType] VARCHAR(50) NOT NULL,
    [Rate] DECIMAL(10,2) NOT NULL,
    [RoomStatus] VARCHAR(50) NOT NULL,
    [Notes] VARCHAR(MAX)
);

CREATE TABLE [Payments] (
    [Id] INT PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [PaymentDate] DATE NOT NULL,
    [AccountNumber] INT NOT NULL,
    [FirstDateOccupied] DATE,
    [LastDateOccupied] DATE,
    [TotalDays] INT,
    [AmountCharged] DECIMAL(10,2),
    [TaxRate] DECIMAL(5,2),
    [TaxAmount] DECIMAL(10,2),
    [PaymentTotal] DECIMAL(10,2),
    [Notes] VARCHAR(MAX)
);

CREATE TABLE [Occupancies] (
    [Id] INT PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [DateOccupied] DATE NOT NULL,
    [AccountNumber] INT NOT NULL,
    [RoomNumber] INT NOT NULL,
    [RateApplied] DECIMAL(10,2),
    [PhoneCharge] DECIMAL(10,2),
    [Notes] VARCHAR(MAX)
);

GO

INSERT INTO [Occupancies] VALUES
(1, 1, '2026-01-01', 1001, 101, 50.00, 5.00, NULL),
(2, 2, '2026-02-01', 1002, 102, 80.00, 10.00, NULL),
(3, 3, '2026-03-01', 1003, 103, 150.00, 15.00, 'VIP stay');


INSERT INTO [Payments] VALUES
(1, 1, '2026-01-10', 1001, '2026-01-01', '2026-01-05', 4, 200.00, 0.10, 20.00, 220.00, NULL),
(2, 2, '2026-02-10', 1002, '2026-02-01', '2026-02-03', 2, 160.00, 0.10, 16.00, 176.00, 'Paid online'),
(3, 3, '2026-03-10', 1003, '2026-03-01', '2026-03-06', 5, 400.00, 0.10, 40.00, 440.00, NULL);


INSERT INTO [Rooms] VALUES
(101, 'Single', 'Single Bed', 50.00, 'Available', NULL),
(102, 'Double', 'Double Bed', 80.00, 'Occupied', NULL),
(103, 'Suite', 'King Size', 150.00, 'Available', 'Sea view');

INSERT INTO [BedTypes] VALUES
('Single Bed', NULL),
('Double Bed', NULL),
('King Size', 'Large bed');

INSERT INTO [RoomTypes] VALUES
('Single', NULL),
('Double', NULL),
('Suite', 'Luxury room');

INSERT INTO [RoomStatus] VALUES
('Available', NULL),
('Occupied', NULL),
('Maintenance', 'Under repair');

INSERT INTO [Customers] VALUES
(1001, 'Peter', 'Ivanov', '0888123456', 'Anna Ivanova', '0888765432', NULL),
(1002, 'Maria', 'Georgieva', '0888234567', 'Ivan Georgiev', '0888345678', 'VIP client'),
(1003, 'Nikolay', 'Petrov', '0888456789', 'Elena Petrova', '0888567890', NULL);

INSERT INTO [Employees] VALUES
(1, 'Ivan', 'Petrov', 'Manager', NULL),
(2, 'Maria', 'Ivanova', 'Receptionist', 'Friendly staff'),
(3, 'Georgi', 'Dimitrov', 'Cleaner', NULL);

GO
--Exercise 23: Decrease Tax Rate
USE [Hotel]

UPDATE [Payments]
SET [TaxRate] = [TaxRate] * 0.97

GO

SELECT [TaxRate] FROM [Payments]

GO
--Exercise 24: Delete All Records
USE [Hotel]

SELECT * FROM [Occupancies] --Not needed for Judge

DELETE FROM [Occupancies]

SELECT * FROM [Occupancies] --Not needed for Judge