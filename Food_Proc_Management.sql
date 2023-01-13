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

--LẤY TẤT CẢ LOẠI HÀNG--
CREATE proc [Proc_GetAllCategories](@IP nvarchar(max))
as
select CategoryID, CategoryName, 'http://'+@IP+'/WEBAPI/Images/'+CategoryImage CategoryImage from Categories;
GO
--LẤY TẤT CẢ LOẠI HÀNG--
CREATE proc [Proc_GetAllFoods](@IP nvarchar(max))
as
select FoodID, FoodName, 'http://'+@IP+'/WEBAPI/Images/'+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID from Foods;
GO

-- LIST THỨC ĂN THEO LOẠI--
CREATE proc [dbo].[Proc_GetFoodsByCategoryID](@IP nvarchar(max), @categoryid int)
as
select FoodID, FoodName, 'http://'+@IP+'/WEBAPI/Images/'+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID from Foods where CategoryID=@categoryid
GO

--TOP 4 SỐ LƯỢNG ĐỒ ĂN TRONG LOẠI
CREATE proc [dbo].[Proc_GetTOP3CategoryBySL]
as
SELECT TOP 4 COUNT(CategoryID) AS "So luong",CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Foods
  GROUP BY CategoryID;
GO


--TOP 4 RATING
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetTOP4FoodByRATES](@IP nvarchar(max))
as
select TOP 4 With Ties FoodRating,FoodID, FoodName,'http://'+@IP+'/WEBAPI/Images/'+FoodImages FoodImages, 
	FoodDetail, FoodPrice,FoodFavourite, CategoryID, RestaurantID from Foods
	ORDER BY FoodRating DESC	
GO
--TOP 4 FoodName
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetTOP4NAME](@IP nvarchar(max))
as
SELECT TOP 4 FoodName,FoodRating ,FoodDetail,'http://'+@IP+'/WEBAPI/Images/'+FoodImages FoodImages,FoodPrice, FoodFavourite, CategoryID, RestaurantID,FoodID
  FROM Foods
GO

--Lấy thông tin thức ăn
CREATE proc [dbo].[Proc_GetFoodByID](@IP nvarchar(max), @foodid int)
as
select FoodID, FoodName, 'http://'+@IP+'/WEBAPI/Images/'+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID  from Foods where FoodID=@foodid
GO

-- Get all food
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC Proc_GetFoods
AS
SELECT TOP 4 FoodRating,* FROM Foods;
GO



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
--exec Proc_UpdateCard @CardID=1, @CardNumber='1', @CardImage='2', @CardExpiryDate='2024-01-01', @CardBalance=0.5, @CardTypeID=1, @CurrentID=0

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



--Select all consumers
CREATE proc Proc_SelectAllConsumers
as
select * from Consumers;
GO
-- Select a consumer by ConsumerID
CREATE proc Proc_SelectConsumersByID(@ConsumerID int)
as
select * from Consumers where ConsumerID = @ConsumerID;
GO
-- Select a consumer by ConsumerUsername
CREATE proc Proc_SelectConsumersByUsername(@ConsumerUsername nvarchar(max))
as
select * from Consumers where ConsumerUsername = @ConsumerUsername;
GO

-- Select a consumer by ConsumerEmail
CREATE proc Proc_SelectConsumersByEmail(@ConsumerEmail nvarchar(max))
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
	on OrdersOrderStates.OrderID = OrdersOrderFoods.OrderID and OrdersOrderStates.ConsumerID = OrdersOrderFoods.ConsumerID 
	order by OrdersOrderStates.OrderDate desc;
GO

-- Select orders by ConsumerID
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
	on OrdersOrderStates.OrderID = OrdersOrderFoods.OrderID and OrdersOrderStates.ConsumerID = OrdersOrderFoods.ConsumerID
	order by OrdersOrderStates.OrderDate desc;
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
	@OrderID	int,
	@FoodID	int,
	@FoodQuantity int,
	@FoodPrice float(53),
	@CurrentID int output)
as
begin try
 insert into OrderFoods(OrderID,FoodID,FoodQuantity,FoodPrice) VALUES 
  (@OrderID,@FoodID,@FoodQuantity,@FoodPrice);
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



--Select all restaurants
CREATE proc Proc_SelectAllRestaurants
as
select * from Restaurants;
GO
CREATE proc Proc_SelectAllRestaurantss
as
select * from Restaurants;
GO
-- Select a restaurant by RestaurantID
CREATE proc Proc_SelectRestaurantByID(@RestaurantID int)
as
select * from Restaurants where RestaurantID = @RestaurantID;
GO
-- Insert a restaurant
CREATE PROC dbo.Proc_InsertRestaurant(
	@RestaurantName		nvarchar(MAX),
	@RestaurantImage		nvarchar(MAX),
	@RestaurantLocation	nvarchar(max),
	@CurrentID int output)
as
begin try
 insert into Restaurants(RestaurantName,RestaurantImage,RestaurantLocation) VALUES 
 (@RestaurantName,@RestaurantImage,@RestaurantLocation);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Update a restaurant
CREATE PROC dbo.Proc_UpdateRestaurant(
	@RestaurantID			int,
	@RestaurantName		nvarchar(MAX),
	@RestaurantImage		nvarchar(MAX),
	@RestaurantLocation		nvarchar(max),
	@CurrentID int output)
as	
begin try
 if(exists(select * from Restaurants where RestaurantID=@RestaurantID))
  begin
   update Restaurants set RestaurantName=@RestaurantName, RestaurantImage=@RestaurantImage, 
    RestaurantLocation=@RestaurantLocation
   where RestaurantID = @RestaurantID;
   set @CurrentID=@RestaurantID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Delete a restaurant
create PROC Proc_DeleteRestaurant(@RestaurantID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Restaurants where RestaurantID=@RestaurantID))
  begin
   set @CurrentID=-1
   return
  end
  delete Restaurants where RestaurantID=@RestaurantID;
  set @CurrentID=@RestaurantID;
end try
begin catch
 set @CurrentID=0
 end catch
GO



--Select all producers
CREATE proc Proc_SelectAllProducers
as
select * from Producers;
GO
-- Select a producer by ProducerID
CREATE proc Proc_SelectProducerByID(@ProducerID int)
as
select * from Producers where ProducerID = @ProducerID;
GO
-- Select a producer by ProducerUsername
CREATE proc Proc_SelectProducerByUsername(@ProducerUsername nvarchar(max))
as
select * from Producers where ProducerUsername = @ProducerUsername;
GO
-- Select a producer by ProducerEmail
CREATE proc Proc_SelectProducerByEmail(@ProducerEmail nvarchar(max))
as
select * from Producers where ProducerEmail = @ProducerEmail;
GO
-- Insert a producer
CREATE PROC dbo.Proc_InsertProducer(
	@ProducerName		nvarchar(MAX),
	@ProducerEmail		nvarchar(MAX),
	@ProducerImage		nvarchar(MAX),
	@ProducerUsername	nvarchar(max),
	@ProducerPassword	nvarchar(MAX),
	@RestaurantID		int,
	@CurrentID int output)
as
begin try
 if(exists(select * from Producers where ProducerUsername=@ProducerUsername))
  begin
   set @CurrentID=0
   return
  end
 insert into Producers(ProducerName,ProducerEmail,ProducerImage,ProducerUsername,ProducerPassword,RestaurantID) VALUES 
 (@ProducerName,@ProducerEmail,@ProducerImage,@ProducerUsername,@ProducerPassword,@RestaurantID);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Update a producer
CREATE PROC dbo.Proc_UpdateProducer(
	@ProducerID			int,
	@ProducerName		nvarchar(MAX),
	@ProducerEmail		nvarchar(MAX),
	@ProducerImage		nvarchar(MAX),
	@ProducerUsername	nvarchar(max),
	@ProducerPassword	nvarchar(MAX),
	@RestaurantID		int,
	@CurrentID int output)
as	
begin try
 if(exists(select * from Producers where ProducerID=@ProducerID))
  begin
   update Producers set ProducerName=@ProducerName, ProducerEmail=@ProducerEmail, 
   ProducerImage = @ProducerImage, ProducerUsername = @ProducerUsername, ProducerPassword = @ProducerPassword, RestaurantID=@RestaurantID
   where ProducerID = @ProducerID;
   set @CurrentID=@ProducerID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Delete a producer
create PROC Proc_DeleteProducer(@ProducerID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Producers where ProducerID=@ProducerID))
  begin
   set @CurrentID=-1
   return
  end
  delete Producers where ProducerID=@ProducerID;
  set @CurrentID=@ProducerID;
end try
begin catch
 set @CurrentID=0
 end catch
GO



--Select all comments
CREATE proc Proc_SelectAllComments
as
select * from Comments join Consumers on Comments.ConsumerID=Consumers.ConsumerID order by CommentDate desc;
GO
-- Select a comment by CommentID
CREATE proc Proc_SelectCommentByFoodID(@FoodID int)
as
select * from Comments join Consumers on Comments.ConsumerID=Consumers.ConsumerID where @FoodID = @FoodID order by CommentDate desc;
GO
-- Insert a comment
CREATE PROC dbo.Proc_InsertComment(
	@CommentStar			int,
	@CommentDetail		NVARCHAR(MAX),
	@CommentDate		date,
	@FoodID				int,
	@ConsumerID			int,
	@CurrentID int output)
as
begin try
 insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) VALUES 
 (@CommentStar,@CommentDetail,@CommentDate,@FoodID,@ConsumerID);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO

-- Update a comment
CREATE PROC dbo.Proc_UpdateComment(
	@CommentID			int,
	@CommentStar		int,
	@CommentDetail		NVARCHAR(MAX),
	@CommentDate		date,
	@FoodID				int,
	@ConsumerID			int,
	@CurrentID int output)
as	
begin try
 if(exists(select * from Comments where CommentID=@CommentID))
  begin
   update Comments set CommentStar=@CommentStar, CommentDetail=@CommentDetail, 
    CommentDate=@CommentDate, FoodID=@FoodID, ConsumerID=@ConsumerID
   where CommentID = @CommentID;
   set @CurrentID=@CommentID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Delete a comment
create PROC Proc_DeleteComment(@CommentID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Comments where CommentID=@CommentID))
  begin
   set @CurrentID=-1
   return
  end
  delete Comments where CommentID=@CommentID;
  set @CurrentID=@CommentID;
end try
begin catch
 set @CurrentID=0
 end catch
GO


-- Insert a food
CREATE PROC dbo.Proc_InsertFood(
	@FoodName	NVARCHAR(MAX),
	@FoodImages NVARCHAR(MAX),
	@CategoryID	int	,
	@FoodPrice  int,
	@FoodDetail	int,
	@FoodRating int,
	@RestaurantID int,
	@FoodFavourite int,
	@CurrentID int output)
as
begin try
 insert into Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES 
 (@FoodName,@FoodImages,@FoodDetail,@FoodPrice,0,0,@CategoryID,@RestaurantID);
 set @CurrentID=@@IDENTITY
end try
begin catch
 set @CurrentID=0
 end catch
GO
USE FOOD_MANAGEMENT; 
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Select a food by foodid
CREATE proc [dbo].[Proc_GetIDByCategoryName](@IP nvarchar(max),@CategoryName nvarchar(MAX))
as
select CategoryID, CategoryName, 'http://'+@IP+'/WEBAPI/Images/'+CategoryImage CategoryImages from Categories where CategoryName=@CategoryName
GO

--update food
CREATE PROC dbo.Proc_UpdateFood(
	@FoodID     int,
    @FoodName	NVARCHAR(MAX),
	@FoodImages NVARCHAR(MAX),
	@CategoryID	int	,
	@FoodPrice  int,
	@FoodDetail	int,
	@FoodRating int,
	@RestaurantID int,
	@FoodFavourite int,
	@CurrentID int output)	
as	
begin try
 if(exists(select * from Foods where FoodID=@FoodID))
  begin
   update Foods set FoodName=@FoodName, FoodImages=@FoodImages, 
   CategoryID = @CategoryID, FoodPrice = @FoodPrice, FoodDetail = @FoodDetail,FoodRating=FoodRating,RestaurantID=RestaurantID,FoodFavourite=FoodFavourite
   where FoodID = @FoodID;
   set @CurrentID=@FoodID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO
-- Delete a producer
create PROC Proc_DeleteFood(@FoodID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Foods where FoodID=@FoodID))
  begin
   set @CurrentID=-1
   return
  end
  delete Foods where FoodID=@FoodID;
  set @CurrentID=@FoodID;
end try
begin catch
 set @CurrentID=0
 end catch
GO
--SelectRestaurantByProducerID
CREATE PROC Proc_SelectRestaurantByProducerID(@RestaurantID int)
AS
SELECT * FROM Restaurants join Producers on Producers.RestaurantID = Restaurants.RestaurantID where Producers.RestaurantID = @RestaurantID;
GO

--SelectRestaurantByProducerID
CREATE PROC Proc_SelectFoodByProducerID(@RestaurantID int)
AS
SELECT * FROM Restaurants join Producers on Producers.RestaurantID = Restaurants.RestaurantID where Producers.RestaurantID = @RestaurantID;
GO