﻿CREATE TABLE [listeradb].[lists] (
    [listID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [userID]   BIGINT        NOT NULL,
    [listname] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_lists_listID] PRIMARY KEY CLUSTERED ([listID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [userID]
    ON [listeradb].[lists]([userID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'listeradb.lists', @level0type = N'SCHEMA', @level0name = N'listeradb', @level1type = N'TABLE', @level1name = N'lists';

