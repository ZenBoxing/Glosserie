CREATE TABLE [listeradb].[listentries] (
    [listID]  BIGINT NOT NULL,
    [entryID] BIGINT NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [entryID]
    ON [listeradb].[listentries]([entryID] ASC);


GO
CREATE NONCLUSTERED INDEX [listID]
    ON [listeradb].[listentries]([listID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'listeradb.listentries', @level0type = N'SCHEMA', @level0name = N'listeradb', @level1type = N'TABLE', @level1name = N'listentries';

