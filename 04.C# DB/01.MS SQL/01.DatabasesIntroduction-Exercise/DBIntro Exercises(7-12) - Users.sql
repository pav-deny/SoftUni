--01.Database Introduction - Exercise (7-12)
GO
--Exercise 07: Create Table People
CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAr(200) NOT NULL,
	[Picture] VARBINARY(max),
	CHECK(LEN([Picture]) <= 2097152), --size up to 2MB (or 2 097 152B),
	[Height] DECIMAL(4,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(max)
)

GO

--Made by ChatGPT
INSERT INTO [People] ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
('Ivan Petrov', NULL, 1.82, 78.50, 'm', '1998-05-12', 'Software developer from Sofia.'),
('Maria Georgieva', NULL, 1.68, 55.20, 'f', '2001-11-03', 'Student and fitness enthusiast.'),
('Georgi Ivanov', NULL, 1.90, 88.10, 'm', '1995-02-20', 'Engineer working in robotics.'),
('Elena Dimitrova', NULL, 1.72, 62.30, 'f', '1999-07-15', 'Graphic designer and artist.'),
('Nikolay Stefanov', NULL, 1.75, 80.00, 'm', '1997-09-30', 'IT consultant and gamer.');

GO
--Exercise 08: Create Table Users
CREATE TABLE [Users] (
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK(LEN([ProfilePicture]) <= 921600), --Checks if the ProfilePicture size is up to 900KB (or 921 600B)
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)
--CHECK: user defined rule for the value in (a) column/s

GO

--Made by Claude.ai
INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
    ('john_doe',      'P@ssw0rd123',  NULL, '2026-05-10 08:23:11', 0),
    ('jane_smith',    'Qwerty!987',   NULL, '2026-05-12 14:05:47', 0),
    ('bob_jackson',   'S3cur3Pass!',  NULL, '2026-01-30 09:18:32', 1),
    ('alice_wonder',  'MyP@ss#2026',  NULL, '2026-05-13 21:44:09', 0),
    ('deleted_user5', 'TempPass!99',  NULL,  NULL,                  1);

GO
--Exercise 09: Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC0722BCF0D0]

GO

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users_Id_Username] PRIMARY KEY([Id], [Username])
--Composite PK: Combination of several columns forming the PK

GO
--Exercise 10: Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT [CK_Password_MinLength_5] CHECK(LEN(Password) >= 5) --Password Length must be atleast 5 symbols

GO
--Exercise 11: Set Default Value Of A Field
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime_Now] DEFAULT(GETDATE()) FOR [LastLoginTime]

GO
--Exercise 12: Set Unique Field
ALTER TABLE [Users]
DROP CONSTRAINT [PK_Users_Id_Username]

GO
ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users_Id] PRIMARY KEY([Id])

GO

ALTER TABLE [Users]
ADD CONSTRAINT [UQ_Users_Username] UNIQUE([Username])