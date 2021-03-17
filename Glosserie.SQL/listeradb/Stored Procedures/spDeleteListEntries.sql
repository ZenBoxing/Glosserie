CREATE PROCEDURE [listeradb].[spDeleteListEntries]
	@listID int
AS
begin
	set nocount on;

	delete from listeradb.listentries where listID = @listID;
end