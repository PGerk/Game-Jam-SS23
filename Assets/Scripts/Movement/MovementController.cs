using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private bool invertXMovementOnTriggerEnter;
    [SerializeField] private bool invertYMovementOnTriggerEnter;
    [SerializeField] private bool startMovementOnTriggerEnter;
    [SerializeField] private bool stopMovementOnTriggerEnter;
    [SerializeField] private Vector2 newMovementDirectionOnTriggerEnter;
    
    
    [SerializeField] private bool invertXMovementOnCollisionEnter;
    [SerializeField] private bool invertYMovementOnCollisionEnter;
    [SerializeField] private bool startMovementOnCollisionEnter;
    [SerializeField] private bool stopMovementOnCollisionEnter;
    [SerializeField] private Vector2 newMovementDirectionOnCollisionEnter;


    public virtual void OnTrigger(GoblinMovementController goblin)
    {
        // Toggle Movement
        if (this.startMovementOnTriggerEnter)
            goblin.IsMoving = true;
        if (this.stopMovementOnTriggerEnter)
            goblin.IsMoving = false;

        // Invert Movement
        Vector2 newMoveVector = goblin.MovementDirection;
        if (this.invertXMovementOnTriggerEnter)
            newMoveVector.x = newMoveVector.x * -1;
        if (this.invertYMovementOnTriggerEnter)
            newMoveVector.y = newMoveVector.y * -1;
        goblin.MovementDirection = newMoveVector;

        // New MovementDirection
        if (this.newMovementDirectionOnTriggerEnter != Vector2.zero)
            goblin.MovementDirection = this.newMovementDirectionOnTriggerEnter;
    }

    public virtual void OnCollision(GoblinMovementController goblin)
    {
        // Toggle Movement
        if (this.startMovementOnCollisionEnter)
            goblin.IsMoving = true;
        if (this.stopMovementOnCollisionEnter)
            goblin.IsMoving = false;

        // Invert Movement
        Vector2 newMoveVector = goblin.MovementDirection;
        if (this.invertXMovementOnCollisionEnter)
            newMoveVector.x = newMoveVector.x * -1;
        if (this.invertYMovementOnCollisionEnter)
            newMoveVector.y = newMoveVector.y * -1;
        goblin.MovementDirection = newMoveVector;

        // New MovementDirection
        if (this.newMovementDirectionOnCollisionEnter != Vector2.zero)
            goblin.MovementDirection = this.newMovementDirectionOnCollisionEnter;
    }
}
