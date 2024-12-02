CREATE TABLE [dbo].[SleepSessions]
(
    [PatientId] VARCHAR(50) NOT NULL,
    [SessionDate] DATE NOT NULL, 
    [AHI] DECIMAL(8, 3) NOT NULL, 
    [UsageHours] DECIMAL(18, 10) NOT NULL, 
    [MaskSessionCount] INT NOT NULL, 
    [LeakScore] INT NOT NULL, 
    [Source] VARCHAR(10) NULL, 

)
