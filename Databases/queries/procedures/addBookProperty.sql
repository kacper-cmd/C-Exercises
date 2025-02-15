CREATE OR ALTER PROC uspAddBookProperty 
	@BookName varchar(50), 
	@AuthorName varchar(max), 
	@AuthorSurname varchar(max),
	@DepartmentID int
AS
IF ((SELECT COUNT(*) FROM BooksProperties bp WHERE 
	bp.BookName = @BookName 
	AND bp.DepartmentID = @DepartmentID
	AND bp.AuthorName = @AuthorName
	AND bp.AuthorSurname = @AuthorSurname) = 0) 

	INSERT INTO [dbo].[BookProperties]
			   ([BookName]
			   ,[AuthorName]
			   ,[AuthorSurname]
			   ,[DepartmentName])
		 VALUES
			   (@BookName
			   ,@AuthorName
			   ,@AuthorSurname
			   ,(SELECT d.Name FROM Departments d WHERE d.DepartmentID = @DepartmentID))

EXEC uspAddAuthor @AuthorName, @AuthorSurname;
EXEC uspAddBook @BookNAme, @DepartmentID;
GO
