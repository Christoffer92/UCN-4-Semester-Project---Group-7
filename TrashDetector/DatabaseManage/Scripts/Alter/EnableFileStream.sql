﻿ALTER DATABASE TSourceDatabase

ADD FILEGROUP FileStreamFileGroup
 CONTAINS FILESTREAM
GO


ALTER DATABASE DBNAME
ADD FILE (NAME='FileStreamFileGroup', FILENAME='C:\FileStreamData\FileStreamDBFile')
TO FILEGROUP FileStreamFileGroup
GO