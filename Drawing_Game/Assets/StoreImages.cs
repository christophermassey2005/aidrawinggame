using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StoreImages : MonoBehaviour
{
    private int length;
    private string[] pathtouserdrawings;
    // Start is called before the first frame update
    void Start()
    {
        //Find the length of this folder
        pathtouserdrawings = Directory.GetFiles(@"E:/CS Project/UserDrawings", "*.png", SearchOption.TopDirectoryOnly);
        length = pathtouserdrawings.Length;
        //Copy the image of the screenshot first to this new folder - the number will be equal to the length of the folder.
        System.IO.File.Copy("E:/CS Project/imageprediction/croppedprediction.png", "E:/CS Project/UserDrawings/UserDrawing" + (length + 1).ToString() + ".png");


    }

}
