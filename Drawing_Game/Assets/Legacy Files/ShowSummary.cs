using System;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowSummary : MonoBehaviour
{
    public TMP_Text predictionbyai;

    // Start is called before the first frame update
    void Start()
    {
        /*
        string confidenceinaidrawing = File.ReadLines("E:/CS Project/imageprediction/confidence.txt").First(); // gets the first line from file.
        float confidencefloat = float.Parse(confidenceinaidrawing);
        */

        string json = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        float confidencefloat = jsonObj["confidence"];


        //string currentitem = File.ReadLines("E:/CS Project/imageprediction/current_item.txt").First(); // gets the first line from file.

        string predictionword = jsonObj["predictionword"];



        predictionbyai.text = "The AI thought you drew a " + predictionword + " and had a confidence of " + (confidencefloat * 100).ToString("n2") + "%.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


