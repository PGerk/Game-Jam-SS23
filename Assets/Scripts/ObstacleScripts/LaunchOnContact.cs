using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOnContact : MonoBehaviour
{
    [Tooltip("The amount of Force the Object is launched with")]
    [SerializeField] float force;

    [SerializeField] bool onlyLaunchGoblins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer != 3 && onlyLaunchGoblins)
        {
            return;
        }
        else
        {
            Rigidbody2D collidedObject = collision.gameObject.GetComponent<Rigidbody2D>();

            if (collidedObject != null)
            {
                float x = collision.transform.position.x - transform.position.x;
                float y = collision.transform.position.y - transform.position.y;
                collidedObject.AddForce(new Vector2(x * force, y * force), ForceMode2D.Impulse);
            }
        }
        
    }
}
