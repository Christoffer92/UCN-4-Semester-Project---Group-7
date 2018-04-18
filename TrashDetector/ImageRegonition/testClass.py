import datetime

print('Starting import stuff: ', datetime.datetime.now())

import train
import predict


print('Start: ', datetime.datetime.now())

#train.train(5000)
predict.runPridict()

print('Finished: ', datetime.datetime.now())


