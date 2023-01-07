﻿-- Execute every connect please
USE FOOD_MANAGEMENT; go
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
/******GET Foods BY CATEID ******/
CREATE proc [dbo].[Proc_GetBooksBySubjectID](@macd int)
as
select * from SACH where Mcd=@macd
GO
--TOP 4 SỐ LƯỢNG ĐỒ ĂN TRONG LOẠI
CREATE proc [dbo].[Proc_GetTOP3CategoryBySL]
as
SELECT TOP 4 CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Foods
  GROUP BY CategoryID;
GO

--Lấy thông tin thức ăn
CREATE proc [dbo].[Proc_GetFoodByID](@IP nvarchar(max), @foodid int)
as
select FoodID, FoodName, 'http://'+@IP+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID  from Foods where FoodID=@foodid
GO


-- Get all cards
CREATE PROC Proc_GetAllCards(@IP nvarchar(max))
AS
SELECT CardID, CardNumber, 'http://'+@IP+CardImage CardImage, CardExpiryDate, CardTypeID, ConsumerID FROM Cards;
GO

-- Get cards by ConsumerID
CREATE PROC Proc_GetCardsByConsumerID(@IP nvarchar(max), @ConsumerID int)
AS
SELECT CardID, CardNumber, 'http://'+@IP+CardImage CardImage, CardExpiryDate, CardTypeID, ConsumerID FROM Cards where;
GO

-- Insert a card
CREATE PROC dbo.Proc_InsertCard(
	@CardNumber nvarchar(max), 
	@CardImage nvarchar(max), 
	@CardExpiryDate date,
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
 insert into Cards(CardNumber, CardImage, CardTypeID, ConsumerID) VALUES (@CardNumber, @CardImage, @CardTypeID, @ConsumerID);
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


select * from Cards;

exec Proc_DeleteCard @CardID = 3, @CurrentID = 0;
select * from Cards;

delete from Cards where CardID=2;
select * from Cards;
select * from Foods