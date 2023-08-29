using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTriggerController : ObjectBaseInteractionController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoblinMovementController goblinMovementController = this.GetGoblinScript(collider: collision);
        if (goblinMovementController is null )
            return;

        this.movementController.OnTrigger(goblinMovementController);

    }
}
