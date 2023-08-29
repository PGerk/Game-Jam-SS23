using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovementController : MonoBehaviour
{
    public bool IsMoving = false;
    public Vector2 MovementDirection = Vector2.zero;
    public float MovementSpeed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
            this.gameObject.transform.Translate(Time.deltaTime * this.MovementSpeed * this.MovementDirection);
    }
}
