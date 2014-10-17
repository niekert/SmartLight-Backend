CREATE TABLE [dbo].[Timelock]
(
	[TimelockId] UNIQUEIDENTIFIER NOT NULL,
	[StartTime] TIME NOT NULL,
	[EndTime] TIME NOT NULL,

	CONSTRAINT [PK_Timelock] PRIMARY KEY(TimelockId)
)
