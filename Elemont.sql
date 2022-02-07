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
	[icon] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL , 
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
values ('tk1', 'tk1', 1, 'test', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF

SET IDENTITY_INSERT [dbo].[Trainer] ON 
insert into Trainer (name, skinId, exp, gold, ball1Num, speed, vision ,accountId, trainerId)
values ('trainer1', 1, 0, 1000, 10, 10, 10, 1 , 1)
insert into Trainer (name, skinId, exp, gold, ball1Num, speed, vision ,accountId, trainerId)
values ('trainer2', 2, 0, 1000, 10, 10, 10, 1 , 2)
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
insert into Element (name, icon,environment, elementId)
values ('FLYING', 'test','Jungle', 6)
insert into Element (name, icon,environment, elementId)
values ('FIGHT', 'test','Swamp', 7)
insert into Element (name, icon,environment, elementId)
values ('ELECTRIC', 'test','Swamp', 8)
insert into Element (name, icon,environment, elementId)
values ('DRAGON', 'test','Snow', 9)
insert into Element (name, icon,environment, elementId)
values ('BUG', 'test','Jungle', 10)
insert into Element (name, icon,environment, elementId)
values ('PSYCHIC', 'test','Desert', 11)
insert into Element (name, icon,environment, elementId)
values ('STEEL', 'test','Snow', 12)
insert into Element (name, icon,environment, elementId)
values ('FAIRY', 'test','Jungle', 13)
insert into Element (name, icon,environment, elementId)
values ('DARK', 'test','Swamp', 14)
SET IDENTITY_INSERT [dbo].[Element] OFF

SET IDENTITY_INSERT [dbo].[Species] ON 
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Pikachu', 'Resources\\sea.png', 10, 5, 150, 1, 1)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Charmander', 'Resources\\wa.jpg', 10, 5, 100, 2, 2)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Mewtwo', 'Resources\\001.png', 5, 5, 60, 3, 3)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Entei', 'test', 5, 4, 100, 1, 101)


insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Charizard', 'test', 5, 4, 100, 1, 102)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Moltres', 'test', 5, 4, 100, 1, 103)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Magmar', 'test', 5, 3, 100, 1, 104)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Kyogre', 'test', 5, 5, 100, 2, 201)


insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Vaporeon', 'test', 5, 4, 100, 2, 203)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Meganium', 'test', 4, 5, 100, 3, 301)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Oddish', 'test', 5, 4, 100, 3, 302)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Sunkern', 'test', 5, 5, 100, 3, 303)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Treecko', 'test', 5, 4, 100, 3, 304)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Naetle', 'test', 5, 4, 100, 3, 305)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Castform', 'test', 5, 4, 100, 4, 401)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Chansey', 'test', 5, 4, 100, 4, 402)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Ditto', 'test', 5, 4, 100, 4, 403)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Eevee', 'test', 5, 5, 100, 4, 404)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Jigglypuff', 'test', 5, 5, 100, 4, 405)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Togepi', 'test', 5, 5, 100, 4, 406)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Articuno', 'test', 5, 5, 100, 5, 501)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Delibird', 'test', 5, 5, 100, 5, 502)


insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Jynx', 'test', 5, 5, 100, 5, 503)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Snorunt', 'test', 5, 5, 100, 5, 504)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Spheal', 'test', 5, 5, 100, 5, 505)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Regice', 'test', 5, 5, 100, 5, 506)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Dugtrio', 'test', 5, 5, 100, 6, 601)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Groudon', 'test', 5, 5, 100, 6, 602)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Misdreavus', 'test', 5, 5, 100, 7, 701)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Banette', 'test', 5, 5, 100, 7, 702)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Gengar', 'test', 5, 5, 100, 7, 703)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Ho-oh', 'test', 5, 5, 100, 8, 801)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Dragonite', 'test', 5, 5, 100, 8, 802)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Machamp', 'test', 5, 5, 100, 9, 901)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Hitmontop', 'test', 5, 5, 100, 9, 902)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Hitmonlee', 'test', 5, 5, 100, 9, 903)


insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Hitmonchan', 'test', 5, 5, 100, 9, 904)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Zapdos', 'test', 5, 5, 100, 10, 1001)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Amphamos', 'test', 5, 5, 100, 10, 1002)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Raikou', 'test', 5, 5, 100, 10, 1003)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Electabuzz', 'test', 5, 5, 100, 10, 1004)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Dragonnite', 'test', 5, 5, 100, 11, 1101)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Gyarados', 'test', 5, 5, 100, 11, 1102)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Latios', 'test', 5, 5, 100, 11, 1103)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Latias', 'test', 5, 5, 100, 11, 1104)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Heracross', 'test', 5, 5, 100, 12, 1201)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Pinsir', 'test', 5, 5, 100, 12, 1202)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Scizor', 'test', 5, 5, 100, 12, 1203)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Gloom', 'test', 5, 5, 100, 13, 1301)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Gulpin', 'test', 5, 5, 100, 13, 1302)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Spinarak', 'test', 5, 5, 100, 13, 1303)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Muk', 'test', 5, 5, 100, 13, 1304)


insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Weezing', 'test', 5, 5, 100, 13, 1305)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Mewtwo', 'test', 5, 5, 100, 14, 1401)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Mew', 'test', 5, 5, 100, 14, 1402)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Alakazam', 'test', 5, 5, 100, 14, 1403)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Golem', 'test', 5, 5, 100, 15, 1501)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Regirock', 'test', 5, 5, 100, 15, 1502)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Beldum', 'test', 5, 5, 100, 16, 1601)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Aggron', 'test', 5, 5, 100, 16, 1602)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Steelix', 'test', 5, 5, 100, 16, 1603)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Mawile', 'test', 5, 5, 100, 16, 1604)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Registeel', 'test', 5, 5, 100, 16, 1605)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Dialga', 'test', 5, 5, 100, 16, 1606)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Xerneas', 'test', 5, 5, 100, 17, 1701)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Sylveon', 'test', 5, 5, 100, 17, 1702)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Togekiss', 'test', 5, 5, 100, 17, 1703)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Tyranitar', 'test', 5, 5, 100, 18, 1801)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Houndoom', 'test', 5, 5, 100, 18, 1802)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Umbreon', 'test', 5, 5, 100, 18, 1803)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Slowking', 'test', 4, 4, 100, 2, 202)





SET IDENTITY_INSERT [dbo].[Species] OFF

SET IDENTITY_INSERT [dbo].[Pokemon] ON 
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Godchu', 1, 15, null, 1,1,2,1 )
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Firelizard', 2, 30, 1, null,3,4,2 )
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Meomeo', 3, 0, 1, null,5,6,3 )
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Crazy', 403, 0, null, null, 103, 205, 15)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Boorin', 402, 0, null, null, 103, 204, 14)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Ramie', 401, 0, null, null, 103, 203, 13)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Legend', 305, 0, null, null, 103, 202, 12)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Joker', 304, 0, null, null, 103, 201, 11)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Phoenix', 303, 0, null, null, 102, 305, 10)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Boss', 302, 0, null, null, 102, 304, 9)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Toxic', 301, 0, null, null, 102, 303, 8)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('PetPanda', 203, 0, null, null, 102, 302, 7)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Boss_Crazy', 201, 0, null, null, 101, 205, 5)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Atena', 104, 0, null, null, 101, 204, 4)

insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Legend', 202, 0, null, null, 102, 301, 6)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('FairyyPo', 904, 0, null, null, 403, 205, 35)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('InSane', 1001, 0, null, null, 404, 301, 36)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Mocha', 1002, 0, null, null, 404, 302, 37)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Mochi', 1003, 0, null, null, 404, 303, 38)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Wayne', 1004, 0, null, null, 404, 304, 39)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Garth', 1101, 0, null, null, 404, 305, 40)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Ying', 1102, 0, null, null, 105, 201, 41)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Yang', 1103, 0, null, null, 105, 202, 42)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Sonny', 1104, 0, null, null, 105, 203, 43)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Cher', 1201, 0, null, null, 105, 204, 44)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Mickey', 1202, 0, null, null, 105, 205, 45)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Minnie', 1203, 0, null, null, 405, 301, 46)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Ken', 1301, 0, null, null, 405, 302, 47)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Barbie', 1302, 0, null, null, 405, 303, 48)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('SlaughterKing', 1303, 0, null, null, 405, 304, 49)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Fighter', 1304, 0, null, null, 405, 305, 50)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Nalayak', 503, 0, null, null, 401, 201, 21)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Shinichi', 504, 0, null, null, 401, 202, 22)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Mai', 505, 0, null, null, 401, 203, 23)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Haru', 506, 0, null, null, 401, 204, 24)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Miumiu', 601, 0, null, null, 401, 205, 25)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Sar Phira Pathan', 602, 0, null, null, 402, 301, 26)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Chulbuln Chorn', 701, 0, null, null, 402, 302, 27)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Soldiers', 702, 0, null, null, 402, 303, 28)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Any', 703, 0, null, null, 402, 304, 29)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Muyn', 801, 0, null, null, 402, 305, 30)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Roxy', 802, 0, null, null, 403, 201, 31)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Sunflowerz', 901, 0, null, null, 403, 202, 32)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Death', 902, 0, null, null, 403, 203, 33)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('falcon', 903, 0, null, null, 403, 204, 34)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Brendy', 404, 0, null, null, 104, 301, 16)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Alone', 405, 0, null, null, 104, 302, 17)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Boorjn', 406, 0, null, null, 104, 303, 18)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Jerry', 501, 0, null, null, 104, 304, 19)
insert into Pokemon (name, speciesId,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('Darfcamper', 502, 0, null, null, 104, 305, 20)


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
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(13,7,13)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(14,7,14)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(20,8,15)
insert into SkillConnection (skillId, speciesId,skillConnectionId)
values(7,8,16)




SET IDENTITY_INSERT [dbo].[SkillConnection] OFF

SET IDENTITY_INSERT [dbo].[Strong] ON
insert into Strong (element1Id, element2Id, strongId)
values (1, 2,1)
insert into Strong (element1Id, element2Id, strongId)
values (2,3 ,2)
insert into Strong (element1Id, element2Id, strongId)
values (3,1,3)
insert into Strong (element1Id, element2Id, strongId)
values (4,5,4)
insert into Strong (element1Id, element2Id, strongId)
values (5,7,5)
insert into Strong (element1Id, element2Id, strongId)
values (14,12,6)
insert into Strong (element1Id, element2Id, strongId)
values (8,10,7)
insert into Strong (element1Id, element2Id, strongId)
values (9,1,8)
insert into Strong (element1Id, element2Id, strongId)
values (9,7,9)
insert into Strong (element1Id, element2Id, strongId)
values (5,6,10)
insert into Strong (element1Id, element2Id, strongId)
values (6,3,11)
insert into Strong (element1Id, element2Id, strongId)
values (7,11,12)
insert into Strong (element1Id, element2Id, strongId)
values (11,12,13)
insert into Strong (element1Id, element2Id, strongId)
values (12,13,14)
insert into Strong (element1Id, element2Id, strongId)
values (13,14,15)


SET IDENTITY_INSERT [dbo].[Strong] OFF

SET IDENTITY_INSERT [dbo].[Weak] ON
insert into Weak (element1Id, element2Id, weakId)
values (1, 1,1)
insert into Weak (element1Id, element2Id, weakId)
values( 2, 2,2)
insert into Weak (element1Id, element2Id, weakId)
values (3, 3,3)









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
insert into Skill (name, type, num, manaCost,skillId)
values ('Iron heal ' , 'heal', 15, 4,13)
insert into Skill (name, type, num, manaCost,skillId)
values ('Mud Slap ' , 'heal', 17, 4,14)
insert into Skill (name, type, num, manaCost,skillId)
values ('Reflect ' , 'heal', 13, 3,15)
insert into Skill (name, type, num, manaCost,skillId)
values (' Poison spikes' , 'attack', 4, 2,16)
insert into Skill (name, type, num, manaCost,skillId)
values (' Solar Beam' , 'attack', 6, 3,17)
insert into Skill (name, type, num, manaCost,skillId)
values (' Waterfall' , 'attack', 5, 2,18)
insert into Skill (name, type, num, manaCost,skillId)
values (' Recover' , 'attack', 7, 3,19)
insert into Skill (name, type, num, manaCost,skillId)
values (' Hex' , 'attack', 5, 3,20)

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