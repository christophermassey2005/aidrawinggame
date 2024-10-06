using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class AIAdjudicatorOOP : MonoBehaviour
{
    public TextMeshProUGUI WhoWon;

    // Start is called before the first frame update
    void Start()
    {
        /*
        string json = File.ReadAllText(@"E:/CS Project/imageprediction/properties_new.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        float confidenceforaidrawingfloat = jsonObj["confidenceforaidrawing"];
        float confidenceforuserdrawingfloat = jsonObj["confidenceforuserdrawing"];

        */
        Singletonattributes.Instance.roundcounter++;
        float confidenceforuserdrawingfloat = Singletonattributes.Instance.confidenceforuserdrawing;
        float confidenceforaidrawingfloat = Singletonattributes.Instance.confidenceforaidrawing;



        if (confidenceforuserdrawingfloat > confidenceforaidrawingfloat)
        {
            WhoWon.text = "You won this round. The confidence for the AI's drawing was " + (confidenceforaidrawingfloat * 100).ToString("n2") + "%," + " whereas the confidence for your drawing was " + (confidenceforuserdrawingfloat * 100).ToString("n2") + "%.";

            Singletonattributes.Instance.roundcounter++;


        }
        else
        {
            WhoWon.text = "The AI won this round. The confidence for the AI's drawing was " + (confidenceforaidrawingfloat * 100).ToString("n2") + "%," + " whereas the confidence for your drawing was " + (confidenceforuserdrawingfloat * 100).ToString("n2") + "%.";

        }

    }

}
