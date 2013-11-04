IF Object_Id('ApplicationSession') IS NOT NULL
	Drop Table [ApplicationSession]
GO

CREATE TABLE [ApplicationSession](
	[SessionID] [nvarchar](80) NOT NULL,
	[ApplicationName] [nvarchar](255) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Expires] [datetime] NOT NULL,
	[LockDate] [datetime] NOT NULL,
	[LockID] [int] NOT NULL,
	[Timeout] [int] NOT NULL,
	[Locked] [bit] NOT NULL,
	[SessionItems] [varbinary](max) NULL,
	[Flags] [int] NOT NULL,
 CONSTRAINT [PKSessions] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC,
	[ApplicationName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 