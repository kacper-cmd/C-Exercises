DROP TABLE IF EXISTS Authors;
CREATE TABLE Authors (
	AuthorID int NOT NULL,
	Name varchar(50),
	Surname varchar(50),
	CONSTRAINT PK_Authors PRIMARY KEY NONCLUSTERED (AuthorID)
);