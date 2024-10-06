using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class reset : MonoBehaviour
{
    private string jsonwrite = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
    // Start is called before the first frame update
    void Start()
    {
        dynamic jsonObjwrite = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonwrite);
        jsonObjwrite["roundcounter"] = 0;
        jsonObjwrite["pointcounter"] = 0;
        string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObjwrite, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("E:/CS Project/imageprediction/properties.json", output);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
