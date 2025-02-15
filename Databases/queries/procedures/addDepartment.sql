CREATE OR ALTER PROC uspAddDepartment @Name varchar(50)
AS
IF ((SELECT COUNT(*) FROM Departments d WHERE d.Name= @Name) = 0) 
	INSERT INTO [dbo].[Departments]([Name])
		 VALUES (@Name);
GO