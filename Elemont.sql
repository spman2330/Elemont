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
------------------------------------------------------------
--CREATE TABLE
CREATE TABLE [Account] (
	[userName] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[password] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[type] [smallint] NOT NULL ,
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[accountId] INT  PRIMARY KEY
) ON [PRIMARY] 
GO
CREATE TABLE [Trainer] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[skin] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[exp] [smallint] NOT NULL ,
	[gold] [smallint] NOT NULL , 
	[ball1Num] [smallint] NOT NULL ,
	[ball2Num] [smallint] NOT NULL ,
	[ball3Num] [smallint] NOT NULL ,
	[trainerId] INT  PRIMARY KEY ,
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
	[pokemonId] INT  PRIMARY KEY,
) ON [PRIMARY] 
GO
CREATE TABLE [Element] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[icon] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL , 
	[elementId] INT  PRIMARY KEY
) ON [PRIMARY] 
GO
CREATE TABLE [Map] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[background] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[height] [smallint] NOT NULL ,
	[width] [smallint] NOT NULL ,
	[mapId] INT  PRIMARY KEY 
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
	[cellID] INT  PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Skill] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[type] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[num] [smallint] NOT NULL ,
	[manaCost] [smallint] NOT NULL ,
	[skillId] INT  PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Species] (
	[name] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[image] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[baseAttack] [smallint] NOT NULL ,
	[baseDefense] [smallint] NOT NULL ,
	[baseHp] [smallint] NOT NULL ,
	[elementId] INT NOT NULL ,
	[speciesId] INT  PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Weak] (
	[element1Id] INT ,
	[element2Id] INT ,
	[weakId] INT  PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [Strong] (
	[element1Id] INT ,
	[element2Id] INT ,
	[strongId] INT  PRIMARY KEY 
) ON [PRIMARY]
GO
CREATE TABLE [SkillConnection] (
	[skillId] INT NOT NULL ,
	[speciesID] INT NOT NULL ,
	[skillConnectionId] INT  PRIMARY KEY 
) ON [PRIMARY]
GO

------------------------------------------------------------
--FAKE DATA
insert into Account (userName, password, type , name, accountId)
values ('tk1', 'tk1', 1, 'test', 1)

insert into Trainer (name, skin, exp, gold, ball1Num, ball2Num, ball3Num ,accountId, trainerId)
values ('trainer1', 'male', 0, 1000, 10, 10, 10, 1 , 1)

insert into Element (name, icon, elementId)
values ('fire', 'test', 1)
insert into Element (name, icon, elementId)
values ('water', 'test', 2)
insert into Element (name, icon, elementId)
values ('grass', 'test', 3)

insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Pikachu', 'test', 5, 5, 100, 1, 1)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Charmander', 'test', 5, 5, 100, 2, 2)
insert into Species (name, image, baseAttack, baseDefense, baseHp, elementId, speciesId)
values ('Mewtwo', 'test', 5, 5, 100, 3, 3)

insert into Pokemon (name, species,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values ('gaBeo', 1, 0, null, 1,1,2,1 )
insert into Pokemon (name, species,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values (null, 2, 0, 1, null,3,4,2 )
insert into Pokemon (name, species,	exp, cellId, trainerId, skill1Id , skill2Id, pokemonId)
values (null, 3, 0, 1, null,5,6,3 )

insert into Map (name, background,	height, width, mapId)
values ('jungle','test',1000,1500,1)

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

insert into Strong (element1Id, element2Id, strongId)
values (1, 2,1)
insert into Strong (element1Id, element2Id, strongId)
values (2,3 ,2)
insert into Strong (element1Id, element2Id, strongId)
values (3,1,3)
insert into Weak (element1Id, element2Id, weakId)
values (1, 1,1)
insert into Weak (element1Id, element2Id, weakId)
values( 2, 2,2)
insert into Weak (element1Id, element2Id, weakId)
values (3, 3,3)


insert into Skill (name, type, num, manaCost, skillId)
values ('Blast burn',  'attack', 10, 5, 1)
insert into Skill (name, type, num, manaCost, skillId)
values ('Magmar ' , 'heal', 10, 3, 2)
insert into Skill (name, type, num, manaCost, skillId)
values ('Hydro cannon ' , 'attack', 10, 5, 3)
insert into Skill (name, type, num, manaCost, skillId)
values ('Water absorb ' , 'defense', 10, 3, 4)
insert into Skill (name, type, num, manaCost, skillId)
values ('Grass knot ' , 'attack', 12, 6, 5)
insert into Skill (name, type, num, manaCost, skillId)
values (' Poison spikes' , 'buffatk', 2, 2, 6)

insert into Cell (height, width, locationX, locationY, type, background, mapID,cellId)
values (50, 50, 200,200, 'nest', 'test',1,1) 
