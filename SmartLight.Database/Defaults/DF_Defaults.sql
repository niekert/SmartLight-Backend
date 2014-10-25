DECLARE @timeLockId uniqueidentifier
SET @timeLockId = NEWID()

INSERT INTO Timelock(TimelockId, StartTime, EndTime)
VALUES
(
@timeLockId,
'21:00:00',
'00:00:00'
);

INSERT INTO Lamp(LampId, LampName, CurrentState, TurnOnWhenInRange, TimelockId)
VALUES
(
NEWID(),
'Woonkamer TV',
0,
1,
@timeLockId
);

INSERT INTO Lamp(LampId, LampName, CurrentState, TurnOnWhenInRange, TimelockId)
VALUES
(
NEWID(),
'Woonkamer Bank',
0,
1,
@timeLockId
);

INSERT INTO Lamp(LampId, LampName, CurrentState, TurnOnWhenInRange, TimelockId)
VALUES
(
NEWID(),
'Slaapkamer bedlicht',
0,
1,
null
);

INSERT INTO Lamp(LampId, LampName, CurrentState, TurnOnWhenInRange, TimelockId)
VALUES
(
NEWID(),
'Slaapkamer plafond',
0,
1,
null
);

INSERT INTO Lamp(LampId, LampName, CurrentState, TurnOnWhenInRange, TimelockId)
VALUES
(
NEWID(),
'Badkamer',
0,
1,
null
);

