use FOOD_MANAGEMENT;
DROP TABLE Category;
DROP TABLE Comment;
DROP TABLE Food;
DROP TABLE Restaurant;
DROP TABLE Roles;
DROP TABLE Users;
drop DATABASE FOOD_MANAGEMENT;

------ To drop database that is currently in use ------
DECLARE @DatabaseName nvarchar(50)
SET @DatabaseName = N'YOUR_DABASE_NAME'

DECLARE @SQL varchar(max)

SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
FROM MASTER..SysProcesses
WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

--SELECT @SQL 
EXEC(@SQL)
------ To drop database that is currently in use ------

CREATE DATABASE FOOD_MANAGEMENT
use FOOD_MANAGEMENT;
create table Categories(
	CategoryID			INT IDENTITY (1, 1) PRIMARY KEY,
	CategoryName		NVARCHAR(MAX) not null,
	CategoryImage		NVARCHAR(MAX) not null
);

create table CreditCards(
	CreditCardID		INT IDENTITY (1, 1) PRIMARY KEY,
	CreditCardName		NVARCHAR(MAX) not null,
	CreditCardImage		NVARCHAR(MAX) not null,
	CreditCardTypeID	INT not null
);
create table CreditCardTypes(
	CreditCardTypeID	INT IDENTITY (1, 1) PRIMARY KEY,
	CreditCardTypeName	NVARCHAR(MAX) not null
);

create table Foods(
	FoodID				INT IDENTITY (1, 1) PRIMARY KEY,
	FoodName			NVARCHAR(MAX) not null,
	FoodImages			NVARCHAR(MAX) not null,
	FoodDetail			NVARCHAR(MAX),
	FoodPrice			FLOAT(53) not null,
	FoodRating			NVARCHAR(MAX),	-- Can be here for faster calculation
	FoodFavourite		NVARCHAR(MAX),	-- Not suppose to be here
	CategoryID			INT,
	RestaurantID		INT not null
);
create table FoodRating(
	ConsumerID			int not null,
	FoodID				int not null,
	primary key (ConsumerID, FoodID)
);
create table FoodFavourite(
	ConsumerID			int not null,
	FoodID				int not null,
	primary key (ConsumerID, FoodID)
);

create table Orders(
	OrderID				int IDENTITY (1, 1) PRIMARY KEY,
	ConsumerID			int not null,
	FoodID				int not null,
);
create table OrderStates(
	OrderID				int not null,
	OrderStateTypeID	int not null,
	OrderDate			date not null,
	OrderLocation		NVARCHAR(MAX) not null
);
create table OrderStateTypes(
	OrderStateTypeID	int IDENTITY (1, 1) PRIMARY KEY,
	OrderStateTypeName	int not null
);

create table Consumers(
	ConsumerID			int IDENTITY (1, 1) PRIMARY KEY,
	ConsumerName		nvarchar(MAX) not null,
	ConsumerEmail		nvarchar(MAX) not null,
	ConsumerImage		nvarchar(MAX),
	ConsumerPassword	nvarchar(MAX) not null
);

create table Producer(
	ProducerID			int IDENTITY (1, 1) PRIMARY KEY,
	ProducerName		nvarchar(MAX) not null,
	ProducerEmail		nvarchar(MAX) not null,
	ProducerImage		nvarchar(MAX),
	ProducerPassword	nvarchar(MAX) not null,
	RestaurantID		int not null
);

create table Admins(
	AdminID				int IDENTITY (1, 1) PRIMARY KEY,
	AdminName			nvarchar(MAX) not null,
	AdminEmail			nvarchar(MAX) not null,
	AdminImage			nvarchar(MAX),
	AdminPassword		nvarchar(MAX) not null
);

create table Comment (
	CommentID			INT IDENTITY (1,1) PRIMARY KEY,
	CommentDetail		NVARCHAR(MAX),
	FoodID				int not null,
	ConsumerID			int not null
);
create table Restaurant (
	RestaurantID		INT IDENTITY (1 , 1) PRIMARY KEY,
	RestaurantName		NVARCHAR(MAX) not null,
	RestaurantImage		NVARCHAR(MAX)
);

create table Users( -- this table will be removed in the future because already have Consumer, Producer and Manager table
	UserID				int IDENTITY (1, 1) PRIMARY KEY,
	StaffID				int not null,
	RoleID				int not null,
	UserName			nvarchar(MAX) not null,
	UserEmail			nvarchar(MAX) not null,
	UserImage			nvarchar(MAX) not null,
	UserPassword		nvarchar(MAX) not null
);

CREATE TABLE Roles ( -- this table will be removed in the future because already have Consumer, Producer and Manager table 
	RoleID		int IDENTITY (1, 1) PRIMARY KEY,  -- 1: staff, 2: admin --
	RoleName	nvarchar(MAX) not null
);

ALTER TABLE Foods ADD CONSTRAINT Food_CategoryID_FK FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE Foods ADD CONSTRAINT Food_RestaurantID_FK FOREIGN KEY (RestaurantID) REFERENCES Restaurant(RestaurantID);


INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Hamburger','http://192.168.2.13/WEBAPI/Images/Hatch_Green_Chile_Hamburger.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Shusi','http://192.168.2.13/WEBAPI/Images/shishi.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Noodles','http://192.168.2.13/WEBAPI/Images/noodle.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Drinks','http://192.168.2.13/WEBAPI/Images/coca.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Milktea','http://192.168.2.13/WEBAPI/Images/milktea.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Rice','http://192.168.2.13/WEBAPI/Images/rice.jpg')

INSERT INTO Restaurant  (RestaurantName) VALUES ('Đặng Văn Hai')


INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Hamburger trứng',
'http://192.168.2.13/WEBAPI/Images/Hatch_Green_Chile_Hamburger.jpg','Hamburger trứng ngon','15000','4,5','YES',1,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cocacola',
'http://192.168.2.13/WEBAPI/Images/coca.jpg','Cocacola ngon','15000','4,5','YES',4,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Mì xào',
'http://192.168.2.13/WEBAPI/Images/noodle.jpg','Mì xào ngon','15000','4,6','YES',3,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cơm',
'http://192.168.2.13/WEBAPI/Images/rice.jpg','Cơm ngon','15000','3,0','YES',6,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cơm tấm',
'http://192.168.2.13/WEBAPI/Images/comtam.jpg','Cơm tấm ngon','15000','3,7','YES',6,1)
--TÌM SỐ LƯỢNG --
SELECT CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Foods
  GROUP BY CategoryID;
--LẤY TẤT CẢ LOẠI HÀNG--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetAllCategory]
as
select * from Categories
GO

--LẤY TẤT CẢ LOẠI HÀNG--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetAllFood]
as
select * from Foods
GO

-- LIST THỨC ĂN THEO LOẠI chính--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetFoodBycategoryID](@categoryid int)
as
select * from Foods where CategoryID=@categoryid
GO
--TOP 4 SỐ LƯỢNG ĐỒ ĂN TRONG LOẠI
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetTOP3CategoryBySL]
as
SELECT TOP 4 CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Food
  GROUP BY CategoryID;

--Lấy thông tin thức ăn
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetFoodByID](@foodid int)
as
select * from Foods where FoodID=@foodid
GO