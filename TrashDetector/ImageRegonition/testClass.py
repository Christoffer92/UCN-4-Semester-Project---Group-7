import datetime

print('testClass, line 3', datetime.datetime.now())

#import train


#print('testClass, line 9', datetime.datetime.now())

#train.train(1000)

import predict

image_paths = [R'1.jpg', R'2.jpg', R'3.jpg', R'4.jpg', R'5.jpg', R'6.jpg', R'7.jpg', R'8.jpg', R'9.jpg', R'10.jpg', R'11.jpg', R'12.jpg', R'13.jpg']

for path in image_paths:
    print('Predicting image: ', path)
    predict.runPridict(path)
    

print('Finished: ', datetime.datetime.now())