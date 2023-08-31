using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTriggerController : GoblinMovementController
{
    private SpawnMaster spawnMaster;

    private void Awake()
    {
        this.spawnMaster = FindObjectOfType<SpawnMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         //GoblinMovementController controller = 
    }
}
