using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectBaseInteractionController : MonoBehaviour
{
    protected MovementController movementController;

    private void Awake()
    {
        this.movementController = this.gameObject.GetComponentInParent<MovementController>();
        if (this.movementController is null)
            throw new MissingComponentException();
    }

    protected virtual GoblinMovementController GetGoblinScript(Collider2D collider = null, Collision2D collision = null)
    {
        GameObject goblin = null;
        if (collider is not null)
            goblin = collider.gameObject;
        else if (collision is not null)
            goblin = collision.gameObject;
        if (goblin is null)
            return null;

        // Return if not Goblin
        if (goblin.layer != 3)
            return null;

        GoblinMovementController goblinMovementController = goblin.GetComponent<GoblinMovementController>();
        if (goblinMovementController is null)
            throw new MissingComponentException();

        return goblinMovementController;
    }
}
