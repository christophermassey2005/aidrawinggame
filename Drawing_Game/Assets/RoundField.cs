using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class RoundField : MonoBehaviour
{
    public string numberofrounds;
    public GameObject inputField;
    public GameObject textDisplay;
    private string regexpattern;

    public RoundField()
    {
        this.regexpattern = @"^(1[0-9]|20|[2-9])$";
    }

    public void Store()
    {
        numberofrounds = inputField.GetComponent<Text>().text;
        UnityEngine.Debug.Log(numberofrounds);
        //Use REGEX to check that it is in the correct range:
        Singletonattributes.Instance.numberofrounds = Int32.Parse(numberofrounds);

        try
        {

            if (Regex.IsMatch(numberofrounds, regexpattern)) //Check if it's in the range of 0 to 10.
            {
                Singletonattributes.Instance.numberofrounds = Int32.Parse(numberofrounds);

            }


        }

        catch (Exception error)
        {
            UnityEngine.Debug.Log(error.Message);
        }
    }

}
