CREATE PROCEDURE [listeradb].[spGetEntriesByList]
	@listID int
AS
begin
	set nocount on;
	
	select entries.word, entries.wordtype, entries.[definition], entries.entryID, entries.wordrank 
	from listeradb.entries
	inner join listeradb.listentries on listentries.entryID = entries.entryID
	Where listentries.listID = @listID;

end