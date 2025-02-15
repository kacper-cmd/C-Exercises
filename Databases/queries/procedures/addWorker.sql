CREATE OR ALTER PROC uspAddWorker @Name varchar(50), @Surname varchar(50)
AS
IF ((SELECT COUNT(*) FROM Workers w WHERE w.Name = @Name AND w.Surname = @Surname) = 0) 
	INSERT INTO [dbo].[Workers]
			   ([Name]
			   ,[Surname])
		 VALUES
			   (@Name,
			   @Surname)
GO