# UCN-4-Semester-Project---Group-7
Big Data, Trash Detector

This project requires that you have anaconda3 python installed and also tensorflow installed on your machine.
It also requires you have sql server manement installed.

to run this project you need to have these folder created in this exact location of your pc.

C:\TrashDetector\Data
C:\TrashDetector\Data\TrainingDBData
C:\TrashDetector\Data\TrainingDBData\augmented_data
C:\TrashDetector\Data\TrainingDBData\augmented_data\cigarettes
C:\TrashDetector\Data\TrainingDBData\augmented_data\non_cigarettes
C:\TrashDetector\Data\TrainingDBData\cigarettes
C:\TrashDetector\Data\TrainingDBData\non_cigarettes
C:\TrashDetector\Data\SourceDBData
C:\TrashDetector\Data\StageDBData
C:\TrashDetector\Data\StageDBData\cigarettes
C:\TrashDetector\Data\StageDBData\non_cigarettes
C:\TrashDetector\Data\StageDBData\uncertain
C:\TrashDetector\Data\StageDBData\unprocessed
C:\TrashDetector\Data\ResultDBData
C:\TrashDetector\Data\ResultDBData\cigarettes
C:\TrashDetector\Data\ResultDBData\non_cigarettes
C:\TrashDetector\Data\ResultDBData\uncertain

in addition to this you need to have a txt file with the filepath:
C:\TrashDetector\Data\StageDBData\log.txt

Also you need to add the models folder located here in the repos to folder:
C:\TrashDetector\Data\TrainingDBData\

After this step you need to create 4 sql databases each placed in your initial catelog and named:
TSourceDB, TStageDB, TResultDB and TTrainningDB. After this step is done you need to run the corresponding create scripts
these are found in the visual project in the DataAccesLayer folder under each database project in the folders named scripts.

Sadly there is some changes that is needed to do in the code aswell as this project is only meant
to be ran locally..

Line 19 in PythonInterpreter. Change the path to your specific location of the anaconda3 pyhon.exe file

If you have SQLExpress instead of SQL enterprice you migt need to add \SQLEXPRESS in the connection strings in each DBContext clases in the DataAccesLayer.

You need to change the connection string in the python file TrainingDB on line 25 to have the name of your local machine instead of LAPTOP-4OIUJ1DH.
This also needs to be done at line 5.
The same thing needs to be done in the StageDB.py file on line 4 and 29.

Now you should be ready to run the code. This is done from the ETLController class. You need to insert your own picture into the sourceDBData folder,
but dont worry the solution allready comes with a trained CNN, that was the models folder you added to the TraninDBData.
If you mange to run the code you should see the result in the TResultDB database.
