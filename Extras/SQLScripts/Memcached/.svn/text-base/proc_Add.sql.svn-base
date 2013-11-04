IF Object_ID('proc_Add') IS NOT NULL	
	Drop procedure [proc_Add]

GO

CREATE procedure [proc_Add]
( 
	@SessionID nvarchar(80),
	@ApplicationName nvarchar(255),
	@Created DateTime,
	@Expires DateTime,
	@LockDate Datetime,
	@LockID int,
	@Timeout int,
	@Locked bit,
	@SessionItems varbinary(max) = NULL,
	@Flags int
) 
AS 
	Begin Try
		-- Deleting any already expired data
		Delete from ApplicationSession where 
			SessionID = @SessionId and
			ApplicationName = @ApplicationName and
			Expires < GetDate();

		-- Inserting new session data
		Insert Into ApplicationSession(
			SessionID, ApplicationName, Created, Expires, LockDate, LockID, [Timeout],
			Locked, SessionItems, Flags)
		Values(@SessionID, @ApplicationName, @Created, @Expires, @LockDate, @LockID, @Timeout, 
			@Locked, @SessionItems, @Flags);
		return 1;
	End Try
	Begin Catch
		return -1;
	End Catch
			
GO