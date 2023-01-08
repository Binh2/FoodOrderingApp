use FOOD_MANAGEMENT; 
go
-------------------- Delete all tables -----------------------------
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
go

create table Cards(
	--CardID				INT IDENTITY (1, 1) PRIMARY KEY,
	--CardNumber			NVARCHAR(MAX) not null,
	--CardImage			NVARCHAR(MAX) not null,
	--CardExpiryDate		date not null,
	--CardTypeID			INT not null,
	--ConsumerID			INT not null
	CardID				INT IDENTITY (1, 1) PRIMARY KEY,
	CardNumber			NVARCHAR(MAX),
	CardImage			NVARCHAR(MAX),
	CardExpiryDate		date,
	CardTypeID			INT,
	ConsumerID			INT
); 
go
create table CardTypes(
	CardTypeID			INT IDENTITY (1, 1) PRIMARY KEY,
	CardTypeName		NVARCHAR(MAX) not null,
	CardTypeImage		nvarchar(max) not null
); 
go

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
go
create table FoodRatings(
	ConsumerID			int not null,
	FoodID				int not null,
	primary key (ConsumerID, FoodID)
); 
go
create table FoodFavourites(
	ConsumerID			int not null,
	FoodID				int not null,
	primary key (ConsumerID, FoodID)
); 
go

create table Orders(
	OrderID				int IDENTITY (1, 1) PRIMARY KEY,
	ConsumerID			int not null,
	FoodID				int not null,
); 
go
create table OrderStates(
	OrderID				int not null,
	OrderStateTypeID	int not null,
	OrderDate			date not null,
	OrderLocation		NVARCHAR(MAX) not null
); 
go
create table OrderStateTypes(
	OrderStateTypeID	int IDENTITY (1, 1) PRIMARY KEY,
	OrderStateTypeName	int not null
); 
go

create table Consumers(
	ConsumerID			int IDENTITY (1, 1) PRIMARY KEY,
	ConsumerName		nvarchar(MAX) not null,
	ConsumerEmail		nvarchar(MAX) not null,
	ConsumerImage		nvarchar(MAX),
	ConsumerUsername	nvarchar(MAX) not null,
	ConsumerPassword	nvarchar(MAX) not null
); 
go

create table Producers(
	ProducerID			int IDENTITY (1, 1) PRIMARY KEY,
	ProducerName		nvarchar(MAX) not null,
	ProducerEmail		nvarchar(MAX) not null,
	ProducerImage		nvarchar(MAX),
	ProducerPassword	nvarchar(MAX) not null,
	RestaurantID		int not null
); 
go

create table Admins(
	AdminID				int IDENTITY (1, 1) PRIMARY KEY,
	AdminName			nvarchar(MAX) not null,
	AdminEmail			nvarchar(MAX) not null,
	AdminImage			nvarchar(MAX),
	AdminPassword		nvarchar(MAX) not null
); 
go

create table Comments (
	CommentID			INT IDENTITY (1, 1) PRIMARY KEY,
	CommentDetail		NVARCHAR(MAX),
	FoodID				int not null,
	ConsumerID			int not null
); 
go
create table Restaurants (
	RestaurantID		INT IDENTITY (1, 1) PRIMARY KEY,
	RestaurantName		NVARCHAR(MAX) not null,
	RestaurantImage		NVARCHAR(MAX)
); 
go

create table Users( -- this table will be removed in the future because already have Consumer, Producer and Manager table
	UserID				int IDENTITY (1, 1) PRIMARY KEY,
	StaffID				int not null,
	RoleID				int not null,
	UserName			nvarchar(MAX) not null,
	UserEmail			nvarchar(MAX) not null,
	UserImage			nvarchar(MAX) not null,
	UserPassword		nvarchar(MAX) not null
); 
go

CREATE TABLE Roles ( -- this table will be removed in the future because already have Consumer, Producer and Manager table 
	RoleID		int IDENTITY (1, 1) PRIMARY KEY,  -- 1: staff, 2: admin --
	RoleName	nvarchar(MAX) not null
); 
go

ALTER TABLE Foods ADD CONSTRAINT Foods_CategoryID_FK FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID);
ALTER TABLE Foods ADD CONSTRAINT Foods_RestaurantID_FK FOREIGN KEY (RestaurantID) REFERENCES Restaurants(RestaurantID);
go

INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Hamburger','/WEBAPI/Images/Hatch_Green_Chile_Hamburger.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Shusi','/WEBAPI/Images/shishi.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Noodles','/WEBAPI/Images/noodle.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Drinks','/WEBAPI/Images/coca.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Milktea','/WEBAPI/Images/milktea.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Rice','/WEBAPI/Images/rice.jpg')
go

INSERT INTO Restaurants(RestaurantName) VALUES ('Đặng Văn Hải')
go

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
go

--TÌM SỐ LƯỢNG --
SELECT CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Foods
  GROUP BY CategoryID;
GO

insert into CardTypes(CardTypeName, CardTypeImage) values ('Visa', '/WEBAPI/Images/visa_logo.png');
insert into CardTypes(CardTypeName, CardTypeImage) values ('MasterCard', '/WEBAPI/Images/master_logo.png');
select * from CardTypes;
go

insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('Mark Olson', 'mark@gmail.com', '/WEBAPI/Images/mark_olson.png', 'mark', '123');
insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('Samathan Smith', 'Samathan@gmail.com', '/WEBAPI/Images/samathan_smith.png', 'samathan', '123');
insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('John Smith', 'john@gmail.com', '/WEBAPI/Images/mark_olson.png', 'john', '123');
insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('Alex Livingson', 'alex@gmail.com', '/WEBAPI/Images/alex_livingson.png', 'alex', '123');
select * from Consumers;
GO

INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardTypeID, ConsumerID) VALUES 
	('4227 0123 4567 8901', '/WEBAPI/Images/visa-card1.png', '2024-01-01', 1, 1);
INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardTypeID, ConsumerID) VALUES 
	('1234 4567 8910 1289', '/WEBAPI/Images/visa-card2.png', '2023-12-20', 1, 2);
INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardTypeID, ConsumerID) VALUES 
	('5100 1234 5678 9012', '/WEBAPI/Images/master-card1.png', '2023-12-20', 2, 3);
INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardTypeID, ConsumerID) VALUES 
	('4000 0012 3456 7899', '/WEBAPI/Images/master-card2.png', '2021-03-31', 2, 4);
select * from cards;
go