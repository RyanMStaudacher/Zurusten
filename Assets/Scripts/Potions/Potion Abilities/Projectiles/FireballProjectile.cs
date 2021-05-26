using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    [Tooltip("The speed at which the projectile flies.")]
    public float speed = 5.0f;
    [Tooltip("The amount of time in seconds the projectile will fly before being destroyed.")]
    public float destroyDelay = 5.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDelay());
        rb = this.gameObject.GetComponent<Rigidbody>();
        ProjectileMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void ProjectileMovement()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
