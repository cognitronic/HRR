IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'proc_RemoveItem')
	BEGIN
		DROP  Procedure  proc_RemoveItem
	END

GO

CREATE Procedure proc_RemoveItem
(
	@SessionId nvarchar(80),
	@ApplicationName nvarchar(255)
)
AS

	Delete from ApplicationSession where 
		SessionID = @SessionId and
		ApplicationName = @ApplicationName;

GO


GRANT EXEC ON proc_RemoveItem TO PUBLIC

GO


