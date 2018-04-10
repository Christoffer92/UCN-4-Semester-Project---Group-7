USE TStageDatabase

CREATE TABLE imageFiles (
ID int IDENTITY(1,1) PRIMARY KEY,
FileName VARCHAR(300) UNIQUE,
FilePath varchar(400)
);

CREATE TABLE imageInfos (
ID int IDENTITY(1,1) PRIMARY KEY,
ImageFileID INT,
LocationPoint VARCHAR(100),
IsTrash bit
);