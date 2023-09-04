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
        if (MasterObject.instance?.levelStateManager?.ActiveLevel is not null)
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
        Debug.Log("Return to MainMenu");
        Time.timeScale = 1;
        MasterObject.instance.sceneLoader.LoadMainMenu();
    }

    private void EndLevel()
    {
        Time.timeScale = 0;
        this.controlManager.DeactivateControls();
        this.gameObject.SetActive(true);
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        Debug.Log("Return to Main Menu in five Seconds");
        yield return new WaitForSecondsRealtime(5);
        this.OnClickMainMenu();
    }
}
