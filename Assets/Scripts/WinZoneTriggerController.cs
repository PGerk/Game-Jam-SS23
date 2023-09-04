using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneTriggerController : MovementController
{
    private LevelController m_LevelController;
    private void Awake()
    {
        m_LevelController = FindObjectOfType<LevelController>();
    }

    public override void OnTrigger(GoblinMovementController goblin)
    {
        goblin.StopWalking();
        m_LevelController.SurvivedGoblins++;
        m_LevelController.AliveGoblins--;
    }
}
