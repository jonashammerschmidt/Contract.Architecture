CREATE TABLE [dbo].[EmailUserPasswordResetTokens]
(
    [Token]             NVARCHAR (64)    NOT NULL,
    [EmailUserId]       UNIQUEIDENTIFIER NOT NULL,
    [ExpiresOn]         DATETIME         NOT NULL,
    CONSTRAINT [PK_EmailUserPasswordResetToken_Token] PRIMARY KEY CLUSTERED ([Token] ASC),
    CONSTRAINT [FK_EmailUserPasswordResetToken_EmailUserId] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[EmailUsers] ([Id]) ON DELETE CASCADE
)
