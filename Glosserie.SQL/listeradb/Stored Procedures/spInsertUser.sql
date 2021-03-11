CREATE PROCEDURE [listeradb].[spInsertUser]
	@email varchar(75),
	@password varchar(100)
AS
begin
	set nocount on;

	insert into listeradb.users(email,[password])
	values(@email,@password);

end
