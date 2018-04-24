import pyodbc

def getAllImageFiles():
    connection = pyodbc.connect('Driver={SQL Server};''Server=LAPTOP-4OUIJ1DH;''Database=TStageDatabase;''Trusted_Connection=yes') 
    cursor = connection.cursor() 

    SQLCommand = ("SELECT * FROM imageFiles") 
    cursor.execute(SQLCommand) 
    rowArray = []
    

    for row in cursor:    
        myStr = str(row).replace("\\\\", "\\")
        myStr = myStr.replace("(","")
        myStr = myStr.replace(")","")
        myStr = myStr.replace(",","")
        myStr = myStr.replace("'","")
        myStr = myStr.replace(" ", "")
        myStr = myStr.replace("C", "|C")
        myStr = myStr.replace("False", "|False")
        myStr = myStr.replace("True", "|True")
        myStr = myStr.replace("IMG", "|IMG")
        rowArray.append(myStr)

    connection.close()
    return rowArray

def updateIsCigOnSingleImageInfo(imageFileID, isCig_input, isNotCig):
    connection = pyodbc.connect('Driver={SQL Server};''Server=LAPTOP-4OUIJ1DH;''Database=TStageDatabase;''Trusted_Connection=yes') 
    cursor = connection.cursor() 

    strIsCig = str(isCig_input)
    strIsNotCig = str(isNotCig)
    strImageFileID = str(imageFileID)

    SQLCommand = ("UPDATE imageInfos SET IsCig = " + strIsCig + ", IsNotCig = " + strIsNotCig + " WHERE imageFileID = " + strImageFileID) 
    print(SQLCommand)
    cursor.execute(SQLCommand)

    connection.commit()

    connection.close()


#Just a simply way of testing the method.
def testGetAllImageFilesPaths():

    rowArray = getAllImageFiles()

    for string in rowArray:
        print(string)
        print(' Works')

