CREATE TABLE [dbo].[GegoennteKunden] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
	[Name]                 NVARCHAR (256)   NOT NULL,
	[GegoennterName]       NVARCHAR (256)   NOT NULL,
	[GegoennterBoolean]    BIT              NULL,
	[GegoennterDateTime]   DATETIME         NULL,
	[GegoennterDouble]     FLOAT            NULL,
	[GegoennterGuid]       UNIQUEIDENTIFIER NULL,
	[GegoennterInteger]    INT              NULL,
	[BesteBankId]          UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_GegoennteKunden_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GegoennteKunden_BesteBankId] FOREIGN KEY ([BesteBankId]) REFERENCES [dbo].[GegoennteBanken] ([Id]),
);
