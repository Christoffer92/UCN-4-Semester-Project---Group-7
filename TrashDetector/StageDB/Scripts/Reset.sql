﻿USE TStageDatabase

DROP TABLE IF EXISTS imageFiles;
DROP TABLE IF EXISTS imageInfos;

CREATE TABLE imageFiles (
ID int IDENTITY(1,1) PRIMARY KEY,
FileName VARCHAR(300) UNIQUE,
FilePath varchar(400)
);

CREATE TABLE imageInfos (
ID int IDENTITY(1,1) PRIMARY KEY,
ImageFileID INT,
Latitiude VARCHAR(100),
Longitude VARCHAR(100),
DateCreated VARCHAR(100),
IsTrash BIT

);