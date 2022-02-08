------------------------------------------------------------
--USE MASTER
USE MASTER
GO

------------------------------------------------------------
--DROP DATABASE
If Exists(select* From SysDatabases Where Name='ELEMONT')
DROP DATABASE ELEMONT
GO

------------------------------------------------------------
--CREATE DATABASE
CREATE DATABASE ELEMONT
GO

------------------------------------------------------------
--USE DATABASE ELEMONT
USE ELEMONT
GO

------------------------------------------------------------
--DROP TABLE
if exists (select * from dbo.sysobjects where id = object_id(N'[Account]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Account]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Trainer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Trainer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Pokemon]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Pokemon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Element]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Element]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Map]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Map]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Cell]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Cell]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Skill]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Skill]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Species]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Species]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Weak]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Weak]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Strong]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Strong]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[SkillConnection]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [SkillConnection]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Skin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Skin]
GO
------------------------------------------------------------
--CREATE TABLE
CREATE TABLE [Account] (
	[userName] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[password] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[type] [smallint] NOT NULL ,
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[accountId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
) ON [PRIMARY] 
GO
CREATE TABLE [Trainer] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[skinId] INT NOT NULL,
	[exp] [smallint] NOT NULL ,
	[gold] [smallint] NOT NULL , 
	[ball1Num] [smallint] NOT NULL ,
	[speed] [smallint] NOT NULL ,
	[vision] [smallint] NOT NULL ,
	[trainerId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY ,
	[accountId] INT NOT NULL 
) ON [PRIMARY] 
GO
CREATE TABLE [Pokemon] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS ,
	[speciesId] INT ,
	[exp] [smallint] NOT NULL ,
	[cellId] INT ,
	[trainerId] INT ,
	[skill1Id] INT ,
	[skill2Id] INT ,
	[pokemonId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
) ON [PRIMARY] 
GO
CREATE TABLE [Element] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[icon] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS, 
	[environment] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[elementId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
) ON [PRIMARY] 
GO
CREATE TABLE [Map] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[background] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[height] [smallint] NOT NULL ,
	[width] [smallint] NOT NULL ,
	[mapId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Cell] (
	[height] [smallint] NOT NULL ,
	[width] [smallint] NOT NULL ,
	[locationX] [smallint] NOT NULL ,
	[locationY] [smallint] NOT NULL ,
	[type] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[background] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[mapID] INT ,
	[cellID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Skill] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[type] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[num] [smallint] NOT NULL ,
	[manaCost] [smallint] NOT NULL ,
	[skillId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Species] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[image] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[baseAttack] [smallint] NOT NULL ,
	[baseDefense] [smallint] NOT NULL ,
	[baseHp] [smallint] NOT NULL ,
	[elementId] INT NOT NULL ,
	[speciesId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Weak] (
	[element1Id] INT ,
	[element2Id] INT ,
	[weakId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Strong] (
	[element1Id] INT ,
	[element2Id] INT ,
	[strongId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [SkillConnection] (
	[skillId] INT NOT NULL ,
	[speciesID] INT NOT NULL ,
	[skillConnectionId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Skin] (
	[avatar] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[left] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[right] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[up] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[down] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[skinId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
)
------------------------------------------------------------
--FAKE DATA
SET IDENTITY_INSERT [dbo].[Account] ON 
insert into Account (userName, password, type , name, accountId)
values ('tk1', 'tk1', 0, 'player1', 1)
insert into Account (userName, password, type , name, accountId)
values ('tk2', 'tk2', 0, 'player2', 2)
insert into Account (userName, password, type , name, accountId)
values ('tk3', 'tk3', 1, 'admin', 3)
SET IDENTITY_INSERT [dbo].[Account] OFF

SET IDENTITY_INSERT [dbo].[Trainer] ON 
insert into Trainer (name, skinId, exp, gold, ball1Num, speed, vision ,accountId, trainerId)
values ('trainer1', 1, 0, 1000, 10, 10, 10, 1 , 1)
insert into Trainer (name, skinId, exp, gold, ball1Num, speed, vision ,accountId, trainerId)
values ('trainer2', 2, 0, 1000, 10, 10, 10, 1 , 2)
insert into Trainer (name, skinId, exp, gold, ball1Num, speed, vision ,accountId, trainerId)
values ('trainer3', 1, 0, 1000, 10, 10, 10, 2 , 3)
insert into Trainer (name, skinId, exp, gold, ball1Num, speed, vision ,accountId, trainerId)
values ('trainer4', 2, 0, 1000, 10, 10, 10, 2 , 4)
SET IDENTITY_INSERT [dbo].[Trainer] OFF

SET IDENTITY_INSERT [dbo].[Element] ON 
insert into Element (name, icon,environment, elementId)
values ('FIRE', 'test','Desert', 1)
insert into Element (name, icon,environment, elementId)
values ('WATER', 'test','Swamp', 2)
insert into Element (name, icon,environment, elementId)
values ('GRASS', 'test','Jungle', 3)
insert into Element (name, icon,environment, elementId)
values ('ICE', 'test','Snow', 4)
insert into Element (name, icon,environment, elementId)
values ('GROUND', 'test','Desert', 5)
SET IDENTITY_INSERT [dbo].[Element] OFF

SET IDENTITY_INSERT [dbo].[Species] ON 
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Pikachu', 'Resources\\pokemon\\pikachu.png', 10, 5, 150, 1, 1)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Charmander', 'Resources\\pokemon\\charmander.png', 10, 5, 100, 2, 2)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Mewtwo', 'Resources\\pokemon\\mewtwo.png', 5, 5, 60, 3, 3)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Entei', 'Resources\\pokemon\\entei.png', 5, 4, 100, 4, 4)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Charizard', 'Resources\\pokemon\\charizard.png', 5, 4, 100, 5, 5)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Moltres', 'Resources\\pokemon\\moltres.png', 5, 4, 100, 4, 6)

SET IDENTITY_INSERT [dbo].[Species] OFF			

SET IDENTITY_INSERT [dbo].[Pokemon] ON 
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Pikachu', 1, 0, null, 1,1,2,1 )
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Pikachu', 1, 0, null, 2,2,4,2 )
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Charmander', 2, 0, null,1, 1,6, 3 )
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Charmander', 2, 0, 1, null, 1, 3, 4)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Mewtwo', 3, 0, 2, null, 2, 5, 5)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Mewtwo', 3, 0, 5, null, 4, 12, 6)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Entei', 4, 0, 6, null, 5, 7, 7)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Entei', 4, 0, 1, null, 8, 11, 8)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Charizard', 5, 1, 2, null, 5, 7, 9)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Charizard', 5, 0, 5, null, 7, 8, 10)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Moltres', 6, 0, 6, null, 3, 9, 11)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Moltres', 6, 0, 1, null, 4, 12, 12)


SET IDENTITY_INSERT [dbo].[Pokemon] OFF


SET IDENTITY_INSERT [dbo].[Map] ON 
insert into Map (name, background,	height, width, mapId)
values ('Jungle','Resources\\Jungle.png',2500,2000,1)
insert into Map (name, background,	height, width, mapId)
values ('Snow','Resources\\Snow.png',2000,2000,2)
insert into Map (name, background,	height, width, mapId)
values ('Desert','Resources\\Desert.png',2000,2000,3)
insert into Map (name, background,	height, width, mapId)
values ('Swamp','Resources\\Swamp.png',2000,1500,4)
SET IDENTITY_INSERT [dbo].[Map] OFF

SET IDENTITY_INSERT [dbo].[SkillConnection] ON


insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(1,1,1)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(2,1,2)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(3,2,3)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(4,2,4)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(5,3,5)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(6,3,6)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(7,4,7)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(8,4,8)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(9,5,9)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(10,5,10)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(11,6,11)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(12,6,12)




SET IDENTITY_INSERT [dbo].[SkillConnection] OFF

SET IDENTITY_INSERT [dbo].[Strong] ON
insert into Strong (element1Id, element2Id, strongId)
values (1, 2,1)
insert into Strong (element1Id, element2Id, strongId)
values (2,3 ,2)
insert into Strong (element1Id, element2Id, strongId)
values (3,4,3)
insert into Strong (element1Id, element2Id, strongId)
values (4,5,4)
insert into Strong (element1Id, element2Id, strongId)
values (5,1,5)


SET IDENTITY_INSERT [dbo].[Strong] OFF

SET IDENTITY_INSERT [dbo].[Weak] ON
insert into Weak (element1Id, element2Id, weakId)
values (1, 1,1)
insert into Weak (element1Id, element2Id, weakId)
values( 2, 2,2)
insert into Weak (element1Id, element2Id, weakId)
values (3, 3,3)
insert into Weak (element1Id, element2Id, weakId)
values (4, 4,4)
insert into Weak (element1Id, element2Id, weakId)
values( 5, 5,5)
SET IDENTITY_INSERT [dbo].[Weak] OFF

SET IDENTITY_INSERT [dbo].[Skill] ON
insert into Skill (name, type, num, manaCost,skillId)
values ('Acid Spray',  'heal', 15, 3,1)
insert into Skill (name, type, num, manaCost,skillId)
values ('Blast burn',  'attack', 18, 4,2)
insert into Skill (name, type, num, manaCost,skillId)
values ('Comet Punch',  'attack', 21, 4,3)
insert into Skill (name, type, num, manaCost,skillId)
values ('Hydro cannon ' , 'attack', 23, 5,4)
insert into Skill (name, type, num, manaCost,skillId)
values ('Grass knot ' , 'attack', 25, 6,5)

insert into Skill (name, type, num, manaCost,skillId)
values ('Milk Drink ' , 'heal', 7, 2,6)
insert into Skill (name, type, num, manaCost,skillId)
values ('Magmar ' , 'heal', 10, 3,7)
insert into Skill (name, type, num, manaCost,skillId)
values ('Recover ' , 'heal', 13, 4,8)
insert into Skill (name, type, num, manaCost,skillId)
values ('Roost ' , 'heal', 15, 5,9)
insert into Skill (name, type, num, manaCost,skillId)
values ('Synthesis ' , 'heal', 16, 6,10)
insert into Skill (name, type, num, manaCost,skillId)
values ('Water absorb ' , 'heal', 10, 3,11)
insert into Skill (name, type, num, manaCost,skillId)
values ('Dig ' , 'heal', 12, 3,12)

SET IDENTITY_INSERT [dbo].[Skill] OFF

SET IDENTITY_INSERT [dbo].[Cell] ON
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (250, 500, 305,35, 'Nest', 'test',1,1)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (400, 400, 1150,1940, 'Water', 'test',1,2)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (400, 450, 290,2027, 'Wall', 'test',1,3)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (500, 250, 1310,1042, 'Wall', 'test',1,4)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (500, 500, 1159,68, 'Nest', 'test',1,5)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (300, 1000, 330,621, 'Water', 'test',1,6)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (750, 100, 7,1128, 'Wall', 'test',1,7)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (750, 300, 466,1091, 'Nest', 'test',1,8)

insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (300, 300, 1095,335, 'Nest', 'test',4,9)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (300, 300, 709,38, 'Water', 'test',4,10)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (200, 200, 210,1179, 'Wall', 'test',4,11)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (200, 200, 579,1697, 'Wall', 'test',4,12)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (150, 350, 300,1428, 'Nest', 'test',4,13)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (150, 350, 594,704, 'Water', 'test',4,14)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (300, 150, 170,881, 'Wall', 'test',4,15)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (300, 150, 668,1047, 'Nest', 'test',4,16)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (300, 150, 536,431, 'Water', 'test',4,17)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (150, 500, 129,360, 'Wall', 'test',4,18)
insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (150, 500, 996,1842, 'Nest', 'test',4,19)

SET IDENTITY_INSERT [dbo].[Cell] OFF

SET IDENTITY_INSERT [dbo].[Skin] ON
insert into Skin (avatar, up, down, [right], [left], name, skinId)
values ('Resources\\male.png', 'Resources\\maleu.png', 'Resources\\maled.png', 'Resources\\maler.png', 'Resources\\malel.png', 'male', 1)
insert into Skin (avatar, up, down, [right], [left], name, skinId)
values ('Resources\\female.png', 'Resources\\femaleu.png', 'Resources\\femaled.png', 'Resources\\femaler.png', 'Resources\\femalel.png', 'male', 2)
SET IDENTITY_INSERT [dbo].[Skin] OFF