CREATE PROCEDURE [listeradb].[spGetUserByID]
	@UserID int
AS
begin
	set nocount on;

	select users.userID, users.email, users.[password]
	from listeradb.users
	where users.userID = @UserID;

end