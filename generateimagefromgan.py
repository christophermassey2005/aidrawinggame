import numpy as np
from numpy.random import randint
from numpy.random import rand
from numpy import zeros
from numpy import ones
from numpy import expand_dims
import numpy as np
from numpy.random import randn
from numpy.random import randint
from keras.models import load_model
from PIL import Image

def generate_latent_points(latent_dim, n_samples):
	# generate points in the latent space
	x_input = randn(latent_dim * n_samples)
	# reshape into a batch of inputs for the network
	x_input = x_input.reshape(n_samples, latent_dim)
	return x_input

# load model
model = load_model('airplane.h5') #Model trained for 100 epochs
# generate images
latent_points = generate_latent_points(100, 1)  #Latent dim and n_samples
# generate images
X = model.predict(latent_points)
# scale from [-1,1] to [0,1]
X = (X + 1) / 2.0

X = (X*255).astype(np.uint8)

img = Image.fromarray(X[0], 'RGB')
#img.save('airplane.png')
