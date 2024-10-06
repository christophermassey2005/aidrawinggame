using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Diagnostics;

public class GAN_OOP : MonoBehaviour
{
    public void RunGANContingency()
    {
        ProcessStartInfo runGANStartInfo = new ProcessStartInfo();
        runGANStartInfo.FileName = "E:/CS Project/GAN_Predictv3/GAN_Predictv2/bin/x64/Debug/GAN_Predictv2";
        runGANStartInfo.RedirectStandardOutput = true;
        runGANStartInfo.RedirectStandardError = true;
        runGANStartInfo.UseShellExecute = false;
        runGANStartInfo.CreateNoWindow = true;

        Process RunGAN = new Process();
        RunGAN.StartInfo = runGANStartInfo;
        RunGAN.EnableRaisingEvents = true;
        RunGAN.Start();
        RunGAN.WaitForExit();
    }

    public void RunCNNOnUserDrawingContingency()
    {
        //Run CNN on user drawing:
        ProcessStartInfo RunCNNonUserDrawingStartInfo = new ProcessStartInfo();
        RunCNNonUserDrawingStartInfo.FileName = "E:/CS Project/EXEForCNNPredictv6_ForUserDrawing/EXEForCNNPredictv5_ForUserDrawing/bin/x64/Debug/netcoreapp3.1/ExeForCNNPredictv5_ForUserDrawing";
        RunCNNonUserDrawingStartInfo.RedirectStandardOutput = true;
        RunCNNonUserDrawingStartInfo.RedirectStandardError = true;
        RunCNNonUserDrawingStartInfo.UseShellExecute = false;
        RunCNNonUserDrawingStartInfo.CreateNoWindow = true;

        Process RunCNNonUserDrawing = new Process();
        RunCNNonUserDrawing.StartInfo = RunCNNonUserDrawingStartInfo;
        RunCNNonUserDrawing.EnableRaisingEvents = true;
        RunCNNonUserDrawing.Start();
        RunCNNonUserDrawing.WaitForExit();

    }

    public void RunCNNOnAIDrawingContingency()
    {
        //Run CNN on AI Drawing:
        ProcessStartInfo RunCNNonAIDrawingStartInfo = new ProcessStartInfo();
        RunCNNonAIDrawingStartInfo.FileName = "E:/CS Project/EXEForCNNPredictv6_ForAI/EXEForCNNPredictv5_ForAI/bin/x64/Debug/netcoreapp3.1/EXEForCNNPredictv5_ForAI";
        RunCNNonAIDrawingStartInfo.RedirectStandardOutput = true;
        RunCNNonAIDrawingStartInfo.RedirectStandardError = true;
        RunCNNonAIDrawingStartInfo.UseShellExecute = false;
        RunCNNonAIDrawingStartInfo.CreateNoWindow = true;

        Process RunCNNonAIDrawing = new Process();
        RunCNNonAIDrawing.StartInfo = RunCNNonAIDrawingStartInfo;
        RunCNNonAIDrawing.EnableRaisingEvents = true;
        RunCNNonAIDrawing.Start();
        RunCNNonAIDrawing.WaitForExit();

    }

}
