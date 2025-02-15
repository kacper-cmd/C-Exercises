CREATE OR ALTER PROCEDURE uspAddBookAuthor @BookID int, @AuthorID int
AS
IF ((SELECT COUNT(*) FROM BookAuthors ba WHERE ba.BookID = @BookID AND ba.AuthorID = @AuthorID) = 0) 
	INSERT INTO [dbo].[BookAuthors]
			   ([BookID]
			   ,[AuthorID])
		 VALUES
			   (@BookID,
			   @AuthorID)
GO