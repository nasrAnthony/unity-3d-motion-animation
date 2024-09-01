using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class AnimationCode : MonoBehaviour
{
    public GameObject[] Body;
    int totalLMSnum = 32;
    List<string> lines;
    int counter = 0;

    public int frameRate = 30;
    public string folderName = "C:\\Users\\User\\Desktop\\4th year 2nd sem 2024\\CEG4913\\CODE\\Python stuff\\Form detector\\Animation Frames";

    private bool isRecording = false;
    private int frameCount = 0;

    void Start()
    {
        // Load lines from the file
        lines = System.IO.File.ReadLines("C:\\Users\\User\\Desktop\\4th year 2nd sem 2024\\CEG4913\\CODE\\Python stuff\\Form detector\\AnimationFileUnityData.txt").ToList();

        // Set frame rate for recording
        Time.captureFramerate = frameRate;

        // Start recording immediately
        isRecording = true;
        Debug.Log("Recording started.");
    }

    void Update()
    {
        for (int i = 0; i < totalLMSnum; i++)
        {
            string[] points = lines[counter].Split(',');
            float x = float.Parse(points[0 + (i * 3)]) / 100;
            float y = float.Parse(points[1 + (i * 3)]) / 100;
            float z = float.Parse(points[2 + (i * 3)]) / 100;
            Body[i].transform.localPosition = new Vector3(x, y, z);
        }

        counter++;

        if (isRecording)
        {
            // Capture each frame as a PNG file
            string name = string.Format("{0}/frame_{1:D04}.png", folderName, frameCount);
            ScreenCapture.CaptureScreenshot(name);
            frameCount++;
        }

        // When the counter hits the end of the file, stop the recording
        if (counter == lines.Count)
        {
            isRecording = false;
            Debug.Log("Recording stopped.");
            //counter = 0; // Reset counter if you want to loop the animation
            Application.Quit();
        }

        Thread.Sleep(30);
    }
}
