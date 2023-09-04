using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovementController : MonoBehaviour
{
    private bool m_IsMoving = false;
    public Vector2 MovementDirection = Vector2.zero;
    public float MovementSpeed = 1;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsMoving)
            this.gameObject.transform.Translate(Time.deltaTime * this.MovementSpeed * this.MovementDirection);
    }

    public void StartWalking()
    {
        this.m_IsMoving = true;
        m_Animator.SetBool("Walking", true);
    }

    public void StopWalking()
    {
        this.m_IsMoving= false;
        m_Animator.SetBool("Walking", false);
    }

    public void TurnAround()
    {
        Quaternion currentRotation = this.gameObject.transform.rotation;
        currentRotation *= Quaternion.Euler(Vector3.up * 180);
        this.gameObject.transform.rotation = currentRotation;
    }
}
