CREATE TABLE [dbo].[GegoennteBanken] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
	[Name]                 NVARCHAR (256)   NOT NULL,
	[GegoennterName]       NVARCHAR (256)   NOT NULL,
	[GegoennterBoolean]    BIT              NOT NULL,
	[GegoenntesDateTime]   DATETIME         NOT NULL,
	[GegoennterDouble]     FLOAT            NOT NULL,
	[GegoennteGuid]        UNIQUEIDENTIFIER NOT NULL,
	[GegoennterInteger]    INT              NOT NULL,
    CONSTRAINT [PK_GegoennteBanken_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
);
