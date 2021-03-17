CREATE PROCEDURE [listeradb].[spGetListsByUserID]
	@UserID int
AS
begin
	set nocount on;
	
	select listID, userID, listname 
	from listeradb.vocablists
	where userID = @UserID;
end
