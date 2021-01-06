CREATE PROCEDURE [listeradb].[spInsertListEntry]
	@listID int,
	@entryID int
AS
begin
	set nocount on;

	insert into listeradb.listentries(listID,entryID)
	values(@listID,@entryID);

end