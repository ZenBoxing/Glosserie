CREATE PROCEDURE [listeradb].[spGetEntriesByWord]
	@EntryList [listeradb].[EntryTableType] READONLY
AS
BEGIN
	set nocount on;

	SELECT entries.entryID, entries.word, entries.wordtype, entries.[definition], entries.wordrank
	FROM listeradb.entries
	WHERE entries.word = @EntryList.word;
END