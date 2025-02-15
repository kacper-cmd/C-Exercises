CREATE OR ALTER VIEW BookProperties
AS
SELECT b.BookID, b.Name AS 'Book Name', 
	a.Name AS 'Author Name', 
	a.Surname AS 'Author Surname',
	d.Name AS 'Department Name'
FROM Books b FULL OUTER JOIN BookAuthors ba ON b.BookID = ba.BookID
	FULL OUTER JOIN Authors a ON a.AuthorID = ba.AuthorID
	FULL OUTER JOIN Departments d ON d.DepartmentID = b.DepartmentID;
GO