INSERT INTO TracerAppSchema.Task([Description],[Title],[TaskStatus],[PriorityStatus])
OUTPUT inserted.TaskId
VALUES('It is really important Data2','Brother2','UNCOMPLETE','LOW');
INSERT INTO TracerAppSchema.Task([Description],[Title],[TaskStatus],[PriorityStatus])
OUTPUT inserted.TaskId
VALUES('It is really important Data1','Brother1','UNCOMPLETE','HIGH');