using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Threading.Tasks;

namespace Timer
{
    public class CountDownTimerOOP// : MonoBehaviour
    {
        protected float currentTime;
        protected string prediction;
       // protected int width;
        //protected int height;
        //protected int startX;
        //protected int startY;
        protected TextMeshProUGUI countdowntext;
        protected TakeaScreenshot takescreenshot;
        protected CNN_OOP predictusingcnn;

        //private CommonAttributes properties;


        public CountDownTimerOOP(TextMeshProUGUI countdowntext)
        {
            this.currentTime = Singletonattributes.Instance.amountoftime;
            this.countdowntext = countdowntext;
            this.takescreenshot = new TakeaScreenshot();
            this.predictusingcnn = new CNN_OOP();
            //this.properties = new CommonAttributes();


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
                return countdowntext;
            }

            set
            {
                countdowntext = value;
            }
        }


        public virtual void CountDown() //Virtual keyword allows us to override this method.
        {

            currentTime -= 1 * Time.deltaTime;
            countdowntext.text = currentTime.ToString("0");

            
            if (currentTime <= 0)
            {
                currentTime = 10;

                takescreenshot.Screenshot();
                //int imax = predictusingcnn.PredictOnImage();
                int imax = predictusingcnn.StartProcessContingency();


                /*
                List<string> items = new List<string>();

                string json = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                int numberofitems = 30;

                for (int i = 0; i < numberofitems - 1; i++)
                {
                    string item = jsonObj["items"][i];
                    items.Add(item);
                }

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

                */

                //var player = CNN_OOP.FindObjectOfType(CNN_OOP);
                //GameManager gameManager = GameObject.Find("CNN_OOP").GetComponent<CNN_OOP>();

                /*
                int current_round1 = player.RoundCounter;
                UnityEngine.Debug.Log("current round is " + current_round1.ToString());

                int current_round2 = player.RoundCounter;
                properties.RoundCounter = current_round1++;
                */
                /*
                int current_round = Singletonattributes.Instance.roundcounter;
                UnityEngine.Debug.Log(current_round);
                */

                Singletonattributes.Instance.roundcounter++;

                string[] items = Singletonattributes.Instance.items;
                string predictionword = items[imax];
                Singletonattributes.Instance.predictionword = predictionword;

                string currentitem = Singletonattributes.Instance.current_item;

                if (predictionword == currentitem)
                {
                    /*
                    int currentpoints = jsonObj["pointcounter"];
                    currentpoints++;
                    jsonObj["pointcounter"] = currentpoints;
                    string outputpoints = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("E:/CS Project/imageprediction/properties.json", outputpoints);
                    */

                    Singletonattributes.Instance.pointcounter++;


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
