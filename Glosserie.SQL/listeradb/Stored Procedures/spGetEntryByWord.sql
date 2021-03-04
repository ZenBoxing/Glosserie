
CREATE PROCEDURE [listeradb].[spGetEntryByWord]
	@word varchar(50)
AS
begin
	set nocount on;

	SELECT entries.entryID, entries.word, entries.wordtype, entries.[definition], entries.wordrank
	FROM listeradb.entries
	Where entries.word = @word;

end
