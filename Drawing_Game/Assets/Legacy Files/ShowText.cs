using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using Random = System.Random;


public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI objecttodraw;
    public List<string> items = new List<string>();
    public Random rnd = new Random();
    string item;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //create list of items
        foreach (string item_iteration in File.ReadLines("E:/CS Project/imageprediction/finalitemlist.txt"))
        {
            items.Add(item_iteration);
        }
        */

        string json = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        int numberofitems = 30;

        for (int i = 0; i < numberofitems - 1; i++)
        {
            //UnityEngine.Debug.Log(jsonObj["items"][i]);
            string item = jsonObj["items"][i];
            items.Add(item);
        }

        int number = rnd.Next(0, items.Count - 1);
        item = items[number];
        //Debug.Log(item);

        //File.WriteAllText("E:/CS Project/imageprediction/current_item.txt", item);

        jsonObj["current_item"] = item;
        string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("E:/CS Project/imageprediction/properties.json", output);

        objecttodraw.text = "Draw a " + item;

    }

    // Update is called once per frame
    void Update()
    {



    }

    /*
    public void ChangeItem(string olditem)
    {
        objecttodraw.text = "Draw a " + olditem;
    }
    */
    /*
    public string ShareItem()
    {
        Debug.Log(item);
        return item;
    }
    */
}
