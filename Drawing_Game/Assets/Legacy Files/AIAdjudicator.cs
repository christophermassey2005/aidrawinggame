using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AIAdjudicator : MonoBehaviour
{
    public TMP_Text WhoWon;


    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(@"E:/CS Project/imageprediction/properties.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

        int currentround = jsonObj["roundcounter"];
        currentround++;
        jsonObj["pointcounter"] = currentround;
        string outputrounds = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("E:/CS Project/imageprediction/properties.json", outputrounds);



        float confidenceforaidrawingfloat = jsonObj["confidenceforaidrawing"];
        float confidenceforuserdrawingfloat = jsonObj["confidenceforuserdrawing"];



        if (confidenceforuserdrawingfloat > confidenceforaidrawingfloat)
        {
            WhoWon.text = "You won this round. The confidence for the AI's drawing was " + (confidenceforaidrawingfloat * 100).ToString("n2") + "%," + " whereas the confidence for your drawing was " + (confidenceforuserdrawingfloat * 100).ToString("n2") + "%.";
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

        }
        else
        {
            WhoWon.text = "The AI won this round. The confidence for the AI's drawing was " + (confidenceforaidrawingfloat * 100).ToString("n2") + "%," + " whereas the confidence for your drawing was " + (confidenceforuserdrawingfloat * 100).ToString("n2") + "%.";

        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
