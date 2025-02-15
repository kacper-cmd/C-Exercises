DROP TABLE IF EXISTS Workers;
CREATE TABLE Workers
(
	WorkerID int NOT NULL ,
	Name varchar(50),
	Surname varchar(50),
	CONSTRAINT PK_Workers PRIMARY KEY NONCLUSTERED (WorkerID)
);