USE FOOD_MANAGEMENT;
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetAllCategories](@IP nvarchar(max))
as
select CategoryID, CategoryName, 'http://'+@IP+CategoryImage CategoryImage from Categories;
GO
--LẤY TẤT CẢ LOẠI HÀNG--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetAllFoods](@IP nvarchar(max))
as
select FoodID, FoodName, 'http://'+@IP+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID from Foods;
GO

-- LIST THỨC ĂN THEO LOẠI--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetFoodsByCategoryID](@IP nvarchar(max), @categoryid int)
as
select FoodID, FoodName, 'http://'+@IP+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID from Foods where CategoryID=@categoryid
GO
--TOP 4 SỐ LƯỢNG ĐỒ ĂN TRONG LOẠI
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetFoodByID](@IP nvarchar(max), @foodid int)
as
select FoodID, FoodName, 'http://'+@IP+FoodImages FoodImages, 
	FoodDetail, FoodPrice, FoodRating, FoodFavourite, CategoryID, RestaurantID  from Foods where FoodID=@foodid
GO


-- Get all cards
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC Proc_GetAllCards
AS
SELECT CardID, CardNumber, CardImage, CardTypeID, ConsumerID FROM Cards;
GO

-- Insert a card
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC dbo.Proc_InsertCard(
	@CardNumber nvarchar(max), 
	@CardImage nvarchar(max), 
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

-- Insert a fake card
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC dbo.Proc_InsertFakeCard(
	@CurrentID int output)
as	
begin try
 insert into Cards(CardNumber, CardImage, CardTypeID, ConsumerID) VALUES ('123456789', 'image.png', 5, 5);
 set @CurrentID=@@IDENTITY
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


exec Proc_InsertCard @CardNumber = '123', @CardImage = 'card3.png', @CardTypeID = 3, @ConsumerID = 3, @CurrentID = 0;
exec Proc_InsertCard @CardNumber = '1234', @CardImage = 'card3.png', @CardTypeID = 3, @ConsumerID = 3, @CurrentID = 0;
exec Proc_InsertCard @CardNumber = '12345', @CardImage = 'card3.png', @CardTypeID = 3, @ConsumerID = 3, @CurrentID = 0;
exec Proc_InsertCard @CardNumber = '123456', @CardImage = 'card3.png', @CardTypeID = 3, @ConsumerID = 3, @CurrentID = 0;
select * from Cards;
insert into Cards select * from Cards;

exec Proc_DeleteCard @CardID = 3, @CurrentID = 0;
select * from Cards;

delete from Cards where CardID=2;
select * from Cards;
select * from Foods
-- Get all food
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC Proc_GetFoods
AS
SELECT TOP 4 FoodRating,* FROM Foods;
GO