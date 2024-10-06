using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowAIImage : MonoBehaviour
{
    byte[] byteArray = File.ReadAllBytes(@"E:/CS Project/imageprediction/aidrawing.png");
   
    void Start()
    {     //create a texture and load byte array to it
          // Texture size does not matter 
        Texture2D sampleTexture = new Texture2D(2, 2);
        // the size of the texture will be replaced by image size
        // Use this for initialization
        // read image and store in a byte array

        bool isLoaded = sampleTexture.LoadImage(byteArray);
        // apply this texure as per requirement on image or material
        GameObject image = GameObject.Find("RawImage");
        if (isLoaded)
        {
            image.GetComponent<RawImage>().texture = sampleTexture;
        }
    }
}