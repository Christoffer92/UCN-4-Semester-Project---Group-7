USE TStageDatabase

DROP TABLE IF EXISTS imageInfos;
DROP TABLE IF EXISTS imageFiles;

CREATE TABLE imageFiles (
ID int IDENTITY(1,1) PRIMARY KEY,
FileName VARCHAR(300) UNIQUE,
FilePath varchar(400)
);

CREATE TABLE imageInfos (
ID int IDENTITY(1,1) PRIMARY KEY,
ImageFileID INT,
Latitiude DECIMAL(12,4),
Longitude DECIMAL(12,4),
DateCreated VARCHAR(100),
IsCig DECIMAL(12,4),
IsNotCig DECIMAL(12,4),
FOREIGN KEY (imageFileID) REFERENCES imageFiles(ID)
);