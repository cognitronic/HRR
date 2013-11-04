IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'proc_RemoveItemWithLock')
	BEGIN
		DROP  Procedure  proc_RemoveItemWithLock
	END

GO

CREATE Procedure proc_RemoveItemWithLock

(
	@SessionId nvarchar(80),
	@ApplicationName nvarchar(255),
	@LockId int
)
AS

	DELETE FROM ApplicationSession
        WHERE SessionID = @SessionId AND ApplicationName = @ApplicationName
			 AND LockID =@LockId;

GO

GRANT EXEC ON proc_RemoveItemWithLock TO PUBLIC

GO


