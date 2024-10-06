using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using Random = System.Random;

public class ShowTextOOP : MonoBehaviour
{
    public TextMeshProUGUI objecttodraw;
    private string[] items = Singletonattributes.Instance.items;
    private Random rnd = new Random();
    private string item;
    // Start is called before the first frame update
    void Start()
    {
        int number = rnd.Next(0, items.Length - 1);
        item = items[number];
        Singletonattributes.Instance.current_item = item;

        objecttodraw.text = "Draw a " + item;

        //Write to Json file to allow GAN to work:

        string json = File.ReadAllText("E:/CS Project/imageprediction/properties_new.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        jsonObj["current_item"] = item;
        string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("E:/CS Project/imageprediction/properties_new.json", output);


    }

}
