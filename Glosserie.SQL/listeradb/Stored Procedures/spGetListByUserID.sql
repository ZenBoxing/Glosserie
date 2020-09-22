CREATE PROCEDURE [listeradb].[spGetListByUserID]
	@UserID int
AS
begin
	set nocount on;
	
	select listID, userID, listname 
	from listeradb.vocablists
	where userID = @UserID;
end
