using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private bool turnAroundOnTriggerEnter;
    [SerializeField] private bool startMovementOnTriggerEnter;
    [SerializeField] private bool stopMovementOnTriggerEnter;
    [SerializeField] private Vector2 newMovementDirectionOnTriggerEnter;
    
    
    [SerializeField] private bool turnAroundOnCollisionEnter;
    [SerializeField] private bool startMovementOnCollisionEnter;
    [SerializeField] private bool stopMovementOnCollisionEnter;
    [SerializeField] private Vector2 newMovementDirectionOnCollisionEnter;


    public virtual void OnTrigger(GoblinMovementController goblin)
    {
        // Toggle Movement
        if (this.startMovementOnTriggerEnter)
            goblin.StartWalking();
        if (this.stopMovementOnTriggerEnter)
            goblin.StopWalking();

        // Invert Movement
        if (this.turnAroundOnTriggerEnter)
            goblin.TurnAround();

        // New MovementDirection
        if (this.newMovementDirectionOnTriggerEnter != Vector2.zero)
            goblin.MovementDirection = this.newMovementDirectionOnTriggerEnter;
    }

    public virtual void OnCollision(GoblinMovementController goblin)
    {
        // Toggle Movement
        if (this.startMovementOnCollisionEnter)
            goblin.StartWalking();
        if (this.stopMovementOnCollisionEnter)
            goblin.StopWalking();

        // Invert Movement
        if (this.turnAroundOnCollisionEnter)
            goblin.TurnAround();
         
        // New MovementDirection
        if (this.newMovementDirectionOnCollisionEnter != Vector2.zero)
            goblin.MovementDirection = this.newMovementDirectionOnCollisionEnter;
    }
}
