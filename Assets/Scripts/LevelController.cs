using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int GoblinsNeedToSurvive = 1;
    [SerializeField] int GoblinsTotalInLevel = 50;
    public int DiedGoblins = 0;
    public int SurvivedGoblins = 0;
    public int AliveGoblins = 0;
    private bool gameEnded = false;
    private EndOfLevelController endOfLevelController;

    private void Awake()
    {
        this.endOfLevelController = FindObjectOfType<EndOfLevelController>(true);
        if (this.endOfLevelController is null)
            throw new ArgumentException("endofLevelController is missing");
    }

    private void Update()
    {
        if (SurvivedGoblins >= GoblinsNeedToSurvive && !gameEnded)
        {
            this.OnWin();
            gameEnded = true;
            return;
        }
        if ((GoblinsTotalInLevel - DiedGoblins) < GoblinsNeedToSurvive && !gameEnded)
        {
            this.OnDeath();
            gameEnded = true;
            return;
        }
    }

    public void OnWin()
    {
        Debug.Log("Yeah Win");
        this.endOfLevelController.OnWin();
    }

    public void OnDeath()
    {
        Debug.Log("No You Die");
        this.endOfLevelController.OnLose();
    }

}
