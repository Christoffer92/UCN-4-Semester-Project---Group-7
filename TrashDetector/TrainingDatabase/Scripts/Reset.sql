USE TTrainingDatabase

DROP TABLE IF EXISTS imageFiles;

CREATE TABLE imageFiles (
ID int IDENTITY(1,1) PRIMARY KEY,
FileName VARCHAR(300) UNIQUE,
FilePath varchar(400),
IsCig BIT
);