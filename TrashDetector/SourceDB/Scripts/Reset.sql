USE TSourceDatabase

DROP TABLE IF EXISTS imageFiles;
DROP TABLE IF EXISTS imageInfos;

USE TSourceDatabase

CREATE TABLE imageFiles (
ID int IDENTITY(1,1) PRIMARY KEY,
FileName VARCHAR(300) UNIQUE,
FilePath varchar(400),
IsCig VARCHAR(100),
IsNotCig VARCHAR(100)
);