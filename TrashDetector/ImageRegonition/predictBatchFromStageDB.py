import datetime
import predict
import StageDB as stageDB


imageFiles = stageDB.getAllImageFiles();


#1: filename, 2: path, 3: isCig
for row in imageFiles:
    strImageFile = [];
    strImageFile = row.split('|');
    print(strImageFile)
    fileName = strImageFile[1]
    predictionArray = predict.runPridict(fileName)
    isCig = predictionArray[0][0]
    isNonCig = predictionArray[0][1]
    imageFileID = strImageFile[0];

    print(isCig, isNonCig)
    stageDB.updateIsCigOnSingleImageInfo(imageFileID, isCig, isNonCig)
    
    
print('Finished: ', datetime.datetime.now())