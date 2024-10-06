using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Threading.Tasks;
using System.Diagnostics;
//using System.Text.Json;

/*
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
*/

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 10f;
    //float startingTime = 10f;
    //private CNN AccessCNN;
    string prediction;

    int width = 685;
    int height = 377;
    int startX = 235;
    int startY = 60;
    //int predictcount = 0;
    //int points;

    //private TMP_Text pointsscored;
    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        //currentTime = startingTime;

    }

    void Update()
    {
        //UnityEngine.Debug.Log("test");
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        //Unity.Debug.Log("test"); 

        if (currentTime <= 0)
        {
            currentTime = 10; //or zero !?
            //ScreenCapture.CaptureScreenshot("E:/CS Project/imagepredictiondifferent/prediction.png");
            /*
            IEnumerator TakeScreenshot()
            {
                yield return new WaitForEndOfFrame();

                //string path = Application.persistentDataPath + "Screenshots/"
                //        + "_" +  + "_" + Screen.width + "X" + Screen.height + "" + ".png";

                Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
                //Get Image from screen
                screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
                screenImage.Apply();
                //Convert to png
                byte[] imageBytes = screenImage.EncodeToPNG();

                //Save image to file
                System.IO.File.WriteAllBytes("E:/CS Project/imageprediction/prediction.png", imageBytes);
            }
            */

            // Take screenshot
            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            Rect rex = new Rect(startX, startY, width, height);
            tex.ReadPixels(rex, 0, 0);
            tex.Apply();
            // Encode texture into PNG
            var bytes = tex.EncodeToPNG();
            System.IO.File.WriteAllBytes("E:/CS Project/imageprediction/croppedprediction.png", bytes);
            Destroy(tex);

            /*
            if ((predictcount % 300) == 0)
            {
                prediction = Makeaprediction();
                Debug.Log(prediction);
            }
            predictcount++;

            */

            //pass into CNN
            //AccessCNN = FindObjectOfType<CNN>();
            //prediction = AccessCNN.Makeaprediction();


            //List<string> items = new List<string>();

            /*
            foreach (string item in File.ReadLines("E:/CS Project/imageprediction/finalitemlist.txt"))
            {
                items.Add(item);
            }
            */

            List<string> items = new List<string>();



            

            /*
            var proc = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process.Start("E:/CS Project/EXEforCNNPredict/EXEforCNNPredict/bin/x64/Debug/EXEForCNNPredict");
            proc.WaitForExit();

            */
            /*
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = @"E:/CS Project/EXEforCNNPredict/EXEforCNNPredict/bin/x64/Debug/EXEForCNNPredict";
            p.Start();
            p.WaitForExit();
            */
            /*
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "E:/CS Project/EXEforCNNPredict/EXEforCNNPredict/bin/x64/Debug/EXEForCNNPredict";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = false;
            //psi.Arguments = ...
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true; // <- key line
            */

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "E:/CS Project/EXEForCNNPredictv5/EXEForCNNPredictv5/bin/x64/Debug/netcoreapp3.1/EXEForCNNPredictv5";
            //startInfo.Arguments = args;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            Process processTemp = new Process();
            processTemp.StartInfo = startInfo;
            processTemp.EnableRaisingEvents = true;
            processTemp.Start();
            processTemp.WaitForExit();

            string json = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            int numberofitems = 30;

            for (int i = 0; i < numberofitems - 1; i++)
            {
                //UnityEngine.Debug.Log(jsonObj["items"][i]);
                string item = jsonObj["items"][i];
                items.Add(item);
            }

            int imax = processTemp.ExitCode;
            UnityEngine.Debug.Log("imax is" + imax.ToString());

            string predictionword = items[imax];

            //Implement points system

            //Check if the item is correct:
            //string currentitem = File.ReadLines("E:/CS Project/imageprediction/current_item.txt").First(); // gets the first line from file.



            

            string currentitem = jsonObj["current_item"];

            //string jsonround = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
            //dynamic jsonObjround = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonround);
            int currentround = jsonObj["roundcounter"];
            currentround++;
            UnityEngine.Debug.Log(currentround.ToString());
            jsonObj["roundcounter"] = currentround;
            string outputround = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("E:/CS Project/imageprediction/properties.json", outputround);


            jsonObj["predictionword"] = predictionword;
            string outputpredictionword = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("E:/CS Project/imageprediction/properties.json", outputpredictionword);

            if (predictionword == currentitem)
            {
                /*
                using (StreamWriter w = File.AppendText(@"E:\CS Project\imageprediction\pointcounter.txt"))
                {
                    w.WriteLine("+1 point");
                }
                */
                int currentpoints = jsonObj["pointcounter"];
                currentpoints++;
                jsonObj["pointcounter"] = currentpoints;
                string outputpoints = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("E:/CS Project/imageprediction/properties.json", outputpoints);


                SceneManager.LoadScene("Postroundwon");
                //UnityEngine.Debug.Log("testifwon");

            }
            else
            {
                SceneManager.LoadScene("Postroundlost");
                //UnityEngine.Debug.Log("testiflost");

            }
            //Thread.Sleep(2000);

            //SceneManager.LoadScene("Game");


            //SceneManager.LoadScene("Game");
            //prediction = Makeaprediction();
            //Debug.Log(prediction);

            //OLD
            //SceneManager.LoadScene("Postround");
            /*
            if (prediction == )
            {

            }
            else
            {

            }
            */
            //Thread.Sleep(3000);
            //SceneManager.LoadScene("Game");



            //StartCoroutine(TakeScreenshot());
            //Reduce the dimensions of the screencap by accessing CNN.cs
            //AccessCNN = FindObjectOfType<CNN>();
            //AccessCNN.CropScreenshot();
            //Thread.Sleep(3000);


            //Thread.Sleep(500);
            //File.Delete(@"E:/CS Project/imageprediction/prediction.png");

            //CropScreenshot();

            //CropScreenshot();
            /*
            using (StreamWriter w = File.AppendText(@"E:\CS Project\imageprediction\roundcounter.txt"))
            {
                w.WriteLine("+1 round");
            }
            */
            



            //Debug.Log(prediction);


        }
        /*
        void CropScreenshot()
        {
            string imageFilePath = "E:/CS Project/imageprediction/prediction.png";

            Bitmap src = System.Drawing.Image.FromFile(imageFilePath) as Bitmap;

            int initialxaxis = 174;//The x-coordinate of the upper-left corner of the rectangle.
            int initialyaxis = 64;//The y-coordinate of the upper-left corner of the rectangle.
            int width = 695;//The width of the rectangle.
            int height = 377;//The height of the rectangle.

            Bitmap target = new Bitmap(width, height);//Create a new Bitmap object with the cropped size.

            Rectangle destinationRect = new Rectangle(initialxaxis, initialyaxis, width, height);

            RectangleF sourceRect = new RectangleF(initialxaxis, initialyaxis, width, height);

            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(target))
            {
                g.DrawImage(src, destinationRect,
                                 sourceRect,
                                 GraphicsUnit.Point);
                target.Save("E:/CS Project/imageprediction/croppedprediction.png");
            }
        }
        */
    }
    /*
    string Makeaprediction()
    {
        List<string> items = new List<string>();

        //predict
        Debug.Log("1");
        var cnn = Model.LoadModel("E:/CS Project/imageprediction/trainedafteroneepoch30classesmoreparameters.h5");
        Debug.Log("2");

        int img_width = 28;
        int img_height = 28;
        var img = Keras.PreProcessing.Image.ImageUtil.LoadImg("E:/CS Project/imageprediction/croppedprediction.png", target_size: (img_width, img_height));
        Debug.Log("3");

        var img_smaller = Keras.PreProcessing.Image.ImageUtil.ImageToArray(img);
        Debug.Log("4");

        var img_correct_format = Numpy.np.expand_dims(img_smaller, axis: 0);
        Debug.Log("5");

        var predictions = cnn.Predict(img_correct_format);
        Debug.Log("6");

        //Console.WriteLine(prediction);
        //var reader = new StreamReader("E:/CS Project/pythoncodetest/items.txt");
        var predictionsasarray = predictions.GetData<int>();
        Debug.Log("7");


        //create list of items
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

        //Console.WriteLine(items[imax]);
        string predictionword = items[imax];

        return predictionword;

    }
    */
}
