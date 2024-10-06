using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ShowSummaryOOP : MonoBehaviour
{
    public TextMeshProUGUI predictionbyai;

    // Start is called before the first frame update
    void Start()
    {
        /*
        string json = File.ReadAllText("E:/CS Project/imageprediction/confidencevalues.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        float confidencefloat = jsonObj["confidence"];
        */

        float confidencefloat = Singletonattributes.Instance.confidence;
        string predictionword = Singletonattributes.Instance.predictionword;

        predictionbyai.text = "The AI thought you drew a " + predictionword + " and had a confidence of " + (confidencefloat * 100).ToString("n2") + "%.";

    }

}
