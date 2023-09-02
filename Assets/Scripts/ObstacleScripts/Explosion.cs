using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IAction
{
    [SerializeField] float explosionRadius, explosionForce;

    public void AddExplosionForce(Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        Vector2 explosionDir = rb.position - explosionPosition;
        float explosionDistance = explosionDir.magnitude;

        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else
        {
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider obj in colliders)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                AddExplosionForce(rb, explosionForce, transform.position, explosionRadius);
            }
        }
    }

    public void Action()
    {
        Explode();
    }

}
