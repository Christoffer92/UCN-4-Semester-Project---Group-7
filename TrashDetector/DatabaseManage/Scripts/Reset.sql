USE TSourceDatabase

DROP TABLE IF EXISTS images;

CREATE TABLE images (
	id int identity(1,1)primary key ,
	Longtitude varchar(50),
	latitude varchar(50),

);