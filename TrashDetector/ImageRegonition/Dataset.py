import numpy as np
import cv2
import SourceDatabase as sourceDB

#Loads every imagefiles from the db and returns them in a array
def readTrainSets():

    imagePaths = sourceDB.getAllImageFilesPaths()
    imageFiles = []

    for path in imagePaths:
        print(path)
        img = cv2.imread(path, 0)
        imageFiles.append(img)

    return imageFiles

#For testing readTrainSets
def testReadTrainSets():
    imageFiles = readTrainSets()
    
    for img in imageFiles:
        #img = cv2.imread(image, 0)
        cv2.imshow("image", img)
        cv2.waitKey(0)
        cv2.destroyAllWindows()
    

testReadTrainSets()
#readTrainSets()





#train_path, img_size, classes, validation_size=validation_size