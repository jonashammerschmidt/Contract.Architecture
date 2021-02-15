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



