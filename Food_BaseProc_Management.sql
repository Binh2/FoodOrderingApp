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
set @ifExists = N'if(exists(select * from ' + @pluralTable + N' where ' + @uniqueColumn + N'=' + @uniqueValue + N')) ';
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

create proc Proc_Update(@pluralTable nvarchar(max), @parameters nvarchar(max),
	@uniqueColumn nvarchar(max), @uniqueValue nvarchar(max), @IDColumn nvarchar(max), @IDValue nvarchar(max), 
	@CurrentID int output)
as
declare @update nvarchar(max), @proc nvarchar(max), @ifExists nvarchar(max);
--declare @CurrentID int;
set @ifExists = N'if(exists(select * from ' + @pluralTable + N' where ' + @uniqueColumn + N'=' + @uniqueValue + N')) ';
set @update = N'update ' + @pluralTable + N' set ' + @parameters + N' where ' + @IDColumn + N'=' + @IDValue + N';';
set @proc = 
	N'begin try ' +
	   @ifExists +
	N'  begin ' +
	     @update +
	N'   set @CurrentID=' + @IDValue + N';' +
	N'   return;' +
	N'  end ' +
	N'end try ' +
	N'begin catch ' +
	N' set @CurrentID=0;' +
	N'end catch ';
exec sp_executesql @proc, N'@CurrentID int output', @CurrentID output;
go

create proc Proc_Delete(@pluralTable nvarchar(max),
	@uniqueColumn nvarchar(max), @uniqueValue nvarchar(max), @IDColumn nvarchar(max), @IDValue nvarchar(max), 
	@CurrentID int output)
as
declare @delete nvarchar(max), @proc nvarchar(max), @ifNotExists nvarchar(max);
--declare @CurrentID int;
set @ifNotExists = N'if(not exists(select * from ' + @pluralTable + N' where ' + @uniqueColumn + N'=' + @uniqueValue + N')) ';
set @delete = N'delete ' + @pluralTable + N' where ' + @IDColumn + N'=' + @IDValue + N';';
set @proc = 
	N'begin try ' +
	   @ifNotExists +
	N'  begin ' +
	N'   set @CurrentID=-1;' +
	N'   return;' +
	N'  end ' +
	    @delete +
	N'  set @CurrentID=' + @IDValue + N';' +
	N'end try ' +
	N'begin catch ' +
	N' set @CurrentID=0;' +
	N'end catch ';
exec sp_executesql @proc, N'@CurrentID int output', @CurrentID output;
go

create proc Proc_Get(@proc nvarchar(max))
as
exec(@proc)
go

create proc Proc_Post(@proc nvarchar(max), @CurrentID int output)
as
exec sp_executesql @proc, N'@CurrentID int output', @CurrentID output;
go