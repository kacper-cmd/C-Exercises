CREATE OR ALTER VIEW WorkerProperties
AS
SELECT wo.WorkerID, wo.Name, wo.Surname, wg.Amount
FROM Workers wo FULL OUTER JOIN Wages wg ON wg.WorkerID = wo.WorkerID;
GO