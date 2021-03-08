CREATE PROCEDURE [listeradb].[spGetListByListName]
	@listname varchar(50),
	@userID int
AS
BEGIN
	set nocount on;
	
	select listID, userID, listname 
	from listeradb.vocablists
	where listname = @listname and userID = @userID;
END
