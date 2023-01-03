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
CREATE proc [Proc_GetAllCategories]
as
select * from Categories
GO

--LẤY TẤT CẢ LOẠI HÀNG--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetAllFoods]
as
select * from Foods
GO

-- LIST THỨC ĂN THEO LOẠI--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetFoodsByCategoryID](@categoryid int)
as
select * from Foods where CategoryID=@categoryid
GO
/******GET Foods BY CATEID ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetBooksBySubjectID](@macd int)
as
select * from SACH where Mcd=@macd
GO
--TOP 4 SỐ LƯỢNG ĐỒ ĂN TRONG LOẠI
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetTOP3CategoryBySL]
as
SELECT TOP 4 CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Foods
  GROUP BY CategoryID;
GO

-- Get top n categories
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC Proc_GetNCategories(@n INT)
AS
SELECT TOP (@n) * FROM Categories;
GO

-- Get all cards
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC Proc_GetAllCards
AS
SELECT * FROM Cards;
GO

-- Insert a card
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC Proc_InsertCard(@CardNumber nvarchar(max), @CardImage nvarchar(max), @CardTypeID int, @ConsumerID int)
AS
INSERT INTO Cards(CardNumber, CardImage, CardTypeID, ConsumerID) VALUES (@CardNumber, @CardImage, @CardTypeID, @ConsumerID);
GO