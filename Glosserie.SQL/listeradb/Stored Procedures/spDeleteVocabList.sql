CREATE PROCEDURE [listeradb].[spDeleteVocabList]
	@ListID int
AS
begin
	set nocount on;

	delete from listeradb.vocablists where listID = @ListID;
end