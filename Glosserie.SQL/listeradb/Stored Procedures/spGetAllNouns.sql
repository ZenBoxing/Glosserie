CREATE PROCEDURE [listeradb].[spGetAllNouns]
AS
begin
	set nocount on;

	select entries.word, entries.wordtype, entries.[definition], entries.entryID, entries.wordrank
	from listeradb.entries
	where entries.wordtype = 'n.';

end
