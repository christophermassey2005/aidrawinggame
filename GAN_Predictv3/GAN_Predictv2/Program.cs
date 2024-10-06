using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keras;
using Keras.Callbacks;
using Keras.Layers;
using Keras.Models;
using Keras.Optimizers;
using Keras.PreProcessing.Image;
using Keras.Initializer;
using Keras.Utils;
using Numpy;
using Keras.Regularizers;
using Numpy.Models;
//using MatplotlibCS.PlotItems;
using OpenCvSharp;
using SharpCV;
using static SharpCV.Binding;
using System.IO;


namespace GAN_Predictv2
{
    class Program
    {

        static void Main(string[] args)
        {

            //string currentitem = File.ReadLines("E:/CS Project/imageprediction/current_item.txt").First(); // gets the first line from file.
            //string json = File.ReadAllText("E:/CS Project/imageprediction/properties_new.json");
            //dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //int currentitem = jsonObj["current_item"];

            var GAN = Model.LoadModel("E:/CS Project/GAN_MODELS/" + "wine glass" + ".h5");

            var x_input = Numpy.np.random.randn(100);
            x_input = x_input.reshape(1, 100);
            var X = GAN.Predict(x_input);
            X = ((X + 1) / 2);
            X = (X * 255).astype(np.uint8);
            var image = ImageUtil.ArrayToImg(X[0]);
            image.save("E:/CS Project/imageprediction/aidrawing.png");

            //GAN.Summary();
            //Generate latent points:
            //Console.WriteLine(X.shape);
            //var X_new = X[0].GetData<float>(); //important line which makes the below code redundant (as it didn't work anyway)
            //Console.Write(X_new.shape());

            //The following lines were all attempts to save to an image but were unsucessful
            //var img = Keras.PreProcessing.Image.ImageUtil.ArrayToImg(X[0]);
            //Console.WriteLine(img.size());
            //Keras.PreProcessing.Image.ImageDataGenerator.save
            //var train_datagen = new ImageDataGenerator();
            //var mat = new OpenCvSharp.Mat(X_new);
            //Cv2.ImWrite("E:/CS Project/GAN_MODELS/test.jpg", mat);
            //cv2.imwrite("E:/CS Project/GAN_MODELS/test.jpg", X_new);
            //Console.WriteLine(X_new.Length);

            //Console.WriteLine(X[0]);

            //So just write numpy array to disk.
            //Numpy.np.savetxt("E:/CS Project/GAN_MODELS/test.csv", X[0]);
            //Console.WriteLine(X[0].Length);
            //Console.WriteLine(X_new.Length);


            //image = image.resize((500, 500));
            //Console.WriteLine("Test if successful");



        }


    }
}
