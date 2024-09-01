
#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public class BuildScript
{
    [MenuItem("Build/Build and Run")]
    public static void BuildAndRun()
    {
        string[] scenes = { "Assets\\Scenes\\SampleScene.unity" }; // Adjust the scene path as needed
        string buildPath = "C:\\Users\\User\\Desktop\\4th year 2nd sem 2024\\CEG4913\\CODE\\Python stuff\\Form detector\\Unity Animator Entity\\MotionCapture.exe"; // Adjust build path and executable name

        BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.StandaloneWindows64, BuildOptions.EnableHeadlessMode);

        // Run the built executable
        System.Diagnostics.Process.Start(buildPath);
    }
}

#endif