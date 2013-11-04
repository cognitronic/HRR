/****** Object:  Table [dbo].[ENTWorkflow]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Workflow]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Workflow](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ObjectName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Workflow]') AND name = N'IX_Workflow')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Workflow] ON [dbo].[Workflow] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO

/****** Object:  Table [dbo].[ENTWFOwnerGroup]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFOwnerGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFOwnerGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkflowID] [int] NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DefaultUserID] [int] NULL,
	[IsDefaultSameAsLast] [bit] NOT NULL,
	[Description] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFOwnerGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WFOwnerGroup]') AND name = N'IX_WFOwnerGroup')
CREATE UNIQUE NONCLUSTERED INDEX [IX_WFOwnerGroup] ON [dbo].[WFOwnerGroup] 
(
	[WorkflowID] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[ENTWFItem]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkflowID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[SubmittedBy] [int] NOT NULL,
	[CurrentWFStateID] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ENTWFState]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFState]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFState](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkflowID] [int] NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WFOwnerGroupID] [int] NULL,
	[IsOwnerSubmitter] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFState] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WFState]') AND name = N'IX_WFState')
CREATE UNIQUE NONCLUSTERED INDEX [IX_WFState] ON [dbo].[WFState] 
(
	[WorkflowID] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[ENTWFTransition]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFTransition]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFTransition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkflowID] [int] NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FromWFStateID] [int] NULL,
	[ToWFStateID] [int] NOT NULL,
	[PostTransitionMethodName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFTransition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WFTransition]') AND name = N'IX_WFTransition_1')
CREATE UNIQUE NONCLUSTERED INDEX [IX_WFTransition_1] ON [dbo].[WFTransition] 
(
	[FromWFStateID] ASC,
	[ToWFStateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[WFOwnerGroupUserAccount]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFOwnerGroupUserAccount]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFOwnerGroupUserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WFOwnerGroupID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFOwnerGroupUserAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[WFItemStateHistory]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFItemStateHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFItemStateHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WFItemID] [int] NOT NULL,
	[WFStateID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFItemTransition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[WFItemOwner]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFItemOwner]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFItemOwner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WFItemID] [int] NOT NULL,
	[WFOwnerGroupID] [int] NOT NULL,
	[PersonID] [int] NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFItemOwner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[WFStateProperty]    Script Date: 07/01/2008 01:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WFStateProperty]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WFStateProperty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WFStateID] [int] NOT NULL,
	[Name] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Required] [bit] NOT NULL,
	[ReadOnly] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[EnteredBy] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[ChangedBy] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_WFStateField] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WFStateProperty]') AND name = N'IX_WFStateField')
CREATE UNIQUE NONCLUSTERED INDEX [IX_WFStateField] ON [dbo].[WFStateProperty] 
(
	[WFStateID] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
--/****** Object:  Default [DF_WFItem_InsertDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_WFItem_InsertDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[WFItem]'))
--Begin
--ALTER TABLE [dbo].[ENTWFItem] ADD  CONSTRAINT [DF_ENTWFItem_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]

--End
--GO
--/****** Object:  Default [DF_ENTWFItem_UpdateDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ENTWFItem_UpdateDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItem]'))
--Begin
--ALTER TABLE [dbo].[ENTWFItem] ADD  CONSTRAINT [DF_ENTWFItem_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]

--End
--GO
--/****** Object:  Default [DF_ENTWFItemOwner_InsertDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ENTWFItemOwner_InsertDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemOwner]'))
--Begin
--ALTER TABLE [dbo].[ENTWFItemOwner] ADD  CONSTRAINT [DF_ENTWFItemOwner_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]

--End
--GO
--/****** Object:  Default [DF_ENTWFItemOwner_UpdateDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ENTWFItemOwner_UpdateDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemOwner]'))
--Begin
--ALTER TABLE [dbo].[ENTWFItemOwner] ADD  CONSTRAINT [DF_ENTWFItemOwner_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]

--End
--GO
--/****** Object:  Default [DF_ENTWFItemTransition_InsertDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ENTWFItemTransition_InsertDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemStateHistory]'))
--Begin
--ALTER TABLE [dbo].[ENTWFItemStateHistory] ADD  CONSTRAINT [DF_ENTWFItemTransition_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]

--End
--GO
--/****** Object:  Default [DF_ENTWFItemTransition_UpdateDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ENTWFItemTransition_UpdateDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemStateHistory]'))
--Begin
--ALTER TABLE [dbo].[ENTWFItemStateHistory] ADD  CONSTRAINT [DF_ENTWFItemTransition_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]

--End
--GO
--/****** Object:  Default [DF_ENTUserAccount_InsertDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ENTUserAccount_InsertDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTUserAccount]'))
--Begin
--ALTER TABLE [dbo].[ENTUserAccount] ADD  CONSTRAINT [DF_ENTUserAccount_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]

--End
--GO
--/****** Object:  Default [DF_ENTUserAccount_UpdateDate]    Script Date: 07/01/2008 01:01:36 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ENTUserAccount_UpdateDate]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTUserAccount]'))
--Begin
--ALTER TABLE [dbo].[ENTUserAccount] ADD  CONSTRAINT [DF_ENTUserAccount_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]

--End
--GO
--/****** Object:  ForeignKey [FK_ENTWFItem_ENTUserAccount]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItem_ENTUserAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItem]'))
--ALTER TABLE [dbo].[ENTWFItem]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItem_ENTUserAccount] FOREIGN KEY([SubmitterENTUserAccountId])
--REFERENCES [dbo].[ENTUserAccount] ([ENTUserAccountId])
--GO
--ALTER TABLE [dbo].[ENTWFItem] CHECK CONSTRAINT [FK_ENTWFItem_ENTUserAccount]
--GO
--/****** Object:  ForeignKey [FK_ENTWFItem_ENTWorkflow]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItem_ENTWorkflow]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItem]'))
--ALTER TABLE [dbo].[ENTWFItem]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItem_ENTWorkflow] FOREIGN KEY([ENTWorkflowId])
--REFERENCES [dbo].[ENTWorkflow] ([ENTWorkflowId])
--GO
--ALTER TABLE [dbo].[ENTWFItem] CHECK CONSTRAINT [FK_ENTWFItem_ENTWorkflow]
--GO
--/****** Object:  ForeignKey [FK_ENTWFItemOwner_ENTUserAccount]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItemOwner_ENTUserAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemOwner]'))
--ALTER TABLE [dbo].[ENTWFItemOwner]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItemOwner_ENTUserAccount] FOREIGN KEY([ENTUserAccountId])
--REFERENCES [dbo].[ENTUserAccount] ([ENTUserAccountId])
--GO
--ALTER TABLE [dbo].[ENTWFItemOwner] CHECK CONSTRAINT [FK_ENTWFItemOwner_ENTUserAccount]
--GO
--/****** Object:  ForeignKey [FK_ENTWFItemOwner_ENTWFItem]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItemOwner_ENTWFItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemOwner]'))
--ALTER TABLE [dbo].[ENTWFItemOwner]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItemOwner_ENTWFItem] FOREIGN KEY([ENTWFItemId])
--REFERENCES [dbo].[ENTWFItem] ([ENTWFItemId])
--GO
--ALTER TABLE [dbo].[ENTWFItemOwner] CHECK CONSTRAINT [FK_ENTWFItemOwner_ENTWFItem]
--GO
--/****** Object:  ForeignKey [FK_ENTWFItemOwner_ENTWFOwnerGroup]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItemOwner_ENTWFOwnerGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemOwner]'))
--ALTER TABLE [dbo].[ENTWFItemOwner]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItemOwner_ENTWFOwnerGroup] FOREIGN KEY([ENTWFOwnerGroupId])
--REFERENCES [dbo].[ENTWFOwnerGroup] ([ENTWFOwnerGroupId])
--GO
--ALTER TABLE [dbo].[ENTWFItemOwner] CHECK CONSTRAINT [FK_ENTWFItemOwner_ENTWFOwnerGroup]
--GO
--/****** Object:  ForeignKey [FK_ENTWFItemStateHistory_ENTUserAccount]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItemStateHistory_ENTUserAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemStateHistory]'))
--ALTER TABLE [dbo].[ENTWFItemStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItemStateHistory_ENTUserAccount] FOREIGN KEY([ENTUserAccountId])
--REFERENCES [dbo].[ENTUserAccount] ([ENTUserAccountId])
--GO
--ALTER TABLE [dbo].[ENTWFItemStateHistory] CHECK CONSTRAINT [FK_ENTWFItemStateHistory_ENTUserAccount]
--GO
--/****** Object:  ForeignKey [FK_ENTWFItemStateHistory_ENTWFItem]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItemStateHistory_ENTWFItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemStateHistory]'))
--ALTER TABLE [dbo].[ENTWFItemStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItemStateHistory_ENTWFItem] FOREIGN KEY([ENTWFItemId])
--REFERENCES [dbo].[ENTWFItem] ([ENTWFItemId])
--GO
--ALTER TABLE [dbo].[ENTWFItemStateHistory] CHECK CONSTRAINT [FK_ENTWFItemStateHistory_ENTWFItem]
--GO
--/****** Object:  ForeignKey [FK_ENTWFItemStateHistory_ENTWFState]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFItemStateHistory_ENTWFState]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFItemStateHistory]'))
--ALTER TABLE [dbo].[ENTWFItemStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFItemStateHistory_ENTWFState] FOREIGN KEY([ENTWFStateId])
--REFERENCES [dbo].[ENTWFState] ([ENTWFStateId])
--GO
--ALTER TABLE [dbo].[ENTWFItemStateHistory] CHECK CONSTRAINT [FK_ENTWFItemStateHistory_ENTWFState]
--GO
--/****** Object:  ForeignKey [FK_ENTWFOwnerGroupUserAccount_ENTUserAccount]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFOwnerGroupUserAccount_ENTUserAccount]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFOwnerGroupUserAccount]'))
--ALTER TABLE [dbo].[ENTWFOwnerGroupUserAccount]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFOwnerGroupUserAccount_ENTUserAccount] FOREIGN KEY([ENTUserAccountId])
--REFERENCES [dbo].[ENTUserAccount] ([ENTUserAccountId])
--GO
--ALTER TABLE [dbo].[ENTWFOwnerGroupUserAccount] CHECK CONSTRAINT [FK_ENTWFOwnerGroupUserAccount_ENTUserAccount]
--GO
--/****** Object:  ForeignKey [FK_ENTWFOwnerGroupUserAccount_ENTWFOwnerGroup]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFOwnerGroupUserAccount_ENTWFOwnerGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFOwnerGroupUserAccount]'))
--ALTER TABLE [dbo].[ENTWFOwnerGroupUserAccount]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFOwnerGroupUserAccount_ENTWFOwnerGroup] FOREIGN KEY([ENTWFOwnerGroupId])
--REFERENCES [dbo].[ENTWFOwnerGroup] ([ENTWFOwnerGroupId])
--ON DELETE CASCADE
--GO
--ALTER TABLE [dbo].[ENTWFOwnerGroupUserAccount] CHECK CONSTRAINT [FK_ENTWFOwnerGroupUserAccount_ENTWFOwnerGroup]
--GO
--/****** Object:  ForeignKey [FK_ENTWFState_ENTWFOwnerGroup]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFState_ENTWFOwnerGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFState]'))
--ALTER TABLE [dbo].[ENTWFState]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFState_ENTWFOwnerGroup] FOREIGN KEY([ENTWFOwnerGroupId])
--REFERENCES [dbo].[ENTWFOwnerGroup] ([ENTWFOwnerGroupId])
--GO
--ALTER TABLE [dbo].[ENTWFState] CHECK CONSTRAINT [FK_ENTWFState_ENTWFOwnerGroup]
--GO
--/****** Object:  ForeignKey [FK_ENTWFState_ENTWorkflow]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFState_ENTWorkflow]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFState]'))
--ALTER TABLE [dbo].[ENTWFState]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFState_ENTWorkflow] FOREIGN KEY([ENTWorkflowId])
--REFERENCES [dbo].[ENTWorkflow] ([ENTWorkflowId])
--GO
--ALTER TABLE [dbo].[ENTWFState] CHECK CONSTRAINT [FK_ENTWFState_ENTWorkflow]
--GO
--/****** Object:  ForeignKey [FK_ENTWFStateField_ENTWFState]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFStateField_ENTWFState]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFStateProperty]'))
--ALTER TABLE [dbo].[ENTWFStateProperty]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFStateField_ENTWFState] FOREIGN KEY([ENTWFStateId])
--REFERENCES [dbo].[ENTWFState] ([ENTWFStateId])
--ON DELETE CASCADE
--GO
--ALTER TABLE [dbo].[ENTWFStateProperty] CHECK CONSTRAINT [FK_ENTWFStateField_ENTWFState]
--GO
--/****** Object:  ForeignKey [FK_ENTWFTransition_ENTWFState]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFTransition_ENTWFState]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFTransition]'))
--ALTER TABLE [dbo].[ENTWFTransition]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFTransition_ENTWFState] FOREIGN KEY([FromENTWFStateId])
--REFERENCES [dbo].[ENTWFState] ([ENTWFStateId])
--GO
--ALTER TABLE [dbo].[ENTWFTransition] CHECK CONSTRAINT [FK_ENTWFTransition_ENTWFState]
--GO
--/****** Object:  ForeignKey [FK_ENTWFTransition_ENTWFState1]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFTransition_ENTWFState1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFTransition]'))
--ALTER TABLE [dbo].[ENTWFTransition]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFTransition_ENTWFState1] FOREIGN KEY([ToENTWFStateId])
--REFERENCES [dbo].[ENTWFState] ([ENTWFStateId])
--GO
--ALTER TABLE [dbo].[ENTWFTransition] CHECK CONSTRAINT [FK_ENTWFTransition_ENTWFState1]
--GO
--/****** Object:  ForeignKey [FK_ENTWFTransition_ENTWorkflow]    Script Date: 07/01/2008 01:01:36 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENTWFTransition_ENTWorkflow]') AND parent_object_id = OBJECT_ID(N'[dbo].[ENTWFTransition]'))
--ALTER TABLE [dbo].[ENTWFTransition]  WITH CHECK ADD  CONSTRAINT [FK_ENTWFTransition_ENTWorkflow] FOREIGN KEY([ENTWorkflowId])
--REFERENCES [dbo].[ENTWorkflow] ([ENTWorkflowId])
--GO
--ALTER TABLE [dbo].[ENTWFTransition] CHECK CONSTRAINT [FK_ENTWFTransition_ENTWorkflow]
--GO
