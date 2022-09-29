--CREATE table dbo.TodoCategory(
--CategoryId int identity(1,1),
--CategoryName nvarchar(500),
--StateId int,
--ColorId int,
--Created datetime2,
--Modified datetime2,
--UserId int
--)

--insert into dbo.TodoCategory values ('TestCate', 0, 0, getdate(), getdate(), 0)
--insert into dbo.TodoCategory values ('TestCate2', 1, 1, getdate(), getdate(), 1)


select * from dbo.TodoCategory;


--EXEC sp_rename 'dbo.TodoCategory.CategoryState', 'StateId', 'COLUMN'