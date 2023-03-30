using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameMaster
{
    public static int currentScene;
    public static float cameraSentivity = 250;
    public static bool paused = false;
    public static int currentResolution = 0;
    public static int fov = 70;
    static int defaultRes = 0;
    static int defaultFov = 70;
    static int defaultSenTivtity = 250;
    public static void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
        currentScene = scene;
        paused = false;
        Time.timeScale = 1;
    }
    public static void LoadTitle()
    {
        SceneManager.LoadScene(0);
        paused = false;
        currentScene = 0;
        Time.timeScale = 1;
    }
    public static void QuitGame()
    {
        Application.Quit();
        currentResolution = defaultRes;
        fov = defaultFov;
        cameraSentivity = defaultSenTivtity;
    }
    public static void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
        paused = false;
        Time.timeScale = 1;
    }
}
