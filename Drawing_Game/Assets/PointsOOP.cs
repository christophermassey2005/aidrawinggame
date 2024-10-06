using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PointsOOP// : MonoBehaviour
{
    private string topscore;
    private int roundpoints;
    private string regexpattern = "@^(10|[0-9])$";

    public PointsOOP()
    {
        this.roundpoints = Singletonattributes.Instance.pointcounter;
    }

    public void WriteTopScore()
    {
        try
        {
            string json = File.ReadAllText("E:/CS Project/imageprediction/topscsores.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            topscore = jsonObj["topscore"];

            if(Regex.IsMatch(topscore, regexpattern)) //Check if it's in the range of 0 to 10.
            {
                if (roundpoints > int.Parse(topscore))  //Check that it is in the correct range:
                {
                    jsonObj["topscore"] = roundpoints;
                }
            }


        }

        catch (Exception error)
        {
            UnityEngine.Debug.Log(error.Message);
        }

    }

}


