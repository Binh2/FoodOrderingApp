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
select CategoryID, CategoryName, 'http://'+@IP+CategoryImage CategoryImage from Categories;
GO
--LẤY TẤT CẢ LOẠI HÀNG--
CREATE proc [Proc_GetAllFoods](@IP nvarchar(max))
as
select FoodID, FoodName, 'http://'+@IP+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID from Foods;
GO

-- LIST THỨC ĂN THEO LOẠI--
CREATE proc [dbo].[Proc_GetFoodsByCategoryID](@IP nvarchar(max), @categoryid int)
as
select FoodID, FoodName, 'http://'+@IP+FoodImages FoodImages, 
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
select TOP 4 With Ties FoodRating,FoodID, FoodName,'http://'+@IP+FoodImages FoodImages, 
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
SELECT TOP 4 FoodName,FoodRating ,FoodDetail,'http://'+@IP+FoodImages FoodImages,FoodPrice, FoodFavourite, CategoryID, RestaurantID,FoodID
  FROM Foods
GO

--Lấy thông tin thức ăn
CREATE proc [dbo].[Proc_GetFoodByID](@IP nvarchar(max), @foodid int)
as
select FoodID, FoodName, 'http://'+@IP+FoodImages FoodImages, 
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
CREATE PROC Proc_GetAllCards
AS
SELECT * FROM Cards;
GO

-- Select card by ConsumerID
CREATE PROC Proc_GetCardsByConsumerID(@ConsumerID int)
AS
SELECT * FROM Cards where ConsumerID = @ConsumerID;
GO

-- Insert a card
CREATE PROC dbo.Proc_InsertCard(
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
	@CardTypeID int,
	@CurrentID int output)
as	
begin try
 if(exists(select * from Cards where CardID=@CardID))
  begin
   update Cards set CardNumber = @CardNumber, CardImage = @CardImage, CardExpiryDate = @CardExpiryDate, CardTypeID = @CardTypeID 
   where CardID = @CardID
   set @CurrentID=@CardID
   return
  end
end try
begin catch
 set @CurrentID=0
 end catch
GO

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
