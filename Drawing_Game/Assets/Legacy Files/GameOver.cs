using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


public class GameOver : MonoBehaviour
{

    public TMP_Text numberofpointstext;
    private string json = File.ReadAllText("E:/CS Project/imageprediction/properties.json");


    // Start is called before the first frame update
    void Start()
    {
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        int points = jsonObj["pointcounter"];

        numberofpointstext.text = "At the end of the game, the total number of points you scored was " + points.ToString() + ".";

    }

}