using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject fracturedPrefab;
    public float explosionForce = 200f;
    public float explosionRadius = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet")) return;

        // Spawn fractured version
        GameObject broken = Instantiate(fracturedPrefab, transform.position, transform.rotation);

        // Slightly above the center to reduce downward force
        Vector3 explosionOrigin = transform.position + Vector3.up * 0.5f;

        foreach (Rigidbody rb in broken.GetComponentsInChildren<Rigidbody>())
        {
            rb.linearDamping = 1.5f; // slows downward fall
            rb.AddExplosionForce(explosionForce, explosionOrigin, explosionRadius);
        }

        Destroy(other.gameObject); // remove bullet
        Destroy(gameObject);       // remove original object
    }
}
