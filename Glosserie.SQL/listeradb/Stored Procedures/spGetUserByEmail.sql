CREATE PROCEDURE [listeradb].[spGetUserByEmail]
	@email varchar(75)
AS
begin
	set nocount on;

	select userID, email, [password]
	from listeradb.users
	where users.email = @email;

end