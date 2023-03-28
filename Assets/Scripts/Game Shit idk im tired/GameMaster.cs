using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameMaster
{
    public static int currentScene;
    public static void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
        currentScene = scene;
    }
    public static void LoadTitle()
    {
        SceneManager.LoadScene(0);
        currentScene = 0;
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
