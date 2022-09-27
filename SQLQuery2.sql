--CREATE table dbo.TodoItem(
--TodoItemId bigint identity(1,1),
--TodoTitle nvarchar(500),
--TodoText nvarchar(max),
--IsComplete bit,
--Created datetime2,
--Modified datetime2
--)

--insert into dbo.TodoItem values ('title','text','false',getdate(),getdate())
--insert into dbo.TodoItem values ('title2','text2','false',getdate(),getdate())

select * from dbo.TodoItem