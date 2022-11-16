using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    public void takeScreenshot()
    {
        string currentDateTime =
            DateTime.Now.ToString("yyyyMMdd_Hmmss");

        //You may want to use Application.persistentDataPath
        var directory =
            new DirectoryInfo(Application.dataPath + "\\Screenshots");

        var path = Path.Combine(
            directory.Parent.FullName,
            $"Screenshot_{currentDateTime}.png");

        Debug.Log(path);

        ScreenCapture.CaptureScreenshot(path);
    }

}