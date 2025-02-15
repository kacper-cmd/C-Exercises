CREATE OR ALTER PROC uspAddWage @Amount money, @WorkerID int
AS
IF ((SELECT COUNT(*) FROM Wages w WHERE w.Amount = @Amount AND w.WorkerID = @WorkerID) = 0) 
	INSERT INTO [dbo].[Wages]
			   ([Amount]
			   ,[WorkerID])
		 VALUES
			   (@Amount,@WorkerID)
GO