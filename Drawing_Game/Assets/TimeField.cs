using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeField : MonoBehaviour
{
    public string amountoftime;
    public GameObject inputField;
    public GameObject textDisplay;
    private string regexpattern;
    public TextMeshProUGUI warningtext;

    public TimeField()
    {
        this.regexpattern = @"^(1[01][0-9]|120|[5-9]|[1-9][0-9])$"; //Check if between 5 and 120
    }

    public void Store()
    {
        amountoftime = inputField.GetComponent<Text>().text;
        UnityEngine.Debug.Log(amountoftime);
        //Use REGEX to check that it is in the correct range:
        Singletonattributes.Instance.amountoftime = Int32.Parse(amountoftime);

        try
        {

            if (Regex.IsMatch(amountoftime, regexpattern)) //Check if it's in the range of 5 to 120.
            {
                Singletonattributes.Instance.amountoftime = Int32.Parse(amountoftime);

            }
            else
            {
                warningtext.text = "Invalid input!";
                Singletonattributes.Instance.amountoftime = 10;
            }


        }

        catch (Exception error)
        {
            UnityEngine.Debug.Log(error.Message);
        }


    }

}
