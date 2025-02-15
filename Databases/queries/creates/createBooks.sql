DROP TABLE IF EXISTS Books;
CREATE TABLE Books 
(
	BookID int NOT NULL ,
	Name varchar(50),
	DepartmentID int NOT NULL,
	CONSTRAINT PK_Books PRIMARY KEY NONCLUSTERED (BookID),
	CONSTRAINT FK_Books_Departments FOREIGN KEY (DepartmentID)
		REFERENCES Departments (DepartmentID)
		ON DELETE CASCADE
        ON UPDATE CASCADE
);
