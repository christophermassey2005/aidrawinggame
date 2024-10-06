using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverOOP : MonoBehaviour
{
    private int points;
    public TextMeshProUGUI numberofpoints;


    // Start is called before the first frame update
    void Start()
    {
        points = Singletonattributes.Instance.pointcounter;

        numberofpoints.text = "At the end of the game, the total number of points you scored was " + points.ToString() + ".";

        


        //string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        //File.WriteAllText("E:/CS Project/imageprediction/topscores.json", output);

    }


}
