USE ContractArchitecture;

GO
PRINT N'Creating [dbo].[EmailUserPasswordResetTokens]...';


GO
CREATE TABLE [dbo].[EmailUserPasswordResetTokens] (
    [Token]       NVARCHAR (64)    NOT NULL,
    [EmailUserId] UNIQUEIDENTIFIER NOT NULL,
    [ExpiresOn]   DATETIME         NOT NULL,
    CONSTRAINT [PK_EmailUserPasswordResetToken_Token] PRIMARY KEY CLUSTERED ([Token] ASC)
);


GO
PRINT N'Creating [dbo].[EmailUsers]...';


GO
CREATE TABLE [dbo].[EmailUsers] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Email]        NVARCHAR (256)   NOT NULL,
    [PasswordHash] NVARCHAR (88)    NOT NULL,
    [PasswordSalt] NVARCHAR (54)    NOT NULL,
    CONSTRAINT [PK_EmailUsers_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[EmailUsers].[EmailUsersEmailUnique]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [EmailUsersEmailUnique]
    ON [dbo].[EmailUsers]([Email] ASC) WHERE ([Email] IS NOT NULL);


GO
PRINT N'Creating [dbo].[Logs]...';


GO
CREATE TABLE [dbo].[Logs] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [MachineName] NVARCHAR (50)  NOT NULL,
    [Logged]      DATETIME       NOT NULL,
    [Level]       NVARCHAR (20)  NOT NULL,
    [Logger]      NVARCHAR (256) NULL,
    [Callsite]    NVARCHAR (256) NULL,
    [IP]          NVARCHAR (20)  NULL,
    [Message]     NVARCHAR (MAX) NOT NULL,
    [Username]    NVARCHAR (256) NULL,
    [Exception]   NVARCHAR (MAX) NULL
);


GO
PRINT N'Creating [dbo].[Sessions]...';


GO
CREATE TABLE [dbo].[Sessions] (
    [Token]       NVARCHAR (64)    NOT NULL,
    [EmailUserId] UNIQUEIDENTIFIER NULL,
    [Name]        NVARCHAR (256)   NOT NULL,
    [ExpiresOn]   DATETIME         NOT NULL,
    CONSTRAINT [PK_Sessions_Token] PRIMARY KEY CLUSTERED ([Token] ASC)
);


GO
PRINT N'Creating [dbo].[FK_EmailUserPasswordResetToken_EmailUserId]...';


GO
ALTER TABLE [dbo].[EmailUserPasswordResetTokens] WITH NOCHECK
    ADD CONSTRAINT [FK_EmailUserPasswordResetToken_EmailUserId] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[EmailUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_Sessions_EmailUserid]...';


GO
ALTER TABLE [dbo].[Sessions] WITH NOCHECK
    ADD CONSTRAINT [FK_Sessions_EmailUserid] FOREIGN KEY ([EmailUserId]) REFERENCES [dbo].[EmailUsers] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[EmailUserPasswordResetTokens] WITH CHECK CHECK CONSTRAINT [FK_EmailUserPasswordResetToken_EmailUserId];

ALTER TABLE [dbo].[Sessions] WITH CHECK CHECK CONSTRAINT [FK_Sessions_EmailUserid];


GO
PRINT N'Update complete.';


GO
