IF Object_Id('proc_Update') IS NOT NULL
	Drop procedure [proc_Update]

GO

Create procedure [proc_Update]
(
	@Expires DateTime,
	@SessionItems varbinary(max) = NULL,
	@Locked bit,
	@SessionId nvarchar(80),
	@ApplicationName nvarchar(255),
	@LockId int
)
AS

Begin Try
-- Deleting any already expired data
	Delete from ApplicationSession where 
		SessionID = @SessionId and
		ApplicationName = @ApplicationName and
		Expires < GetDate();

-- Update the current session data
	UPDATE ApplicationSession SET Expires = @Expires, SessionItems = @SessionItems, Locked = @Locked
           WHERE SessionID = @SessionId AND ApplicationName = @ApplicationName AND LockID = @LockId;
    return 1;
End Try
Begin Catch
	return -1;
End Catch

GO 