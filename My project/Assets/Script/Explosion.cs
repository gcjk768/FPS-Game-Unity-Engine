using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // enforces dependency
public class Explosion : MonoBehaviour
{
    // radius and power of the explosion
    public float radius = 5.0f;
    public float power = 10.0f;

    // Bounce properties
    public int bounceCount = 3;  // set to desired number of bounces
    private int currentBounce = 0;

    // Delayed explosion after last bounce
    public float explosionDelay = 10.0f;

    // Explosion scene before the final explosion (e.g., visual particle effect, sound)
    public GameObject explosionScenePrefab;

    // if the object collides with anything
    private void OnCollisionEnter(Collision collision)
    {
        currentBounce++;  // increment the bounce count

        // If the grenade has reached its bounce limit
        if (currentBounce >= bounceCount)
        {
            // Delay the explosion by explosionDelay seconds
            Invoke("ExecuteExplosion", explosionDelay);
        }
    }

    private void ExecuteExplosion()
    {
        // If you want an explosion effect scene before the explosion logic
        if (explosionScenePrefab != null)
        {
            Instantiate(explosionScenePrefab, transform.position, Quaternion.identity);
        }

        // proceed with the explosion logic
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            Shootable st = hit.GetComponent<Shootable>();
            if (rb != null && st != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Impulse);
                st.SetRandomColour();
            }
        }

        Destroy(gameObject);  // remove the explosive game object
    }
}
