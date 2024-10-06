using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class Buttons_gm2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Home_GM2()
    {
        SceneManager.LoadScene("Menu");

    }

    // Update is called once per frame
    public void Skip_GM2()
    {
        SceneManager.LoadScene("Game2");
        /*
        using (StreamWriter w = File.AppendText(@"E:\CS Project\imageprediction\roundcounter.txt"))
        {
            w.WriteLine("+1 round");
        }
        */
    }
}
