CREATE PROCEDURE [listeradb].[spInsertEntry]
	@word varchar(25),
	@wordtype varchar(20),
	@definition varchar(max),
	@wordrank float
AS
begin
	set nocount on;

	insert into listeradb.entries(word,wordtype,[definition],wordrank)
	values(@word,@wordtype,@definition,@wordrank);

end
