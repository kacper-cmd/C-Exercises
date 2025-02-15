CREATE OR ALTER PROC uspAddBook @Name varchar(50), @DepartmentID int
AS
IF ((SELECT COUNT(*) FROM Books b WHERE b.Name = @Name AND b.DepartmentID = @DepartmentID) = 0) 
	INSERT INTO [dbo].[Books]
           ([Name]
           ,[DepartmentID])
     VALUES
           (@Name,
           @DepartmentID)
GO

