CREATE PROCEDURE [listeradb].[spGetVocabLists]
AS
begin
	set nocount on;

	select listID, userID, listname
	from listeradb.vocablists;

end