USE TStageDatabase

CREATE TABLE ImagesTable AS FileTable
WITH (
 FileTable_Directory = 'ImagesDirectory',
 FileTable_Collate_Filename = database_default
)

CREATE TABLE ImagesInformation (
	locatio VARCHAR(24),
	timee VARCHAR(24),
	isTrash BIT
)
