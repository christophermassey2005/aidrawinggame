using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Diagnostics;
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

public class CNN_OOP// : MonoBehaviour
{
    /*
    public void TrainModel()
    {
        var model = new Sequential();
        model.Add(new Conv2D(32, (3, 3).ToTuple(), input_shape: new Shape(28, 28, 3)));
        model.Add(new Activation("relu"));
        model.Add(new MaxPooling2D(pool_size: (2, 2).ToTuple()));

        model.Add(new Conv2D(32, (3, 3).ToTuple(), input_shape: new Shape(28, 28, 3)));
        model.Add(new Activation("relu"));
        model.Add(new MaxPooling2D(pool_size: (2, 2).ToTuple()));

        model.Add(new Conv2D(32, (3, 3).ToTuple(), input_shape: new Shape(28, 28, 3)));
        model.Add(new Activation("relu"));
        model.Add(new MaxPooling2D(pool_size: (2, 2).ToTuple()));

        model.Add(new Flatten());
        model.Add(new Dense(64));
        model.Add(new Activation("relu"));
        model.Add(new Dropout(0.5));
        model.Add(new Dense(68));
        model.Add(new Activation("softmax"));

        //model.Compile(loss: "categorical_crossentropy", optimizer: new RMSprop(), metrics: new String[] { "accuracy" });
        model.Compile(optimizer: "sgd", loss: "categorical_crossentropy", metrics: new string[] { "accuracy" });
        model.Summary();

        var train_datagen = new ImageDataGenerator();
        var train_generator = train_datagen.FlowFromDirectory(directory: "E:/CS Project/pythoncodetest/imagdatajpegs68", target_size: (28, 28).ToTuple(), batch_size: 32, class_mode: "categorical");
        //var x_batch, y_batch = new Next(train_generator);

        Console.WriteLine("Data successfully loaded");
        //model.FitGenerator(train_generator, epochs: 1);
        model.FitGenerator(train_generator, epochs: 1);
        model.Save("weights.h5");

    }
    */
    /*
    public int PredictOnImage()
    {
        List<string> items = new List<string>();

        //predict
        var cnn = Model.LoadModel("E:/CS Project/imageprediction/trainedafteroneepoch30classesmoreparameters.h5");
        int img_width = 28;
        int img_height = 28;
        var img = Keras.PreProcessing.Image.ImageUtil.LoadImg("E:/CS Project/imageprediction/croppedprediction.png", target_size: (img_width, img_height));
        var img_smaller = Keras.PreProcessing.Image.ImageUtil.ImageToArray(img);
        var img_correct_format = Numpy.np.expand_dims(img_smaller, axis: 0);
        var predictions = cnn.Predict(img_correct_format);
        var predictionsasarray = predictions.GetData<float>();
        foreach (string item in File.ReadLines("E:/CS Project/imageprediction/finalitemlist.txt"))
        {
            items.Add(item);
        }

        //find index of highest value
        int imax = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (predictionsasarray[i] > predictionsasarray[imax])
                imax = i;
        }

        //imax is the index of predictionsasarray with the greatest value (confidence)
        //Therefore:
        float confidence = predictionsasarray[imax];


        //Console.WriteLine(confidence);
        string json = File.ReadAllText(@"E:/CS Project/imageprediction/properties.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        jsonObj["confidence"] = confidence;
        string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(@"E:/CS Project/imageprediction/properties.json", output);

        return imax;
    }
    */
 
    public int StartProcessContingency()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "E:/CS Project/EXEForCNNPredictv6/EXEForCNNPredictv5/bin/x64/Debug/netcoreapp3.1/EXEForCNNPredictv5";
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;

        Process processTemp = new Process();
        processTemp.StartInfo = startInfo;
        processTemp.EnableRaisingEvents = true;
        processTemp.Start();
        processTemp.WaitForExit();
        int imax = processTemp.ExitCode;
        return imax;

    }


}
