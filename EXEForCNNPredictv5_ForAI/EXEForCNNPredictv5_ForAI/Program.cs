using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
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

namespace EXEForCNNPredictv5_ForAI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string>();

            //predict
            var cnn = Model.LoadModel("E:/CS Project/imageprediction/trainedafteroneepoch30classesmoreparameters.h5");
            int img_width = 28;
            int img_height = 28;
            var img = Keras.PreProcessing.Image.ImageUtil.LoadImg("E:/CS Project/imageprediction/aidrawing.png", target_size: (img_width, img_height));
            var img_smaller = Keras.PreProcessing.Image.ImageUtil.ImageToArray(img);
            var img_correct_format = Numpy.np.expand_dims(img_smaller, axis: 0);
            var predictions = cnn.Predict(img_correct_format);
            //Console.WriteLine(prediction);
            //var reader = new StreamReader("E:/CS Project/pythoncodetest/items.txt");


            //for some reason the predictions contains integers - will have to come back to this!

            Console.WriteLine(predictions);
            var predictionsasarray = predictions.GetData<float>();
            //Console.WriteLine(predictionsasarray[0]);

            //create list of items
            foreach (string item in File.ReadLines("E:/CS Project/imageprediction/finalitemlist.txt"))
            {
                items.Add(item);
            }

            //Find the current item
            int currentitemindex = 0;
            string currentitem = File.ReadLines("E:/CS Project/imageprediction/current_item.txt").First(); // gets the first line from file.
            for (int j = 0; j < items.Count; j++)
            {
                if (items[j] == currentitem)
                {
                    currentitemindex = j;
                }
            }
            /*
            Console.WriteLine(predictions);
            for (int j = 0; j < items.Count; j++)
            {
                Console.WriteLine(predictionsasarray[j]);
            }
            */

            float confidenceforaidrawing = predictionsasarray[currentitemindex];
            //Console.WriteLine("confidence is" + confidence.ToString());

            /*
            File.WriteAllText("E:/CS Project/imageprediction/confidenceforaidrawing.txt", String.Empty);

            using (StreamWriter w = File.AppendText(@"E:/CS Project/imageprediction/confidenceforaidrawing.txt"))
            {
                w.WriteLine(confidenceforaidrawing.ToString());
            }
            */

            string json = File.ReadAllText(@"E:/CS Project/imageprediction/properties.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //Console.WriteLine(confidence);
            jsonObj["confidenceforaidrawing"] = confidenceforaidrawing;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"E:/CS Project/imageprediction/properties.json", output);
        }
    }
}
