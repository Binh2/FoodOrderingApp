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
	CardID				INT IDENTITY (1, 1) PRIMARY KEY,
	CardNumber			NVARCHAR(MAX) not null,
	CardImage			NVARCHAR(MAX) not null,
	CardExpiryDate		date not null,
	CardBalance			float(53) not null,
	CardTypeID			INT not null,
	ConsumerID			INT not null
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
	FoodImages			NVARCHAR(MAX) not null, -- later will be removed
	FoodDetail			NVARCHAR(MAX),
	FoodPrice			FLOAT(53) not null,
	FoodRating			FLOAT(53),	-- Can be here for faster calculation
	FoodFavourite		INT,	-- Not suppose to be here
	CategoryID			INT,
	RestaurantID		INT not null
); 
create table FoodImages(
	FoodImageID			int identity (1, 1) primary key,
	FoodID				int not null,
	FoodImage			nvarchar(max) not null
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
); 
go
create table OrderFoods(
	OrderFoodID			int identity (1, 1) primary key,
	OrderID				int not null,
	FoodID				int not null,
	FoodQuantity		int not null,
	FoodPrice			int not null
);
go
create table OrderStates(
	OrderStateID		int identity (1, 1) primary key,
	OrderID				int not null,
	OrderStateTypeID	int not null,
	OrderDate			date not null,
	OrderLocation		NVARCHAR(MAX) not null
); 
go
create table OrderStateTypes(
	OrderStateTypeID	int IDENTITY (1, 1) PRIMARY KEY,
	OrderStateTypeName	nvarchar(max) not null,
	OrderStateTypeIsDone bit not null
); 
go

create table Consumers(
	ConsumerID			int IDENTITY (1, 1) PRIMARY KEY,
	ConsumerName		nvarchar(MAX) not null,
	ConsumerEmail		nvarchar(MAX) not null,
	ConsumerImage		nvarchar(MAX) not null,
	ConsumerUsername	nvarchar(MAX) not null,
	ConsumerPassword	nvarchar(MAX) not null
); 
go

create table Producers(
	ProducerID			int IDENTITY (1, 1) PRIMARY KEY,
	ProducerName		nvarchar(MAX) not null,
	ProducerEmail		nvarchar(MAX) not null,
	ProducerImage		nvarchar(MAX),
	ProducerUsername	nvarchar(max) not null,
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
	CommentStar			int not null,
	CommentDetail		NVARCHAR(MAX),
	CommentDate			date not null,
	FoodID				int not null,
	ConsumerID			int not null
); 
go
create table Restaurants (
	RestaurantID		INT IDENTITY (1, 1) PRIMARY KEY,
	RestaurantName		NVARCHAR(MAX) not null,
	RestaurantImage		NVARCHAR(MAX),
	RestaurantLocation	nvarchar(max)
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

INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Hamburger','Hatch_Green_Chile_Hamburger.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Shusi','shishi.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Noodles','noodle.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Drinks','coca.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Milktea','milktea.jpg')
INSERT INTO Categories (CategoryName,CategoryImage) VALUES ('Rice','rice.jpg')
go

INSERT INTO Restaurants(RestaurantName) VALUES ('Đặng Văn Hải');
INSERT INTO Restaurants(RestaurantName) VALUES ('Taca');
INSERT INTO Restaurants(RestaurantName) VALUES ('DiDi');
INSERT INTO Restaurants(RestaurantName,RestaurantImage,RestaurantLocation) VALUES 
	('Jiffy Burger', 'jiffy_burger_restaurant.png', '815 E Highway 36, Smith Center, KS 66967');
INSERT INTO Restaurants(RestaurantName,RestaurantImage,RestaurantLocation) VALUES 
	('El A De Oros', 'el_as_de_oros_restaurant.png', '609 3rd St, Phillipsburg, KS 67661');
INSERT INTO Restaurants(RestaurantName,RestaurantImage,RestaurantLocation) VALUES 
	('Cardinal Drive In', 'cardinal_drive_in_restaurant.png', '400 N Broadway St, Plainville, KS 67663');
go

INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Hamburger trứng',
'Hatch_Green_Chile_Hamburger.jpg','Hamburger trứng ngon',15000,4.5,0,1,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cocacola',
'coca.jpg','Cocacola ngon',15000,4.5,0,4,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Mì xào',
'noodle.jpg','Mì xào ngon',15000,4.6,0,3,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cơm',
'rice.jpg','Cơm ngon',15000,3.0,0,6,1)
INSERT INTO Foods(FoodName,FoodImages,FoodDetail,FoodPrice,FoodRating,FoodFavourite,CategoryID,RestaurantID) VALUES ('Cơm tấm',
'comtam.jpg','Cơm tấm ngon',15000,3.7,0,6,1)
go

--TÌM SỐ LƯỢNG --
SELECT CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Foods
  GROUP BY CategoryID;
GO

insert into CardTypes(CardTypeName, CardTypeImage) values ('Visa', 'visa_logo.png');
insert into CardTypes(CardTypeName, CardTypeImage) values ('MasterCard', 'master_logo.png');
select * from CardTypes;
go

insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('Mark Olson', 'mark@gmail.com', 'mark_olson.png', 'mark', '123');
insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('Samathan Smith', 'Samathan@gmail.com', 'samathan_smith.png', 'samathan', '123');
insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('John Smith', 'john@gmail.com', 'mark_olson.png', 'john', '123');
insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('Alex Livingson', 'alex@gmail.com', 'alex_livingson.png', 'alex', '123');
insert into Consumers(ConsumerName, ConsumerEmail, ConsumerImage, ConsumerUsername, ConsumerPassword) values 
	('David Spade', 'david@gmail.com', 'david.png', 'david', '123');
select * from Consumers;
GO

INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardBalance, CardTypeID, ConsumerID) VALUES 
	('4227 0123 4567 8901', 'visa-card1.png', '2024-01-01', 10000000, 1, 1);
INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardBalance, CardTypeID, ConsumerID) VALUES 
	('1234 4567 8910 1289', 'visa-card2.png', '2023-12-20', 30, 1, 2);
INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardBalance, CardTypeID, ConsumerID) VALUES 
	('5100 1234 5678 9012', 'master-card1.png', '2023-12-20', 0, 2, 3);
INSERT INTO Cards(CardNumber, CardImage, CardExpiryDate, CardBalance, CardTypeID, ConsumerID) VALUES 
	('4000 0012 3456 7899', 'master-card2.png', '2021-03-31', 100, 2, 4);
select * from cards;
go



insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('In restaurant', 0);	--1 This state won't be used. It's just a filler state
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('In restaurant', 1);	--2
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('In cart', 0);			--3 This state won't be used. It's just a filler state
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('In cart', 1);			--4
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('sign', 0);			--5
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('sign', 1);			--6
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('process', 0);			--7
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('process', 1);			--8
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('ship', 0);			--9
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('ship', 1);			--10
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('receive', 0);			--11
insert into OrderStateTypes(OrderStateTypeName,OrderStateTypeIsDone) values ('receive', 1);			--12
go

insert into OrderStates(OrderID,OrderStateTypeID,OrderDate,OrderLocation) values(1,4,'2022-07-20','Lagos State, Nigeria');
insert into OrderStates(OrderID,OrderStateTypeID,OrderDate,OrderLocation) values(1,6,'2022-07-20','Lagos State, Nigeria');
insert into OrderStates(OrderID,OrderStateTypeID,OrderDate,OrderLocation) values(1,8,'2022-07-20','Lagos State, Nigeria');
insert into OrderStates(OrderID,OrderStateTypeID,OrderDate,OrderLocation) values(1,10,'2022-07-21','Lagos State, Nigeria');
go

insert into OrderFoods(OrderID,FoodID,FoodQuantity,FoodPrice) values (1,1,1,15000);
insert into OrderFoods(OrderID,FoodID,FoodQuantity,FoodPrice) values (1,2,1,15000);
insert into OrderFoods(OrderID,FoodID,FoodQuantity,FoodPrice) values (1,3,1,15000);
insert into OrderFoods(OrderID,FoodID,FoodQuantity,FoodPrice) values (1,4,1,15000);
insert into OrderFoods(OrderID,FoodID,FoodQuantity,FoodPrice) values (1,5,1,15000);
go

insert into Orders(ConsumerID) values (1);
go



insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (5,'delicious','2023-01-11',1,1);
insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (5,'amazing!!!!!','2023-01-12',1,2);
insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (4,'The flavor is so goood','2023-01-15',1,3);
insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (5,'I have never taste anything like this before, loving it','2023-01-19',1,4);

insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (5,'The food is amazing and the delivery is fast','2023-01-21',2,1);
insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (5,'tastefull','2023-01-22',2,2);
insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (5,'Wonderful','2023-01-25',2,3);
insert into Comments(CommentStar,CommentDetail,CommentDate,FoodID,ConsumerID) values (2,'There is a fly in my food','2023-01-27',2,4);