using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSmallCannonball : MonoBehaviour, IAction
{
    public GameObject smallCannonball;
    private GameObject shot;
    public float x, y, force;
    public Animator animator;

    public GameObject Fire()
    {
        Vector2 offset = new Vector2(transform.position.x - 0.8f, transform.position.y+1f);
        GameObject cannonball = Instantiate(smallCannonball, offset, Quaternion.identity);
        
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        
        Vector2 direction = new Vector2(x * force, y*force);
        rb.AddForce(direction, ForceMode2D.Impulse);

        animator.Play("Attack");
        
        return cannonball;
    }

    public void Action()
    {
        Fire();
    }
}
