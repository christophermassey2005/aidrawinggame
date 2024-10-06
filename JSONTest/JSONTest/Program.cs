using System;
//using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
//using System.Text.Json;


namespace JSONTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string json = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            Console.WriteLine(jsonObj["items"][0]);
            //jsonObj["confidence"] = 10;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("E:/CS Project/imageprediction/properties.json", output);

            */
            //JArray items = (JArray)test["JSONObject"];

            
            List<string> items = new List<string>();


            string json = File.ReadAllText("E:/CS Project/imageprediction/properties.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            int numberofitems = 30;

            for (int i = 0; i < numberofitems - 1; i++)
            {
                //UnityEngine.Debug.Log(jsonObj["items"][i]);
                string item = jsonObj["items"][i];
                //Console.WriteLine(item);
                items.Add(jsonObj[item]);
            }


            Console.WriteLine(jsonObj["items"][0]);
            jsonObj["confidence"] = 10;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("E:/CS Project/imageprediction/properties.json", output);

        }
    }


}
