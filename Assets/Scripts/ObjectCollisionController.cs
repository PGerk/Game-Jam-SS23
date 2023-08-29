using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionController : ObjectBaseInteractionController
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GoblinMovementController goblinMovementController = this.GetGoblinScript(collision: collision);
        if (goblinMovementController is null)
            return;

        this.movementController.OnCollision(goblinMovementController);
    }
}
