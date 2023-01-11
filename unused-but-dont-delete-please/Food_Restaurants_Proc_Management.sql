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

--Select all restaurants
CREATE proc Proc_SelectAllRestaurants
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
