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
