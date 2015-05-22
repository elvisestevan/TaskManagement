if not exists(select * from taskmanagementdb.Status where Name = 'Not Started')
 insert into taskmanagementdb.Status(Name, Ordinal) values('Not Started', 0);
if not exists(select * from taskmanagementdb.Status where Name = 'In Progress')
 insert into taskmanagementdb.Status(Name, Ordinal) values('In Progress', 1);
if not exists(select * from taskmanagementdb.Status where Name = 'Completed')
 insert into taskmanagementdb.Status(Name, Ordinal) values('Completed', 2);