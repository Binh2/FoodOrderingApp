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

--Select all orderFoods
CREATE proc Proc_SelectAllOrderFoods
as
select * from OrderFoods 
	join Orders on Orders.OrderID = OrderFoods.OrderID 
	join Foods on Foods.FoodID = OrderFoods.FoodID;
GO
-- Select orderFoods by OrderID
CREATE proc Proc_SelectOrderFoodsByOrderID(@OrderID int)
as
select * from OrderFoods 
	join Orders on Orders.OrderID = OrderFoods.OrderID 
	join Foods on Foods.FoodID = OrderFoods.FoodID
	where Orders.OrderID=@OrderID;
GO
-- Insert a orderFood
CREATE PROC Proc_InsertOrderFood(
	@OrderFoodID int,
	@OrderID	int,
	@FoodID	int,
	@FoodQuantity int,
	@FoodPrice float(53),
	@CurrentID int output)
as
begin try
 insert into OrderFoods(OrderFoodID,OrderID,FoodID,FoodQuantity,FoodPrice) VALUES 
  (@OrderFoodID,@OrderID,@FoodID,@FoodQuantity,@FoodPrice);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Update a orderFood
CREATE PROC Proc_UpdateOrderFood(
	@OrderFoodID		int,
	@OrderID	int,
	@FoodID	int,
	@FoodQuantity int,
	@FoodPrice float(53),
	@CurrentID int output)
as	
begin try
 if(exists(select * from OrderFoods where OrderFoodID=@OrderFoodID))
  begin
   update OrderFoods set OrderID=@OrderID,FoodID=@FoodID,FoodQuantity=@FoodQuantity,FoodPrice=@FoodPrice
    where OrderFoodID = @OrderFoodID;
   set @CurrentID=@OrderFoodID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Delete a orderFood
create PROC Proc_DeleteOrderFood(@OrderFoodID int, @CurrentID int output)
as
begin try
 if(not exists(select * from OrderFoods where OrderFoodID=@OrderFoodID))
  begin
   set @CurrentID=-1
   return
  end
  delete OrderFoods where OrderFoodID=@OrderFoodID;
  set @CurrentID=@OrderFoodID;
end try
begin catch
 set @CurrentID=0
 end catch
GO