CREATE TABLE [dbo].[Sessions] (
    [Token]                NVARCHAR (64)    NOT NULL,
    [EmailUserId]          UNIQUEIDENTIFIER NULL,
    [Name]                 NVARCHAR (256)   NOT NULL,
    [ExpiresOn]            DATETIME         NOT NULL,
    CONSTRAINT [PK_Sessions_Token] PRIMARY KEY CLUSTERED ([Token] ASC),
    CONSTRAINT [FK_Sessions_EmailUserid] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[EmailUsers] ([Id]),
);








