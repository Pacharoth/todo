CREATE TABLE TracerAppSchema.Tasks(
    -- tableId int identity (starting, increment by)
    TaskId INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(200) NULL,
    Title NVARCHAR(100) NOT NULL,
    TaskStatus NVARCHAR(100) DEFAULT 'UNCOMPLETE',
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NULL,
    PriorityStatus NVARCHAR(100) DEFAULT 'LOW',
    DueTo DATETIME NULL,
    -- check constraint status priority of task in low priority and high priority
    CONSTRAINT CK_StatusPriority CHECK (PriorityStatus in ('LOW','MEDIUM','HIGH')),
    -- check constraints status complete, uncomplete, softdelete
    CONSTRAINT CK_TaskStatus CHECK (TaskStatus in ('COMPLETE','UNCOMPLETE'))
);