

INSERT INTO [dbo].[ImagesTable]
([name],[file_stream])
SELECT
               'SimpelExample.jpg',
               * FROM OPENROWSET(BULK N'C:\Users\Chris\OneDrive\Skrivebord\SimpelExample.jpg',
               SINGLE_BLOB) AS FileData 
			   GO