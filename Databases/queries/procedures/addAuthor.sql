CREATE OR ALTER PROC uspAddAuthor @Name varchar(50), @Surname varchar(50)
AS

IF ((SELECT COUNT(*) FROM Authors a WHERE a.Name = @Name AND a.Surname = @Surname) = 0) 
		INSERT INTO [dbo].[Authors]
				([Name]
				,[Surname])
			VALUES
				(@Name
				,@Surname)
GO

USE [LibraryDatabase]
GO