using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Timer
{
    public class CountDownTimerOOP_GM2 : CountDownTimerOOP
    {
        private CountDownTimerOOP CallCountDownTimerOOP;
        private GAN_OOP rungan;
        //private RunGAN = new GAN_OOP();
        public TextMeshProUGUI text;


        //Call constructor of parent class - this requires the base(text) keyword
        public CountDownTimerOOP_GM2(TextMeshProUGUI text) : base(text)
        {
            CallCountDownTimerOOP = new CountDownTimerOOP(text);
            this.rungan = new GAN_OOP();
        }

        //Polymorphism
        public override void CountDown()
        {

            currentTime -= 1 * Time.deltaTime;
            countdowntext.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 10;

                takescreenshot.Screenshot();
                rungan.RunGANContingency();
                UnityEngine.Debug.Log("GAN run");
                rungan.RunCNNOnUserDrawingContingency();
                UnityEngine.Debug.Log("CNN run");
                rungan.RunCNNOnAIDrawingContingency();
                UnityEngine.Debug.Log("CNN run");
                SceneManager.LoadScene("Postround_Gamemode2");

            }

            /*
            if (currentTime <= 0)
            {
                currentTime = 10;

                takescreenshot.Screenshot();
                int imax = predictusingcnn.StartProcessContingency();

                Singletonattributes.Instance.roundcounter++;

                string[] items = Singletonattributes.Instance.items;
                string predictionword = items[imax];
                Singletonattributes.Instance.predictionword = predictionword;

                string currentitem = Singletonattributes.Instance.current_item;



                SceneManager.LoadScene("Postround_Gamemode2");


            }
            */


        }
    }
}

