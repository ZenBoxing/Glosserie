CREATE PROCEDURE [listeradb].[spInsertVocabList]
	@listID int,
	@userID int,
	@listname nvarchar(100)
AS
begin
	set nocount on;

	insert into listeradb.vocablists(listID,userID,listname)
	values(@listID,@userID,@listname);

end