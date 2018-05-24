import cv2
import SourceDatabase
import shutil

filePaths = SourceDatabase.getAllCigarettesImageFilesPaths()
print(filePaths[0])


augmentedDataPath = R'C:\TrashDetector\Data\StageDBData\augmented_data\cigarettes\flipped.jpg'

shutil.copy(filePaths[0], augmentedDataPath)


image = cv2.imread(augmentedDataPath, 1)

newImage = cv2.flip(image, 0)

cv2.imwrite(augmentedDataPath, newImage)

def showImage():
    cv2.imshow("img", image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()