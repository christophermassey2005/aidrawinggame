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

/*
using Keras.Models;
using Keras.PreProcessing.Image;
using Numpy;
*/


public class CountdownTimer_forgm2 : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;
    string prediction;

    int width = 692;
    int height = 377;
    int startX = 240;
    int startY = 64;

    public TMP_Text countdownText_forgm2;

    void Start()
    {
        currentTime = startingTime;

    }

    void Update()
    {
      
        currentTime -= 1 * Time.deltaTime;
        countdownText_forgm2.text = currentTime.ToString("0");
        //Unity.Debug.Log("test"); 

        if (currentTime <= 0)
        {
            currentTime = 0;

            // Take screenshot
            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            Rect rex = new Rect(startX, startY, width, height);
            tex.ReadPixels(rex, 0, 0);
            tex.Apply();
            // Encode texture into PNG
            var bytes = tex.EncodeToPNG();
            System.IO.File.WriteAllBytes("E:/CS Project/imageprediction/croppedprediction.png", bytes);
            Destroy(tex);

            List<string> items = new List<string>();

            foreach (string item in File.ReadLines("E:/CS Project/imageprediction/finalitemlist.txt"))
            {
                items.Add(item);
            }

            string currentitem = File.ReadLines("E:/CS Project/imageprediction/current_item.txt").First(); // gets the first line from file.

            
            ProcessStartInfo runGANStartInfo = new ProcessStartInfo();
            runGANStartInfo.FileName = "E:/CS Project/GAN_Predictv2/GAN_Predictv2/bin/x64/Debug/GAN_Predictv2";
            runGANStartInfo.RedirectStandardOutput = true;
            runGANStartInfo.RedirectStandardError = true;
            runGANStartInfo.UseShellExecute = false;
            runGANStartInfo.CreateNoWindow = true;

            Process RunGAN = new Process();
            RunGAN.StartInfo = runGANStartInfo;
            RunGAN.EnableRaisingEvents = true;
            RunGAN.Start();
            RunGAN.WaitForExit();

           
            //Run CNN on user drawing:
            ProcessStartInfo RunCNNonUserDrawingStartInfo = new ProcessStartInfo();
            RunCNNonUserDrawingStartInfo.FileName = "E:/CS Project/EXEForCNNPredictv5_ForUserDrawing/EXEForCNNPredictv5_ForUserDrawing/bin/x64/Debug/netcoreapp3.1/ExeForCNNPredictv5_ForUserDrawing";
            RunCNNonUserDrawingStartInfo.RedirectStandardOutput = true;
            RunCNNonUserDrawingStartInfo.RedirectStandardError = true;
            RunCNNonUserDrawingStartInfo.UseShellExecute = false;
            RunCNNonUserDrawingStartInfo.CreateNoWindow = true;

            Process RunCNNonUserDrawing = new Process();
            RunCNNonUserDrawing.StartInfo = RunCNNonUserDrawingStartInfo;
            RunCNNonUserDrawing.EnableRaisingEvents = true;
            RunCNNonUserDrawing.Start();
            RunCNNonUserDrawing.WaitForExit();

            //Run CNN on AI Drawing:
            ProcessStartInfo RunCNNonAIDrawingStartInfo = new ProcessStartInfo();
            RunCNNonAIDrawingStartInfo.FileName = "E:/CS Project/EXEForCNNPredictv5_ForAI/EXEForCNNPredictv5_ForAI/bin/x64/Debug/netcoreapp3.1/EXEForCNNPredictv5_ForAI";
            RunCNNonAIDrawingStartInfo.RedirectStandardOutput = true;
            RunCNNonAIDrawingStartInfo.RedirectStandardError = true;
            RunCNNonAIDrawingStartInfo.UseShellExecute = false;
            RunCNNonAIDrawingStartInfo.CreateNoWindow = true;

            Process RunCNNonAIDrawing = new Process();
            RunCNNonAIDrawing.StartInfo = RunCNNonAIDrawingStartInfo;
            RunCNNonAIDrawing.EnableRaisingEvents = true;
            RunCNNonAIDrawing.Start();
            RunCNNonAIDrawing.WaitForExit();


            SceneManager.LoadScene("Postround_Gamemode2");
            

            /*
            //Implement points system

            //Check if the item is correct:
            if (predictionword == currentitem)
            {
                using (StreamWriter w = File.AppendText(@"E:\CS Project\imageprediction\pointcounter.txt"))
                {
                    w.WriteLine("+1 point");
                }
                SceneManager.LoadScene("Postroundwon");

            }
            else
            {
                SceneManager.LoadScene("Postroundlost");

            }


            using (StreamWriter w = File.AppendText(@"E:\CS Project\imageprediction\roundcounter.txt"))
            {
                w.WriteLine("+1 round");
            }
            */

        }
        
    }
    
}
