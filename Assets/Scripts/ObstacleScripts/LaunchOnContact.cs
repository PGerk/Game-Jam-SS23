using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOnContact : MonoBehaviour
{
    [Tooltip("The amount of Force the Object is launched with")]
    [SerializeField] float force;
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
        Rigidbody2D collidedObject = collision.gameObject.GetComponent<Rigidbody2D>();
        float x = collision.transform.position.x - transform.position.x;
        float y = collision.transform.position.y - transform.position.y;
        collidedObject.AddForce(new Vector2(x*force, y*force), ForceMode2D.Impulse);
    }
}
