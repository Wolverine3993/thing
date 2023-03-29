using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameMaster
{
    public static int currentScene;
    public static float cameraSentivity = 250;
    public static bool paused = false;
    public static void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
        currentScene = scene;
        paused = false;
    }
    public static void LoadTitle()
    {
        SceneManager.LoadScene(0);
        paused = false;
        currentScene = 0;
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
        paused = false;
    }
}
