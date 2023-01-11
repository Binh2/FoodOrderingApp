-- Execute every connect please
USE FOOD_MANAGEMENT; 
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------- Delete all procedures -------------------------
declare @procName varchar(500)
declare cur cursor 
for select [name] from sys.objects where type = 'p'
open cur
fetch next from cur into @procName
while @@fetch_status = 0
begin
    exec('drop procedure [' + @procName + ']')
    fetch next from cur into @procName
end
close cur
deallocate cur
go
--//---------------- Delete all procedures ---------------------//--

--Select all consumers
CREATE proc Proc_SelectAllConsumers
as
select * from Consumers;
GO
-- Select a consumer by ConsumerID
CREATE proc Proc_SelectConsumerByID(@ConsumerID int)
as
select * from Consumers where ConsumerID = @ConsumerID;
GO
-- Select a consumer by ConsumerUsername
CREATE proc Proc_SelectConsumerByUsername(@ConsumerUsername nvarchar(max))
as
select * from Consumers where ConsumerUsername = @ConsumerUsername;
GO

-- Select a consumer by ConsumerEmail
CREATE proc Proc_SelectConsumerByEmail(@ConsumerEmail nvarchar(max))
as
select * from Consumers where ConsumerEmail = @ConsumerEmail;
GO

-- Insert a consumer
CREATE PROC dbo.Proc_InsertConsumer(
	@ConsumerName		nvarchar(MAX),
	@ConsumerEmail		nvarchar(MAX),
	@ConsumerImage		nvarchar(MAX),
	@ConsumerUsername	nvarchar(MAX),
	@ConsumerPassword	nvarchar(MAX),
	@CurrentID int output)
as
begin try
 if(exists(select * from Consumers where ConsumerUsername=@ConsumerUsername))
  begin
   set @CurrentID=0
   return
  end
 insert into Consumers(ConsumerName,ConsumerEmail,ConsumerImage,ConsumerUsername,ConsumerPassword) VALUES 
 (@ConsumerName,@ConsumerEmail,@ConsumerImage,@ConsumerUsername,@ConsumerPassword);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO

-- Update a consumer
CREATE PROC dbo.Proc_UpdateConsumer(
	@ConsumerID			int,
	@ConsumerName		nvarchar(MAX),
	@ConsumerEmail		nvarchar(MAX),
	@ConsumerImage		nvarchar(MAX),
	@ConsumerUsername	nvarchar(MAX),
	@ConsumerPassword	nvarchar(MAX),
	@CurrentID int output)
as	
begin try
 if(exists(select * from Consumers where ConsumerID=@ConsumerID))
  begin
   update Consumers set ConsumerName=@ConsumerName, ConsumerEmail=@ConsumerEmail, 
   ConsumerImage = @ConsumerImage, ConsumerUsername = @ConsumerUsername, ConsumerPassword = @ConsumerPassword
   where ConsumerID = @ConsumerID;
   set @CurrentID=@ConsumerID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO

--exec Proc_UpdateConsumer @ConsumerID=5, @ConsumerName='david', @ConsumerEmail='david@gmail.com', @ConsumerImage='david.png', @ConsumerUsername='david',
--@ConsumerPassword='123', @CurrentID=0;

-- Delete a consumer
create PROC Proc_DeleteConsumer(@ConsumerID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Consumers where ConsumerID=@ConsumerID))
  begin
   set @CurrentID=-1
   return
  end
  delete Consumers where ConsumerID=@ConsumerID;
  set @CurrentID=@ConsumerID;
end try
begin catch
 set @CurrentID=0
 end catch
GO
