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

--Select all orderStates
CREATE proc Proc_SelectAllOrderStates
as
select * from OrderStates join OrderStateTypes on OrderStates.OrderStateTypeID = OrderStateTypes.OrderStateTypeID;
GO
-- Select a orderState by ConsumerID
CREATE proc Proc_SelectOrderStatesByOrderID(@OrderID int)
as
select * from OrderStates join OrderStateTypes on OrderStates.OrderStateTypeID = OrderStateTypes.OrderStateTypeID 
	where OrderID = @OrderID;
GO
-- Insert a orderState
CREATE PROC Proc_InsertOrderState(
	@OrderID int,
	@OrderStateTypeID int,
	@OrderDate date,
	@OrderLocation nvarchar(max),
	@CurrentID int output)
as
begin try
 insert into OrderStates(OrderID,OrderStateTypeID,OrderDate,OrderLocation) VALUES 
  (@OrderID,@OrderStateTypeID,@OrderDate,@OrderLocation);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Update a orderState
CREATE PROC Proc_UpdateOrderState(
	@OrderStateID		int,
	@OrderID int,
	@OrderStateTypeID int,
	@OrderDate date,
	@OrderLocation nvarchar(max),
	@CurrentID int output)
as	
begin try
 if(exists(select * from OrderStates where OrderStateID=@OrderStateID))
  begin
   update OrderStates set OrderID=@OrderID, OrderStateTypeID=@OrderStateTypeID,
    OrderDate=@OrderDate, OrderLocation=@OrderLocation where OrderStateID = @OrderStateID;
   set @CurrentID=@OrderStateID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Delete a orderState
create PROC Proc_DeleteOrderState(@OrderStateID int, @CurrentID int output)
as
begin try
 if(not exists(select * from OrderStates where OrderStateID=@OrderStateID))
  begin
   set @CurrentID=-1
   return
  end
  delete OrderStates where OrderStateID=@OrderStateID;
  set @CurrentID=@OrderStateID;
end try
begin catch
 set @CurrentID=0
 end catch
GO