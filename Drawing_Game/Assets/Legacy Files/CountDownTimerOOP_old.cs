/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Timer
{
    [System.Serializable]
    public class CountDownTimerOOP_old : MonoBehaviour
    {
        public float currentTime;
        private string prediction;
        private int width;
        private int height;
        private int startX;
        private int startY;
        public TextMeshProUGUI countdownText;

        public CountDownTimerOOP()
        {
            this.currentTime = 10f;
            this.width = 685;
            this.height = 377;
            this.startX = 235;
            this.startY = 60;
        }

        //Getters and setters needed for currenTime and startingTime

        public float CurrentTime
        {
            get
            {
                return currentTime;
            }

            set
            {
                currentTime = value;
            }

        }

        public TextMeshProUGUI CountdownText
        {
            get
            {
                return countdownText;
            }

            set
            {
                countdownText = value;
            }
        }

        //Method itself

        public void CountDown() //Or private?
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            /*
            if (currentTime <= 0)
            {
                currentTime = 10;

                var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
                Rect rex = new Rect(startX, startY, width, height);
                tex.ReadPixels(rex, 0, 0);
                tex.Apply();
                // Encode texture into PNG
                var bytes = tex.EncodeToPNG();
                System.IO.File.WriteAllBytes("E:/CS Project/imageprediction/croppedprediction.png", bytes);
                Destroy(tex);

                List<string> items = new List<string>();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "E:/CS Project/EXEForCNNPredictv5/EXEForCNNPredictv5/bin/x64/Debug/netcoreapp3.1/EXEForCNNPredictv5";
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
                    string item = jsonObj["items"][i];
                    items.Add(item);
                }

                int imax = processTemp.ExitCode;
                UnityEngine.Debug.Log("imax is" + imax.ToString());

                string predictionword = items[imax];
                string currentitem = jsonObj["current_item"];
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

                    int currentpoints = jsonObj["pointcounter"];
                    currentpoints++;
                    jsonObj["pointcounter"] = currentpoints;
                    string outputpoints = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("E:/CS Project/imageprediction/properties.json", outputpoints);


                    SceneManager.LoadScene("Postroundwon");

                }
                else
                {
                    SceneManager.LoadScene("Postroundlost");

                }

            }
            
        }
    }
}
*/