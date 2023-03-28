using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempManagerLevels : MonoBehaviour
{
    public void RestartLevel()
    {
        GameMaster.ReloadScene();
    }
    public void TitleScreen()
    {
        GameMaster.LoadTitle();
    }
}
