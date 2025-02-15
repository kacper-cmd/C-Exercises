-- DROP IF EXSITS
IF OBJECT_ID ('dbo.Authors', 'U') IS NOT NULL  
   DROP TABLE Authors;  
IF OBJECT_ID ('dbo.BookAuthors', 'U') IS NOT NULL  
   DROP TABLE BookAuthors;  
IF OBJECT_ID ('dbo.Books', 'U') IS NOT NULL  
   DROP TABLE Books;  
IF OBJECT_ID ('dbo.Departments', 'U') IS NOT NULL  
   DROP TABLE Departments;  
IF OBJECT_ID ('dbo.Wages', 'U') IS NOT NULL  
   DROP TABLE Wages;  
IF OBJECT_ID ('dbo.Workers', 'U') IS NOT NULL  
   DROP TABLE Workers;  
GO

--CREATE TABLES
CREATE TABLE Departments
(
	DepartmentID int IDENTITY(1,1) NOT NULL ,
	Name varchar(50),
	CONSTRAINT PK_Departments PRIMARY KEY NONCLUSTERED (DepartmentID)
);

CREATE TABLE Books 
(
	BookID int IDENTITY(1,1) NOT NULL ,
	Name varchar(50),
	DepartmentID int NOT NULL,
	CONSTRAINT PK_Books PRIMARY KEY NONCLUSTERED (BookID),
	CONSTRAINT FK_Books_Departments FOREIGN KEY (DepartmentID)
		REFERENCES Departments (DepartmentID)
		ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE Authors (
	AuthorID int IDENTITY(1,1) NOT NULL,
	Name varchar(50),
	Surname varchar(50),
	CONSTRAINT PK_Authors PRIMARY KEY NONCLUSTERED (AuthorID)
);

CREATE TABLE BookAuthors 
(
	BookID int NOT NULL ,
	AuthorID int NOT NULL,
	CONSTRAINT FK_BookAuthors_Books FOREIGN KEY (BookID)
		REFERENCES Books (BookID)
		ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT FK_BookAuthors_Authors FOREIGN KEY (AuthorID)
		REFERENCES Authors (AuthorID)
		ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE Workers
(
	WorkerID int IDENTITY(1,1) NOT NULL ,
	Name varchar(50),
	Surname varchar(50),
	CONSTRAINT PK_Workers PRIMARY KEY NONCLUSTERED (WorkerID)
);

CREATE TABLE Wages 
(
	WageID int IDENTITY(1,1) NOT NULL ,
	Amount money NOT NULL,
	WorkerID int NOT NULL,
	CONSTRAINT PK_Wages PRIMARY KEY NONCLUSTERED (WageID),
	CONSTRAINT PK_Wages_Workers FOREIGN KEY (WorkerID)
		REFERENCES Workers (WorkerID)
		ON DELETE CASCADE
        ON UPDATE CASCADE
);

--Alter Table

ALTER TABLE Books 
ADD 
	CONSTRAINT FK_Books_Departments FOREIGN KEY (DepartmentID) 
		REFERENCES Departments (DepartmentID)
		ON DELETE CASCADE
		ON UPDATE CASCADE;

ALTER TABLE BookAuthors
ADD
	CONSTRAINT FK_BookAuthors_Books FOREIGN KEY (BookID)
		REFERENCES Books (BookID)
		ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT FK_BookAuthors_Authors FOREIGN KEY (AuthorID)
		REFERENCES Authors (AuthorID)
		ON DELETE CASCADE
        ON UPDATE CASCADE

ALTER TABLE BookAuthors
ADD
	CONSTRAINT PK_Wages_Workers FOREIGN KEY (WorkerID)
		REFERENCES Workers (WorkerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE