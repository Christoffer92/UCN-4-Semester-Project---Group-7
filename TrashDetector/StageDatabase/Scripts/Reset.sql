USE TStageDatabase

DROP TABLE IF EXISTS ImageTable;
DROP TABLE IF EXISTS ImageInformation

CREATE TABLE ImagesTable AS FileTable
WITH (
 FileTable_Directory = 'ImagesDirectory',
 FileTable_Collate_Filename = database_default
)

CREATE TABLE ImageInformation (
	id int NOT NULL,
	fileID int NOT NULL,
	locatio VARCHAR(24),
	timee VARCHAR(24),
	isTrash BIT,
	PRIMARY KEY id
)