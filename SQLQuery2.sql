--CREATE table dbo.TodoItem(
--TodoItemId bigint identity(1,1),
--TodoTitle nvarchar(500),
--TodoText nvarchar(max),
--IsComplete bit,
--Created datetime2,
--Modified datetime2
--);

--ALTER TABLE dbo.TodoItem ADD
--	[CategoryId] int,
--	[ColorId] int,
--	[UserId] int,
	--[StateId] int;

--insert into dbo.TodoItem values ('test','text','false',getdate(),getdate(), 0, 0 ,0, 0);

 --UPDATE TodoItem SET
	--ColorId = 0,
	--CategoryId = 0,
	--UserId = 0,
	--StateId = 0;

select * from dbo.TodoItem
ORDER BY TodoItemId;