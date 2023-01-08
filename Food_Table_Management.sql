-------------------- Delete all tables -----------------------------
use FOOD_MANAGEMENT;
DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR
SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME
OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql
WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END
CLOSE @Cursor DEALLOCATE @Cursor
GO
EXEC sp_MSforeachtable 'DROP TABLE ?'
GO
--//---------------- Delete all tables --------------------------//--


CREATE DATABASE FOOD_MANAGEMENT
use FOOD_MANAGEMENT;
create table Categories(
	CategoryID			INT IDENTITY (1, 1) PRIMARY KEY,
	CategoryName		NVARCHAR(MAX) not null,
	CategoryImage		NVARCHAR(MAX) not null
);

create table Cards(
	CardID				INT IDENTITY (1, 1) PRIMARY KEY,
	CardNumber			NVARCHAR(MAX) not null,
	CardImage			NVARCHAR(MAX) not null,
	CardTypeID			INT not null,
	ConsumerID			INT not null
);
create table CardTypes(
	CardTypeID			INT IDENTITY (1, 1) PRIMARY KEY,
	CardTypeName		NVARCHAR(MAX) not null
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
create table FoodRatings(
	ConsumerID			int not null,
	FoodID				int not null,
	primary key (ConsumerID, FoodID)
);
create table FoodFavourites(
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

create table Producers(
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

create table Comments (
	CommentID			INT IDENTITY (1, 1) PRIMARY KEY,
	CommentDetail		NVARCHAR(MAX),
	FoodID				int not null,
	ConsumerID			int not null
);
create table Restaurants (
	RestaurantID		INT IDENTITY (1, 1) PRIMARY KEY,
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

ALTER TABLE Foods ADD CONSTRAINT Foods_CategoryID_FK FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE Foods ADD CONSTRAINT Foods_RestaurantID_FK FOREIGN KEY (RestaurantID) REFERENCES Restaurants(RestaurantID);


INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Hamburger','/WEBAPI/Images/Hatch_Green_Chile_Hamburger.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Shusi','/WEBAPI/Images/shishi.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Noodles','/WEBAPI/Images/noodle.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Drinks','/WEBAPI/Images/coca.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Milktea','/WEBAPI/Images/milktea.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Rice','/WEBAPI/Images/rice.jpg')

INSERT INTO Restaurants(RestaurantName) VALUES ('Đặng Văn Hải')

INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Hamburger trứng',
'/WEBAPI/Images/Hatch_Green_Chile_Hamburger.jpg','Hamburger trứng ngon','15000','4,5','YES',1,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cocacola',
'/WEBAPI/Images/coca.jpg','Cocacola ngon','15000','4,5','YES',4,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Mì xào',
'/WEBAPI/Images/noodle.jpg','Mì xào ngon','15000','4,6','YES',3,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cơm',
'/WEBAPI/Images/rice.jpg','Cơm ngon','15000','3,0','YES',6,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cơm tấm',
'/WEBAPI/Images/comtam.jpg','Cơm tấm ngon','15000','3,7','YES',6,1)
--TÌM SỐ LƯỢNG --
SELECT CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Foods
  GROUP BY CategoryID;
GO

INSERT INTO Cards(CardNumber, CardImage, CardTypeID, ConsumerID) VALUES ('1234', 'card.png', 1, 1);
select * from cards;

