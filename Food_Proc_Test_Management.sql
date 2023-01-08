-- Execute Proc_Insert
declare @CurrentID int;
exec Proc_Insert @pluralTable=N'Cards', @parameterColumns=N'CardNumber, CardImage, CardExpiryDate, CardTypeID, ConsumerID', 
	@parameterValues=N'''7227 0123 4567 8901'', ''/WEBAPI/Images/visa-card1.png'', ''2024-01-01'', ''1'', 1', 
	@uniqueColumn=N'CardNumber', @uniqueValue=N'''8227 0123 4567 8901''', @CurrentID = @CurrentID output;
select @CurrentID;
select * from Cards;
go

-- Execute Proc_Update
declare @CurrentID int;
exec Proc_Update @pluralTable=N'Cards', @parameters=N'CardNumber=''1''', 
	@uniqueColumn=N'CardNumber', @uniqueValue=N'''7227 0123 4567 8901''', @tableID=N'CardID', @tableIDValue=N'1', 
	@CurrentID = @CurrentID output;
select @CurrentID;
select * from Cards;
go

-- Execute Proc_Delete
declare @CurrentID int;
exec Proc_Delete @pluralTable=N'Cards',
	@uniqueColumn=N'CardID', @uniqueValue=N'1', @tableID=N'CardID', @tableIDValue=N'1', 
	@CurrentID = @CurrentID output;
select @CurrentID;
select * from Cards;
go