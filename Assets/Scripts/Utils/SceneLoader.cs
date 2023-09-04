using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string MainMenu;
    public string Credits;

    public void LoadMainMenu() => SceneManager.LoadScene(this.MainMenu);

    public void LoadCredits() => SceneManager.LoadScene(this.Credits);

    public void LoadLevel(string levelName)
    {
        foreach (Level level in MasterObject.instance.levelStateManager.Level)
        {
            if (level.LevelName == levelName)
            {
                MasterObject.instance.levelStateManager.ActiveLevel = level;
                SceneManager.LoadScene(level.LevelName);
                break;
            }
        }
    }
}