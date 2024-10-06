using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Threading.Tasks;
using System.Diagnostics;

public class TakeaScreenshot// : MonoBehaviour
{
    private int width = 685;
    private int height = 377;
    private int startX = 235;
    private int startY = 60;

    public void Screenshot()
    {
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        Rect rex = new Rect(startX, startY, width, height);
        tex.ReadPixels(rex, 0, 0);
        tex.Apply();
        // Encode texture into PNG
        var bytes = tex.EncodeToPNG();
        System.IO.File.WriteAllBytes("E:/CS Project/imageprediction/croppedprediction.png", bytes);
        //Destroy(tex);


    }
}
