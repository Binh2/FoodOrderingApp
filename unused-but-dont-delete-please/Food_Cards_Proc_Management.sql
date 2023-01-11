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

-- Select all cards
CREATE PROC Proc_SelectAllCards
AS
SELECT * FROM Cards join Consumers on Consumers.ConsumerID = Cards.ConsumerID;
GO

-- Select card by ConsumerID
CREATE PROC Proc_SelectCardsByConsumerID(@ConsumerID int)
AS
SELECT * FROM Cards join Consumers on Consumers.ConsumerID = Cards.ConsumerID where Cards.ConsumerID = @ConsumerID;
GO
--exec Proc_SelectCardsByConsumerID @ConsumerID=1;

-- Insert a card
CREATE PROC Proc_InsertCard(
	@CardNumber nvarchar(max), 
	@CardImage nvarchar(max), 
	@CardExpiryDate date,
	@CardBalance float(53),
	@CardTypeID int, 
	@ConsumerID int, 
	@CurrentID int output)
as
begin try
 if(exists(select * from Cards where CardNumber=@CardNumber))
  begin
   set @CurrentID=0
   return
  end
 insert into Cards(CardNumber, CardImage, CardExpiryDate, CardBalance, CardTypeID, ConsumerID) VALUES 
 (@CardNumber, @CardImage, @CardExpiryDate, @CardBalance, @CardTypeID, @ConsumerID);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO

-- Update a card
CREATE PROC dbo.Proc_UpdateCard(
	@CardID		int,
	@CardNumber nvarchar(max), 
	@CardImage nvarchar(max), 
	@CardExpiryDate date,
	@CardBalance float(53),
	@CardTypeID int,
	@ConsumerID int,
	@CurrentID int output)
as	
begin try
 if(exists(select * from Cards where CardID=@CardID))
  begin
   update Cards set CardNumber=@CardNumber, CardImage=@CardImage, CardExpiryDate=@CardExpiryDate, CardBalance=@CardBalance, 
   CardTypeID=@CardTypeID, ConsumerID=@ConsumerID 
   where CardID = @CardID
   set @CurrentID=@CardID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO
exec Proc_UpdateCard @CardID=1, @CardNumber='1', @CardImage='2', @CardExpiryDate='2024-01-01', @CardBalance=0.5, @CardTypeID=1, @CurrentID=0

-- Delete a card
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].Proc_DeleteCard(@CardID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Cards where CardID=@CardID))
  begin
   set @CurrentID=-1
   return
  end
  delete Cards where CardID=@CardID;
  set @CurrentID=@CardID;
end try
begin catch
 set @CurrentID=0
 end catch
GO