using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Seconds before bullet self-destructs")]
    public float lifeTime = 2f;

    [Tooltip("Speed at which the bullet travels (units/sec)")]
    public float speed = 20f;

    void Start()
    {
        // auto-destroy after a short while
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // move forward in local Z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
