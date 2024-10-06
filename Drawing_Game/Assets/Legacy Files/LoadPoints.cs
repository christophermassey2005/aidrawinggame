using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using System.Linq;

public class LoadPoints : MonoBehaviour
{
    private List<string> rounds = new List<string>();
    private List<string> points = new List<string>();
    public TMP_Text pointsscored;
    int i_points;
    string s_points;

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (string round in File.ReadLines("E:/CS Project/imageprediction/roundcounter.txt"))
        {
            rounds.Add(round);
        }

        foreach (string point in File.ReadLines("E:/CS Project/imageprediction/pointcounter.txt"))
        {
            points.Add(point);
        }
        i_points = points.Count;
        s_points = i_points.ToString();
        
        pointsscored.text = "Points: " + s_points;
        */

        string jsonwrite = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
        dynamic jsonObjwrite = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonwrite);
        int currentpoints = jsonObjwrite["pointcounter"];

        pointsscored.text = "Points: " + currentpoints;


    }

    // Update is called once per frame
    /*
    void Update()
    {
        //Debug.Log(rounds.Count);
        if (rounds.Count >= 10)
        {
            File.WriteAllText("E:/CS Project/imageprediction/pointcounter.txt", String.Empty);
        }
    }
    */
}
