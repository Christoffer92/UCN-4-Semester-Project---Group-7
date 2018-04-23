import pyodbc 

#returns an string array with all the full path names for the image files
def getAllImageFilesPaths():
    connection = pyodbc.connect('Driver={SQL Server};''Server=LAPTOP-4OUIJ1DH;''Database=TSourceDatabase;''Trusted_Connection=yes') 
    cursor = connection.cursor() 

    SQLCommand = ("SELECT FilePath FROM imageFiles") 
    cursor.execute(SQLCommand) 
    rowArray = []
    
    for row in cursor:
        myStr = str(row).replace("\\\\", "\\")
        myStr = myStr.replace("(","")
        myStr = myStr.replace(")","")
        myStr = myStr.replace(",","")
        myStr = myStr.replace("'","")
        myStr = myStr.replace(" ", "")
        rowArray.append(myStr)

    connection.close()
    return rowArray

def getAllNonCigarettesImageFilesPaths():
    connection = pyodbc.connect('Driver={SQL Server};''Server=LAPTOP-4OUIJ1DH;''Database=TStageDatabase;''Trusted_Connection=yes') 
    cursor = connection.cursor() 

    SQLCommand = ("SELECT FilePath FROM imageFiles Where IsCigarette=0;") 
    cursor.execute(SQLCommand) 
    rowArray = []
    
    for row in cursor:
        myStr = str(row).replace("\\\\", "\\")
        myStr = myStr.replace("(","")
        myStr = myStr.replace(")","")
        myStr = myStr.replace(",","")
        myStr = myStr.replace("'","")
        myStr = myStr.replace(" ", "")
        rowArray.append(myStr)

    connection.close()
    return rowArray

def getAllCigarettesImageFilesPaths(isCig):
    connection = pyodbc.connect('Driver={SQL Server};''Server=LAPTOP-4OUIJ1DH;''Database=TStageDatabase;''Trusted_Connection=yes') 
    cursor = connection.cursor()

    SQLCommand = '';

    if isCig == 1:
        SQLCommand = ("SELECT FilePath FROM imageFiles Where IsCigarette=1;") 
    elif isCig == 0:
        SQLCommand = ("SELECT FilePath FROM imageFiles Where IsCigarette=0;") 
    
    cursor.execute(SQLCommand) 
    rowArray = []
    
    for row in cursor:
        myStr = str(row).replace("\\\\", "\\")
        myStr = myStr.replace("(","")
        myStr = myStr.replace(")","")
        myStr = myStr.replace(",","")
        myStr = myStr.replace("'","")
        myStr = myStr.replace(" ", "")
        rowArray.append(myStr)

    connection.close()
    return rowArray





#Just a simply way of testing the method.
def testGetAllImageFilesPaths():

    rowArray = getAllCigarettesImageFilesPaths()

    for string in rowArray:
        print(string)
        print(' Works')
