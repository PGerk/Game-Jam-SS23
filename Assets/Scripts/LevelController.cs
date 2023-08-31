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

    private void Update()
    {
        if (SurvivedGoblins >= GoblinsNeedToSurvive)
        {
            this.OnWin();
            return;
        }
        if ((GoblinsTotalInLevel - DiedGoblins) < GoblinsNeedToSurvive)
        {
            this.OnDeath();
            return;
        }
    }

    public void OnWin()
    {
        Debug.Log("Yeah Win");
    }

    public void OnDeath()
    {
        Debug.Log("No You Die");
    }

}
