using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TempManager : MonoBehaviour
{
    [SerializeField] float speed;
    float targetRotY;
    Transform cam;
    bool fullscreenState = true;
    float timeCount = 0;
    [SerializeField] TMP_Dropdown resolution;
    int[] width = { 1920, 1600, 1280, 1280, 1280, 1024 };
    int[] height = { 1080, 900, 1024, 800, 720, 768 };
    private void Start()
    {
        cam = Camera.main.transform;
    }
    private void Update()
    {
        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(0, targetRotY, 0), timeCount);
        if (timeCount <= 1)
            timeCount += Time.deltaTime * speed;
    }
    public void Fullscreen()
    {
        fullscreenState = !fullscreenState;
        Screen.SetResolution(Screen.width, Screen.height, fullscreenState);
    }
    public void LoadLevel(int level)
    {
        GameMaster.LoadScene(level);
    }
    public void TurnCamera(int state)
    {
        switch (state)
        {
            case 1:
                targetRotY = 90;
                break;
            case 0:
                targetRotY = 0;
                break;
            case -1:
                targetRotY = -90;
                break;
        }
        timeCount = 0;
    }
    public void Quit()
    {
        GameMaster.QuitGame();
    }
    public void ChangeResolution()
    {
        int val = resolution.value;
        Screen.SetResolution(width[val], height[val], fullscreenState);
    }
}
