DROP TABLE IF EXISTS Departments;
CREATE TABLE Departments
(
	DepartmentID int NOT NULL ,
	Name varchar(50),
	CONSTRAINT PK_Departments PRIMARY KEY NONCLUSTERED (DepartmentID)
);