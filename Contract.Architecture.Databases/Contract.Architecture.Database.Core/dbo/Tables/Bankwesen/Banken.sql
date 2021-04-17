CREATE TABLE [dbo].[Banken] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
	[Name]                 NVARCHAR (256)   NOT NULL,
	[Boolean]              BIT              NOT NULL,
	[DateTime]             DATETIME         NOT NULL,
	[Double]               FLOAT            NOT NULL,
	[Guid]                 UNIQUEIDENTIFIER NOT NULL,
	[Integer]              INT              NOT NULL,
    CONSTRAINT [PK_Banken_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
);
