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
--//---------------- Delete all procedures ---------------------//--

declare @consumers_columns nvarchar(max);
set @consumers_columns = 'ConsumerID, ConsumerName, ConsumerEmail, ''http://''+@IP+ConsumerImage ConsumerImage, ConsumerUsername, ConsumerPassword'
-- Get all consumers
CREATE PROC Proc_GetAllConsumers(@IP nvarchar(max))
AS
SELECT @consumers_columns FROM Consumers;
GO

-- Get consumers by ConsumerID
CREATE PROC Proc_GetConsumersByConsumerID(@IP nvarchar(max), @ConsumerID int)
AS
SELECT CardID, CardNumber, 'http://'+@IP+CardImage CardImage, CardExpiryDate, CardTypeID, ConsumerID FROM Consumers where;
GO

-- Insert a consumer
CREATE PROC dbo.Proc_InsertCard(
	@CardNumber nvarchar(max), 
	@CardImage nvarchar(max), 
	@CardExpiryDate date,
	@CardTypeID int, 
	@ConsumerID int, 
	@CurrentID int output)
as
begin try
 if(exists(select * from Consumers where CardNumber=@CardNumber))
  begin
   set @CurrentID=0
   return
  end
 insert into Consumers(CardNumber, CardImage, CardTypeID, ConsumerID) VALUES (@CardNumber, @CardImage, @CardTypeID, @ConsumerID);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO

-- Update a consumer
CREATE PROC dbo.Proc_UpdateCard(
	@CardID		int,
	@CardNumber nvarchar(max), 
	@CardImage nvarchar(max), 
	@CardExpiryDate date,
	@CardTypeID int,
	@CurrentID int output)
as
begin try
 if(exists(select * from Consumers where CardID=@CardID))
  begin
   update Consumers set CardNumber = @CardNumber, CardImage = @CardImage, CardExpiryDate = @CardExpiryDate, CardTypeID = @CardTypeID 
   where CardID = @CardID
   set @CurrentID=@CardID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO

-- Delete a consumer
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].Proc_DeleteCard(@CardID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Consumers where CardID=@CardID))
  begin
   set @CurrentID=-1
   return
  end
  delete Consumers where CardID=@CardID;
  set @CurrentID=@CardID;
end try
begin catch
 set @CurrentID=0
 end catch
GO