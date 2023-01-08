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

-- Get all tables
create proc Proc_GetAll(@pluralTable nvarchar(max))
as
declare @proc nvarchar(max);
set @proc = N'select * from ' + @pluralTable;
exec(@proc);
go

-- Get a table by some property in the table
create proc Proc_GetBy(@pluralTable nvarchar(max), @byColumn nvarchar(max), @byValue nvarchar(max))
as
declare @proc nvarchar(max);
set @proc = N'select * from ' + @pluralTable + N' where ' + @byColumn + N'=' + @byValue;
exec(@proc);
go

-- Insert a unique row into a table. Unique depending on @uniqueColumn and @uniqueValue
create proc Proc_Insert(@pluralTable nvarchar(max), @parameterColumns nvarchar(max), @parameterValues nvarchar(max),
	@uniqueColumn nvarchar(max), @uniqueValue nvarchar(max), @CurrentID int output)
as
declare @insert nvarchar(max), @proc nvarchar(max), @ifExists nvarchar(max);
--declare @CurrentID int;
set @ifExists = N' if(exists(select * from ' + @pluralTable + N' where ' + @uniqueColumn + N'=' + @uniqueValue + N')) ';
set @insert = N'insert into ' + @pluralTable + N'(' + @parameterColumns + N') values (' + @parameterValues + N');';
set @proc = 
	N'begin try ' +
	   @ifExists +
	N'  begin ' +
	N'   set @CurrentID=0;' +
	N'   return;' +
	N'  end ' +
	    @insert +
	N' set @CurrentID=@@IDENTITY;' +
	N'end try ' +
	N'begin catch ' +
	N' set @CurrentID=0;' +
	N'end catch ';
exec sp_executesql @proc, N'@CurrentID int output', @CurrentID output;
go

--declare @CurrentID int;
--exec Proc_Insert @pluralTable=N'Cards', @parameterColumns=N'CardNumber, CardImage, CardExpiryDate, CardTypeID, ConsumerID', 
--	@parameterValues=N'''7227 0123 4567 8901'', ''/WEBAPI/Images/visa-card1.png'', ''2024-01-01'', ''1'', 1', 
--	@uniqueColumn=N'CardNumber', @uniqueValue=N'''8227 0123 4567 8901''', @CurrentID = @CurrentID output;
--select @CurrentID;
--select * from Cards;
--go


create proc Proc_Update(@pluralTable nvarchar(max), @parameters nvarchar(max),
	@uniqueColumn nvarchar(max), @uniqueValue nvarchar(max), @tableID nvarchar(max), @tableIDValue nvarchar(max), 
	@CurrentID int output)
as
declare @update nvarchar(max), @proc nvarchar(max), @ifExists nvarchar(max);
--declare @CurrentID int;
set @ifExists = N' if(exists(select * from ' + @pluralTable + N' where ' + @uniqueColumn + N'=' + @uniqueValue + N')) ';
set @update = N'update ' + @pluralTable + N' set ' + @parameters + N' where ' + @tableID + N'=' + @tableIDValue + N';';
set @proc = 
	N'begin try ' +
	   @ifExists +
	N'  begin ' +
	     @update +
	N'   set @CurrentID=' + @tableIDValue + N';' +
	N'   return;' +
	N'  end ' +
	N'end try ' +
	N'begin catch ' +
	N' set @CurrentID=0;' +
	N'end catch ';
exec sp_executesql @proc, N'@CurrentID int output', @CurrentID output;
go

--declare @CurrentID int;
--exec Proc_Update @pluralTable=N'Cards', @parameters=N'CardNumber=''1''', 
--	@uniqueColumn=N'CardNumber', @uniqueValue=N'''7227 0123 4567 8901''', @tableID=N'CardID', @tableIDValue=N'1', 
--	@CurrentID = @CurrentID output;
--select @CurrentID;
--select * from Cards;
--go

-- Update a consumer
CREATE PROC dbo.Proc_UpdateCard(
	@CardID		int,
	@CardNumber nvarchar(max), 
	@CardImage nvarchar(max), 
	@CardExpiryDate date,
	@CardTypeID int,
	@CurrentID int output)
as
begin try
 if(exists(select * from Consumers where CardID=@CardID))
  begin
   update Consumers set CardNumber = @CardNumber, CardImage = @CardImage, CardExpiryDate = @CardExpiryDate, CardTypeID = @CardTypeID 
   where CardID = @CardID
   set @CurrentID=@CardID
   return
  end
end try
begin catch
 set @CurrentID=0
end catch
GO

-- Delete a consumer
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].Proc_DeleteCard(@CardID int, @CurrentID int output)
as
begin try
 if(not exists(select * from Consumers where CardID=@CardID))
  begin
   set @CurrentID=-1
   return
  end
  delete Consumers where CardID=@CardID;
  set @CurrentID=@CardID;
end try
begin catch
 set @CurrentID=0
 end catch
GO