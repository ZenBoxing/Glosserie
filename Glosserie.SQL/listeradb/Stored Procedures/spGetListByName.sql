CREATE PROCEDURE [listeradb].[spGetListByName]
	@UserID int,
	@ListName varchar(50)
AS
begin
	set nocount on;
	
	select listID, userID, listname 
	from listeradb.vocablists
	where userID = @UserID and listname = @listname;
end
