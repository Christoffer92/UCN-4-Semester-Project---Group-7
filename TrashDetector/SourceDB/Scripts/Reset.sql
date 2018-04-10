USE TSourceDatabase

DROP TABLE IF EXISTS imageFiles;
DROP TABLE IF EXISTS imageInfos;

USE TSourceDatabase

CREATE TABLE imageFiles (
ID int NOT NULL,
FilePath varchar(400),
PRIMARY KEY (ID)
);

CREATE TABLE imageInfos (
ID int NOT NULL PRIMARY KEY,
ImageFileID INT,
LocationPoint VARCHAR(100),
IsTrash bit
);