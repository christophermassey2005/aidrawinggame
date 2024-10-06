using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System;

public class LoadEndCard : MonoBehaviour
{
    public int round;
    private string jsonread = File.ReadAllText("E:/CS Project/imageprediction/properties.json");

    // Start is called before the first frame update
    void Start()
    {
        dynamic jsonObjread = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonread);
        round = jsonObjread["roundcounter"];


    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(rounds.Count);
        if (round >= 10)
        {
            SceneManager.LoadScene("EndCard");

        }

    }   
}
