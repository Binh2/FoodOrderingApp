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

--Select all orders
CREATE proc Proc_SelectAllOrders
as
select * from
	(select Orders.OrderID, Orders.ConsumerID, max(OrderDate) OrderDate, max(OrderStateTypeID) OrderStateTypeID
		from Orders 
		join OrderStates on Orders.OrderID=OrderStates.OrderID
		group by Orders.OrderID, Orders.ConsumerID)	OrdersOrderStates
	join
	(select Orders.OrderID, Orders.ConsumerID, sum(OrderFoods.FoodQuantity*OrderFoods.FoodPrice) OrderPrice, string_agg(FoodImages, '|') FoodImages
		from Orders 
		join OrderFoods on Orders.OrderID=OrderFoods.OrderID
		join Foods on OrderFoods.FoodID = Foods.FoodID
		group by Orders.OrderID, Orders.ConsumerID) OrdersOrderFoods
	on OrdersOrderStates.OrderID = OrdersOrderFoods.OrderID and OrdersOrderStates.ConsumerID = OrdersOrderFoods.ConsumerID;
GO

-- Select a order by ConsumerID
CREATE proc Proc_SelectOrdersByConsumerID(@ConsumerID int)
as
select * from
	(select Orders.OrderID, Orders.ConsumerID, max(OrderDate) OrderDate, max(OrderStateTypeID) OrderStateTypeID
		from Orders 
		join OrderStates on Orders.OrderID=OrderStates.OrderID
		where ConsumerID=@ConsumerID
		group by Orders.OrderID, Orders.ConsumerID)	OrdersOrderStates
	join
	(select Orders.OrderID, Orders.ConsumerID, sum(OrderFoods.FoodQuantity*OrderFoods.FoodPrice) OrderPrice, string_agg(FoodImages, '|') FoodImages
		from Orders 
		join OrderFoods on Orders.OrderID=OrderFoods.OrderID
		join Foods on OrderFoods.FoodID = Foods.FoodID
		where ConsumerID=@ConsumerID
		group by Orders.OrderID, Orders.ConsumerID) OrdersOrderFoods
	on OrdersOrderStates.OrderID = OrdersOrderFoods.OrderID and OrdersOrderStates.ConsumerID = OrdersOrderFoods.ConsumerID;
GO

-- Insert a order
CREATE PROC Proc_InsertOrder(
	@ConsumerID		int,
	@CurrentID int output)
as
begin try
 insert into Orders(ConsumerID) VALUES (@ConsumerID);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO

-- Update a order
CREATE PROC dbo.Proc_UpdateOrder(
	@OrderID		int,
	@ConsumerID		int,
	@CurrentID int output)
as	
begin try
 if(exists(select * from Orders where OrderID=@OrderID))
  begin
   update Orders set ConsumerID=@ConsumerID where OrderID = @OrderID;
   set @CurrentID=@OrderID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO

-- Delete a order
create PROC Proc_DeleteOrder(@OrderID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Orders where OrderID=@OrderID))
  begin
   set @CurrentID=-1
   return
  end
  delete Orders where OrderID=@OrderID;
  set @CurrentID=@OrderID;
end try
begin catch
 set @CurrentID=0
 end catch
GO
