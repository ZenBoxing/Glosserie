CREATE TABLE [listeradb].[entries] (
    [word]       VARCHAR (25)  NOT NULL,
    [wordtype]   VARCHAR (20)  NOT NULL,
    [definition] VARCHAR (MAX) NOT NULL,
    [entryID]    BIGINT        IDENTITY (176024, 1) NOT NULL,
    [wordrank]   FLOAT (53)    DEFAULT (NULL) NULL,
    CONSTRAINT [PK_entries_entryID] PRIMARY KEY CLUSTERED ([entryID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'listeradb.entries', @level0type = N'SCHEMA', @level0name = N'listeradb', @level1type = N'TABLE', @level1name = N'entries';

