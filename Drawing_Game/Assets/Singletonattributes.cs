using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletonattributes : MonoBehaviour
{
    public static Singletonattributes Instance { get; private set; }

    public int numberofrounds;
    public int amountoftime;
    public float thickness;
    public float confidence;
    public float confidenceforaidrawing;
    public float confidenceforuserdrawing;
    public string current_item;
    public string predictionword;
    public int pointcounter;
    public int roundcounter;
    public string[] items = { "airplane", "alarm clock", "ambulance", "arm", "bush", "cake", "car", "carrot", "cat", "cow", "eye", "hamburger", "house", "light bulb", "lipstick", "moon", "mouse", "nose", "panda", "pig", "pizza", "rainbow", "scissors", "shorts", "snail", "tiger", "van", "violin", "wine glass", "zebra" };


    private void Awake() //Awake is called before Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
