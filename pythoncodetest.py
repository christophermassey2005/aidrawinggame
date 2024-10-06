# -*- coding: utf-8 -*-
"""
Created on Thu Nov 17 19:37:14 2022

@author: Haztec
"""

# -*- coding: utf-8 -*-
"""
Created on Thu Nov 17 19:33:46 2022

@author: Haztec
"""

#%matplotlib inline 
from matplotlib import pyplot as plt
import keras
from keras.preprocessing.image import ImageDataGenerator
from keras.models import Sequential
from keras.layers import Conv2D, MaxPooling2D
from keras.layers import Activation, Dropout, Flatten, Dense
from keras import backend as K
#from google.colab import drive
#from keras import backend as K
import numpy as np
import os
from sklearn.preprocessing import LabelEncoder
from sklearn.preprocessing import OneHotEncoder

#drive.mount('/content/drive', force_remount=True)
#!cd drive/MyDrive/
#!unzip drive/MyDrive/initialdatasmaller.zip


#splitedSize = 784
#alldata_splited = [alldata[x:x+splitedSize] for x in range(0, len(alldata), splitedSize)]

#print(alldata_splited)
#plt.imshow(alldata_splited[18], interpolation='nearest')
#plt.show()

#from matplotlib import pyplot as plt

#print(alldata[0].size)

#plt.imshow(reshapeddata[70], interpolation='nearest')

#items = os.listdir('/content/initialdatasmaller/')
items = os.listdir()


allimages = []

def npytoimage(item):
  reshapeddata = []

  filepath = item
  npyfile = np.load(filepath)
  #print(alldata.size)
  for image in npyfile:
    newdata = np.reshape(image, (28, 28))
    reshapeddata.append(newdata)

  return reshapeddata

for i in range(len(items)):
  reshapeditem = npytoimage(items[i])
  allimages.append(reshapeditem)


plt.imshow(allimages[9][75], interpolation='nearest')

# we have roughly 150000 images of each object

num_classes = len(allimages)
activation = 'relu'

model = Sequential()


# Convolution Layer
model.add(Conv2D(32, kernel_size=(3, 3), activation=activation, input_shape=(28, 28, 1))) 
  
# Convolution layer
model.add(Conv2D(64, (3, 3), activation=activation))
  
# Pooling with stride (2, 2)
model.add(MaxPooling2D(pool_size=(2, 2)))
  
# Delete neuron randomly while training (remain 75%)
#   Regularization technique to avoid overfitting
model.add(Dropout(0.25))
  
# Flatten layer 
model.add(Flatten())
  
# Fully connected Layer
model.add(Dense(128, activation=activation))
  
# Delete neuron randomly while training (remain 50%) 
#   Regularization technique to avoid overfitting
model.add(Dropout(0.5))
  
# Apply Softmax
model.add(Dense(num_classes, activation='softmax'))

# Loss function (crossentropy) and Optimizer (Adadelta)
model.compile(loss=keras.losses.categorical_crossentropy,
              optimizer=keras.optimizers.Adadelta(),
              metrics=['accuracy'])

one_hot_encodings = []
for i in range(len(allimages)):
  one_hot_encoding = np.zeros(len(allimages))
  one_hot_encoding[i] = 1
  one_hot_encodings.append(one_hot_encoding)


y_train = []
for i, item in enumerate(allimages):
  temp_y_train = []
  for j, image in enumerate(item):
    temp_y_train.append(one_hot_encodings[i])
  #print(len(temp_y_train))
  y_train.append(temp_y_train)
  #temp_y_train.clear()
#print(one_hot_encodings[0]) 
print("hello")                         
print(len(y_train[1][0]))



#model.fit(allimages, y_train, batch_size=32, epochs=11)

