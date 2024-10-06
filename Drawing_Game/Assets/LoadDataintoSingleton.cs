using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadDataintoSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        string json = File.ReadAllText(@"E:/CS Project/imageprediction/properties_new.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

        float confidence = jsonObj["confidence"];

        Singletonattributes.Instance.confidence = confidence;


    }


}
