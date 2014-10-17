CREATE TABLE [dbo].[Lamp]
(
	[LampId] UNIQUEIDENTIFIER NOT NULL,
	[LampName] varchar(max) NOT NULL,
	[CurrentState] TINYINT NOT NULL,
	[TurnOnWhenInRange] bit not null
		CONSTRAINT [DF_Lamp_TurnOnAtHome] DEFAULT(0),
	[TimelockId] UNIQUEIDENTIFIER NULL,

	CONSTRAINT [PK_Lamp] PRIMARY KEY(LampId),
	CONSTRAINT [FK_Lamp_Timelock] FOREIGN KEY(TimelockId) REFERENCES Timelock(TimelockId) ON DELETE CASCADE
)
