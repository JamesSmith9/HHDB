USE [HHDB]
GO

DROP TABLE [dbo].[Answer]
GO


CREATE TABLE [dbo].[Answer](
	[SXQID] [int] NOT NULL,
	[AnsText] [varchar](500) NOT NULL,
	[CreatedByUser] [uniqueidentifier] NOT NULL,
	[AnswerID] [int] IDENTITY(1,1) NOT NULL,
	[Month] [smallint] NOT NULL,
	[Year] [smallint] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK__Answer__D4825024720F24C6] PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_aspnet_Users] FOREIGN KEY([CreatedByUser])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_aspnet_Users]
GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_SurveyXQuestion] FOREIGN KEY([SXQID])
REFERENCES [dbo].[SurveyXQuestion] ([SXQID])
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_SurveyXQuestion]
GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [CK__Answer__Month__40C49C62] CHECK  (([Month]>(0) AND [Month]<(13)))
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [CK__Answer__Month__40C49C62]
GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [CK__Answer__Quantity__42ACE4D4] CHECK  (([Quantity]>(0)))
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [CK__Answer__Quantity__42ACE4D4]
GO

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [CK__Answer__Year__41B8C09B] CHECK  (([Year]>(999) AND [Year]<(9999)))
GO

ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [CK__Answer__Year__41B8C09B]
GO


