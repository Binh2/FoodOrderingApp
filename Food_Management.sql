drop DATABASE FOOD_MANAGEMENT
CREATE DATABASE FOOD_MANAGEMENT
use FOOD_MANAGEMENT
create table Category (
		CategoryID		INT IDENTITY (1, 1) PRIMARY KEY,
		CategoryName	NVARCHAR(MAX) not null,
		CategoryImages  NVARCHAR(MAX) not null
);
create table Food(
		FoodID		INT IDENTITY (1, 1) PRIMARY KEY,
		FoodName	NVARCHAR(MAX) not null,
		FoodImages	NVARCHAR(MAX) not null,
		FoodDecription	NVARCHAR(MAX),
		FoodPrice decimal not null,
		Rating	NVARCHAR(MAX),
		Favourite	NVARCHAR(MAX),
		CategoryID	 INT,
		RestaurantID INT
);

create table Comment(
		IDComment INT IDENTITY (1,1) PRIMARY KEY,
		CommentDetail NVARCHAR(MAX),
		IDFood int,
);
create table Restaurant(
		RestaurantID INT IDENTITY (1 , 1) PRIMARY KEY,
		RestaurantName NVARCHAR(MAX) not null
);

create table Users(
		UserID		int IDENTITY (1, 1) PRIMARY KEY,
		StaffID			int not null,
		RoleID			int not null,
		UserName		nvarchar(MAX) not null,
		UserEmail		nvarchar(MAX) not null,
		UserImage		nvarchar(MAX) not null,
		UserPassword nvarchar(MAX) not null
);

CREATE TABLE Roles (
	RoleID		int IDENTITY (1, 1) PRIMARY KEY,  -- 1: staff, 2: admin --
	RoleName	nvarchar(MAX) not null
);

ALTER TABLE Food ADD CONSTRAINT Food_CategoryID_FK FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID);
ALTER TABLE Food ADD CONSTRAINT Food_RestaurantID_FK FOREIGN KEY (RestaurantID) REFERENCES Restaurant(RestaurantID);


INSERT INTO Category (CategoryName,CategoryImages) VALUES ('Hamburger','http://192.168.2.13/WEBAPI/Images/Hatch_Green_Chile_Hamburger.jpg')
INSERT INTO Category (CategoryName,CategoryImages) VALUES ('Shusi','http://192.168.2.13/WEBAPI/Images/shishi.jpg')
INSERT INTO Category (CategoryName,CategoryImages) VALUES ('Noodles','http://192.168.2.13/WEBAPI/Images/noodle.jpg')
INSERT INTO Category (CategoryName,CategoryImages) VALUES ('Drinks','http://192.168.2.13/WEBAPI/Images/coca.jpg')
INSERT INTO Category (CategoryName,CategoryImages) VALUES ('Milktea','http://192.168.2.13/WEBAPI/Images/milktea.jpg')
INSERT INTO Category (CategoryName,CategoryImages) VALUES ('Rice','http://192.168.2.13/WEBAPI/Images/rice.jpg')

INSERT INTO Restaurant  (RestaurantName) VALUES ('Đặng Văn Hai')


INSERT INTO Food(FoodName,FoodImages,FoodDecription,FoodPrice,Rating,Favourite,CategoryID,RestaurantID) VALUES ('Hamburger trứng',
'http://192.168.2.13/WEBAPI/Images/Hatch_Green_Chile_Hamburger.jpg','Hamburger trứng ngon','15000','4,5','YES',1,1)
INSERT INTO Food(FoodName,FoodImages,FoodDecription,FoodPrice,Rating,Favourite,CategoryID,RestaurantID) VALUES ('Cocacola',
'http://192.168.2.13/WEBAPI/Images/coca.jpg','Cocacola ngon','15000','4,5','YES',4,1)
INSERT INTO Food(FoodName,FoodImages,FoodDecription,FoodPrice,Rating,Favourite,CategoryID,RestaurantID) VALUES ('Mì xào',
'http://192.168.2.13/WEBAPI/Images/noodle.jpg','Mì xào ngon','15000','4,6','YES',3,1)
INSERT INTO Food(FoodName,FoodImages,FoodDecription,FoodPrice,Rating,Favourite,CategoryID,RestaurantID) VALUES ('Cơm',
'http://192.168.2.13/WEBAPI/Images/rice.jpg','Cơm ngon','15000','3,0','YES',6,1)
INSERT INTO Food(FoodName,FoodImages,FoodDecription,FoodPrice,Rating,Favourite,CategoryID,RestaurantID) VALUES ('Cơm tấm',
'http://192.168.2.13/WEBAPI/Images/comtam.jpg','Cơm tấm ngon','15000','3,7','YES',6,1)
--TÌM SỐ LƯỢNG --
SELECT CategoryID, COUNT(CategoryID) AS "So luong"
  FROM Food
  GROUP BY CategoryID;
--LẤY TẤT CẢ LOẠI HÀNG--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetAllCategory]
as
select * from Category
GO

--LẤY TẤT CẢ LOẠI HÀNG--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [Proc_GetAllFood]
as
select * from Food
GO

-- LIST THỨC ĂN THEO LOẠI--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetFoodByCategoryID](@categoryid int)
as
select * from Food where CategoryID=@categoryid
GO
/******GET FOOD BY CATEID ******/
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
  FROM Food
  GROUP BY CategoryID;
