CREATE TABLE [listeradb].[users] (
    [userID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [email]    NVARCHAR (75) NOT NULL,
    [password] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_users_userID] PRIMARY KEY CLUSTERED ([userID] ASC),
    CONSTRAINT [users$email] UNIQUE NONCLUSTERED ([email] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'listeradb.users', @level0type = N'SCHEMA', @level0name = N'listeradb', @level1type = N'TABLE', @level1name = N'users';

