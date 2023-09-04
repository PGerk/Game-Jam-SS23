using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfLevelController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] ControlManager controlManager;

    public void OnWin()
    {
        MasterObject.instance.levelStateManager.ActiveLevel.LevelCompleted = true;
        this.textMeshProUGUI.text = "Congrats!!! You won the Level";
        this.EndLevel();
    }

    public void OnLose()
    {
        this.textMeshProUGUI.text = "Sorry You lost the Game";
        this.EndLevel();
    }

    public void OnClickMainMenu()
    {
        Time.timeScale = 1;
        MasterObject.instance.sceneLoader.LoadMainMenu();
    }

    private void EndLevel()
    {
        Time.timeScale = 0;
        this.controlManager.DeactivateControls();
        this.gameObject.SetActive(true);
    }
}
