using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class Buttons : MonoBehaviour
{
    //private ShowText AccessShowText;
    //private ShowText AccessShowText;
    //string current_item;

    // Start is called before the first frame update
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Skip()
    {
        SceneManager.LoadScene("Game");

        Singletonattributes.Instance.roundcounter++;


        /*
        using (StreamWriter w = File.AppendText(@"E:\CS Project\imageprediction\roundcounter.txt"))
        {
            w.WriteLine("+1 round");
        }
        */
    }
    /*
    public void Clear()
    {
        //Get current item
        //AccessShowText = GameObject.FindObjectOfType<ShowText>();
        //current_item = AccessShowText.ShareItem();
        //Debug.Log(current_item);
        //SceneManager.LoadScene("Game");
        //AccessShowText.ChangeItem(current_item);
        //Destroy(brush);
        //AccessDrawBehaviour = GameObject.FindObjectOfType<Draw_behaviour>();
        //AccessDrawBehaviour.Delete();

        current_item = File.ReadLines("E:/CS Project/imageprediction/current_item.txt").First();
        AccessShowText = GameObject.FindObjectOfType<ShowText>();
        SceneManager.LoadScene("Game");
        Debug.Log(current_item);
        AccessShowText.ChangeItem(current_item);


    }

    public void Rubber()
    {
        SceneManager.LoadScene("Game");
    }
    */
}
