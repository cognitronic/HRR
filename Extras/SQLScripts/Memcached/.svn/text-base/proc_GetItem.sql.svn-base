IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'proc_GetItem')
	BEGIN
		DROP  Procedure  proc_GetItem
	END

GO

CREATE Procedure proc_GetItem
(
	@SessionId nvarchar(80),
	@ApplicationName nvarchar(255)
)
AS

	SELECT Expires, SessionItems, LockID, LockDate, Flags, Timeout 
          FROM ApplicationSession
          WHERE SessionID = @SessionId AND ApplicationName = @ApplicationName;

GO


GRANT EXEC ON proc_GetItem TO PUBLIC

GO

