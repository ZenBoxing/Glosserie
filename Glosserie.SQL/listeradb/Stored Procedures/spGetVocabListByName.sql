CREATE PROCEDURE [listeradb].[spGetVocabListByName]
	@listname nvarchar(100)
AS
begin
	 set nocount on;
	 select vocablists.listID, vocablists.listname, vocablists.userID
	 from listeradb.vocablists
	 where vocablists.listname = @listname;
	
end
