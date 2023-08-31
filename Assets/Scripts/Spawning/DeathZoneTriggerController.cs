using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTriggerController : MovementController
{
    private SpawnMaster spawnMaster;

    private void Awake()
    {
        this.spawnMaster = FindObjectOfType<SpawnMaster>();
    }

    public override void OnTrigger(GoblinMovementController goblin)
    {
        goblin.StopWalking();
        this.spawnMaster.KillGoblin(goblin.gameObject);
    }
}
