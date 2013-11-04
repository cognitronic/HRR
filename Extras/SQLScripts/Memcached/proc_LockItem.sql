IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'proc_LockItem')
	BEGIN
		DROP  Procedure  proc_LockItem
	END

GO

CREATE Procedure proc_LockItem
(
		@SessionId nvarchar(80),
		@ApplicationName nvarchar(255),
		@LockId int
)
AS
	UPDATE ApplicationSession SET
            LockID = @LockId, Flags = 0
            WHERE SessionID = @SessionId AND ApplicationName = @ApplicationName;

GO


GRANT EXEC ON proc_LockItem TO PUBLIC

GO


