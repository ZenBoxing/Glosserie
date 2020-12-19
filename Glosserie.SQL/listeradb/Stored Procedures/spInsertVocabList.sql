CREATE PROCEDURE [listeradb].[spInsertVocabList]
	@userID int,
	@listname nvarchar(100)
AS
begin
	set nocount on;

	insert into listeradb.vocablists(userID,listname)
	values(@userID,@listname);

end