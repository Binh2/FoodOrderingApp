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

--exec Proc_UpdateComment @CommentID=5, @CommentName='david', @CommentEmail='david@gmail.com', @CommentImage='david.png', @CommentUsername='david',
--@CommentPassword='123', @CurrentID=0;

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
