declare @statusId int,
 @taskId int,
 @userId int
if not exists (select * from [User] where Username = 'bhogg')
 INSERT into [taskmanagementdb].[User] ([Firstname], [Lastname], [Username])
 VALUES (N'Boss', N'Hogg', N'bhogg')
if not exists (select * from [User] where Username = 'jbob')
 INSERT into [taskmanagementdb].[User] ([Firstname], [Lastname], [Username])
 VALUES (N'Jim', N'Bob', N'jbob')
 if not exists (select * from [User] where Username = 'jdoe')
 INSERT into [taskmanagementdb].[User] ([Firstname], [Lastname], [Username])
 VALUES (N'John', N'Doe', N'jdoe')
if not exists(select * from taskmanagementdb.Task where Subject = 'Test Task')
begin
 select top 1 @statusId = StatusId from Status order by StatusId;
 select top 1 @userId = UserId from [User] order by UserId;
 insert into taskmanagementdb.Task(Subject, StartDate, StatusId, CreatedDate, CreatedUserId)
 values('Test Task', getdate(), @statusId, getdate(), @userId);
 set @taskId = SCOPE_IDENTITY();

 INSERT [taskmanagementdb].[TaskUser] ([TaskId], [UserId])
 VALUES (@taskId, @userId)
end