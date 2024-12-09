declare @name nvarchar(50);

exec getFullNameStudent 2, @name output;

select @name