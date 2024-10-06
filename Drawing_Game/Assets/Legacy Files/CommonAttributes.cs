/*
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CommonAttributes : MonoBehaviour
{
    //Set the intital values to zero, and then instantiate this object by having a manager which is attached to main menu. Then we can have getters and setters and increase when needed.
    private int numberofitems = 30;
    private int confidence;
    private int confidenceforaidrawing;
    private int confidenceforuserdrawing;
    private string current_item;
    private string predictionword;
    private int pointcounter;
    private int roundcounter = 1;
    private string[] items;
    private string json = File.ReadAllText("E:/CS Project/imageprediction/items.json");
    private dynamic jsonObj;

    /*
    public void SetInitialValues()
    {
        this.confidence = 0;
        this.confidenceforaidrawing = 0;
        this.confidenceforuserdrawing = 0;
        this.pointcounter = 0;
        this.roundcounter = 0;
        this.items = new string[30];
        this.jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        for (int i = 0; i < numberofitems - 1; i++)
        {
            string item = jsonObj["items"][i];
            items[i] = item;
        }
        UnityEngine.Debug.Log("Inital values initalised");

    }
    

    //getters and setters

    public string[] Items
    {
        get
        {
            return items;
        }

    }

    public int Confidence
    {
        get
        {
            return confidence;
        }

        set
        {
            confidence = value;
        }

    }

    public int ConfidenceForAIDrawing
    {
        get
        {
            return confidenceforaidrawing;
        }

        set
        {
            confidenceforaidrawing = value;
        }

    }

    public int ConfidenceForUserDrawing
    {
        get
        {
            return confidenceforuserdrawing;
        }

        set
        {
            confidenceforuserdrawing = value;
        }

    }

    public string CurrentItem
    {
        get
        {
            return current_item;
        }

        set
        {
            current_item = value;
        }

    }

    public string PredictionWord
    {
        get
        {
            return predictionword;
        }

        set
        {
            predictionword = value;
        }

    }

    public int PointCounter
    {
        get
        {
            return pointcounter;
        }

        set
        {
            pointcounter = value;
        }

    }

    public int RoundCounter
    {
        get
        {
            return roundcounter;
        }

        set
        {
            roundcounter = value;
        }

    }


}
*/