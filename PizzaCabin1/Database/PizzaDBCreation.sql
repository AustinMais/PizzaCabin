CREATE TABLE Schedules
(
	[ScheduleId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Schedule] INT NOT NULL,
	[ContractTimeMinutes] INT NOT NULL,
	[ScheduleDate] DATE NOT NULL,
	[IsFullDayAbscense] BIT NOT NULL,
	[EmployeeName] VARCHAR(50) NOT NULL,
	[PersonID] VARCHAR(50) NOT NULL,
);

CREATE TABLE Projections
(
	[ProjectionId] INT NOT NULL IDENTITY(0,1) PRIMARY KEY,
	[PersonID] VARCHAR(50) NOT NULL,
	[ScheduleID] INT NOT NULL FOREIGN KEY REFERENCES Schedules(ScheduleID),
);

CREATE TABLE Activities
(
	[ActivityId] INT NOT NULL IDENTITY(0,1) PRIMARY KEY,
	[ActivityNumber] INT NOT NULL,
	[Color] VARCHAR(10) NOT NULL,
	[Description] VARCHAR(200) NOT NULL,
	[StartDateTime] DATE NOT NULL,
	[Minutes] INT NOT NULL,
	[ProjectionID] INT NOT NULL FOREIGN KEY REFERENCES Projections(ProjectionId)
);