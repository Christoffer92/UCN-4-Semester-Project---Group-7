USE TSourceDatabase

DROP TABLE IF EXISTS ImagesTable;

CREATE TABLE ImagesTable AS FileTable
WITH (
 FileTable_Directory = 'ImagesDirectory',
 FileTable_Collate_Filename = database_default
)