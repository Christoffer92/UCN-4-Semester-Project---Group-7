﻿USE TSourceDatabase

CREATE TABLE imageFiles (
ID int NOT NULL PRIMARY KEY,
FilePath varchar(400)
);

CREATE TABLE imageInfos (
ID int NOT NULL PRIMARY KEY,
ImageFileID INT,
LocationPoint VARCHAR(100),
IsTrash bit
);