CREATE PROCEDURE [listeradb].[spGetAllEntries]
AS
begin
	set nocount on;

	select entries.word, entries.wordtype, entries.[definition], entries.entryID, entries.wordrank
	from listeradb.entries;

end