﻿USE ProjectBoard;
GO

CREATE TABLE dbo.BoardItem
(
	ID BIGINT IDENTITY(1,1) NOT NULL,
	ItemType VARCHAR(MAX) NOT NULL,
	Title VARCHAR(MAX) NOT NULL,
	Description VARCHAR(MAX) NOT NULL,
	State VARCHAR(MAX) NOT NULL,
	Priority VARCHAR(MAX) NOT NULL,
	Effort VARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_BoardItem PRIMARY KEY CLUSTERED (ID)

)
;

ALTER TABLE dbo.BoardItem
ADD

	CreateDate DATETIME2 NOT NULL 
		DEFAULT '2021-02-10 12:19:00',
	LastUpdated DATETIME2 NOT NULL 
		DEFAULT '2021-02-10 19:19:00',
	Iteration INT NOT NULL 
		DEFAULT 0,
	OwnerName VARCHAR (60) NOT NULL
		DEFAULT 'Admin',
	ParentID VARCHAR (30)
		DEFAULT NULL

;

CREATE TABLE dbo.Project
(
	ID INT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(MAX) NOT NULL,
	Description VARCHAR(MAX) NOT NULL,
	Creator VARCHAR(MAX) NOT NULL,
	CreateDate DATETIME2 NOT NULL,

	CONSTRAINT PK_Project PRIMARY KEY CLUSTERED (ID)

);

CREATE TABLE dbo.ProjectAccess
(
	ID INT IDENTITY(1,1) NOT NULL,
	ProjectID INT NOT NULL,
	UserID INT NOT NULL,
	AccessLevel VARCHAR(MAX) NOT NULL,

	CONSTRAINT PK_ProjectAccess PRIMARY KEY CLUSTERED (ID)

);

CREATE TABLE dbo."User"
(
	ID INT IDENTITY(1,1) NOT NULL,
	UserName VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	CreateDate DATETIME2 NOT NULL,

	CONSTRAINT PK_User PRIMARY KEY CLUSTERED (ID)

);