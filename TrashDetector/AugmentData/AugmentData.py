import cv2
import TrainingDB
import shutil
import os.path
import winsound

cigarettesAugmentedDataPath = R'C:\TrashDetector\Data\TrainingDBData\augmented_data\cigarettes'
nonCigarettesAugmentedDataPath = R'C:\TrashDetector\Data\TrainingDBData\augmented_data\non_cigarettes'

def flipImage(filePath, orientation, isCiggarret):
    #finds the file name in filepath
    filePathSplitted = str(filePath).split('\\', -1)
    lastSplit = filePath.count('\\')
    orginalFileName = filePathSplitted[lastSplit] 

    #making the orientation string for the new filename
    orientationStr = '';
    if orientation == 1:
        orientationStr = 'vertical'
    elif orientation == 0:
        orientationStr = 'horizontal'
    elif orientation == -1:
        orientationStr = 'both'

    newFileName = '\\flipped_'+orientationStr + '_' + orginalFileName

    #determine if its a non-cig or cig
    newFilePath = ''
    if isCiggarret == True:
        newFilePath = cigarettesAugmentedDataPath + newFileName
    elif isCiggarret == False:
        newFilePath = nonCigarettesAugmentedDataPath + newFileName

    #Check if its allready in folder
    if os.path.isfile(newFilePath):
        print(newFileName, 'allready exixst')
    else:
        shutil.copy(filePath, newFilePath)
        image = cv2.imread(newFilePath, 1)
        newImage = cv2.flip(image, orientation)
        cv2.imwrite(newFilePath, newImage)
        
def blurImage(filePath, isCiggarret):
    #finds the file name in filepath
    filePathSplitted = str(filePath).split('\\', -1)
    lastSplit = filePath.count('\\')
    orginalFileName = filePathSplitted[lastSplit]

    newFileName = '\\blur_' + orginalFileName

    #determine if its a non-cig or cig
    newFilePath = ''
    if isCiggarret == True:
        newFilePath = cigarettesAugmentedDataPath + newFileName
    else:
        newFilePath = nonCigarettesAugmentedDataPath + newFileName

    #Check if its allready in folder
    if os.path.isfile(newFilePath):
        print(newFileName, 'allready exixst')
    else:
        shutil.copy(filePath, newFilePath)
        image = cv2.imread(newFilePath, 1)
        newImage = cv2.blur(image, (10,10))
        cv2.imwrite(newFilePath, newImage)

def colorMapImage(filePath, colorMap, isCiggarret):
    #finds the file name in filepath
    filePathSplitted = str(filePath).split('\\', -1)
    lastSplit = filePath.count('\\')
    orginalFileName = filePathSplitted[lastSplit]

    #making the colormap string for the new filename
    colorMapStr = str(colorMap)
    if colorMap == cv2.COLORMAP_AUTUMN:
       colorMapStr = 'autum'
    if colorMap == cv2.COLORMAP_SPRING:
       colorMapStr = 'spring'
    if colorMap == cv2.COLORMAP_SUMMER:
       colorMapStr = 'summer'
    if colorMap == cv2.COLORMAP_WINTER:
       colorMapStr = 'winter'
    if colorMap == cv2.COLORMAP_RAINBOW:
       colorMapStr = 'rainbow'
    

    newFileName = '\\colorMap_'+colorMapStr + '_' + orginalFileName

    #determine if its a non-cig or cig
    newFilePath = ''
    if isCiggarret == True:
        newFilePath = cigarettesAugmentedDataPath + newFileName
    else:
        newFilePath = nonCigarettesAugmentedDataPath + newFileName

    #Check if its allready in folder
    if os.path.isfile(newFilePath):
        print(newFileName, 'allready exixst')

    else:
        shutil.copy(filePath, newFilePath)
        image = cv2.imread(newFilePath, cv2.IMREAD_UNCHANGED)
        newImage = cv2.applyColorMap(image, colorMap)     
        cv2.imwrite(newFilePath, newImage)

def augmentImages(filePaths, isCig):
    i = 1;
    for filePath in filePaths:
        print('Augmenting image', i, '/', len(filePaths))
        i = i+1
        flipImage(filePath, 1, isCig)
        flipImage(filePath, 0, isCig)
        flipImage(filePath, -1, isCig)
        blurImage(filePath, isCig)


def augmentImageWithColorMaps(filePath):
        colorMapImage(filePath, cv2.COLORMAP_AUTUMN, False)
        colorMapImage(filePath, cv2.COLORMAP_BONE, False)
        colorMapImage(filePath, cv2.COLORMAP_COOL, False)
        colorMapImage(filePath, cv2.COLORMAP_HOT, False)
        colorMapImage(filePath, cv2.COLORMAP_HSV, False)
        colorMapImage(filePath, cv2.COLORMAP_JET, False)
        colorMapImage(filePath, cv2.COLORMAP_OCEAN, False)
        colorMapImage(filePath, cv2.COLORMAP_PARULA, False)
        colorMapImage(filePath, cv2.COLORMAP_PINK, False)
        colorMapImage(filePath, cv2.COLORMAP_RAINBOW, False)
        colorMapImage(filePath, cv2.COLORMAP_SPRING, False)
        colorMapImage(filePath, cv2.COLORMAP_SUMMER, False)
        colorMapImage(filePath, cv2.COLORMAP_WINTER, False)


def augmentAllCigImages():
    cigFilePaths = TrainingDB.getAllCigarettesImageFilesPaths(True)
    nonCigFilePaths = TrainingDB.getAllCigarettesImageFilesPaths(False)
    augmentImages(cigFilePaths, True)
    augmentImages(nonCigFilePaths, False)


#testing area
augmentAllCigImages()
winsound.Beep(200, 500) #Sound to indicate its done augmenting all images. can take awhile.

#Notes
#Object tracking might be good but seems complicated.
#cv2.CamShift