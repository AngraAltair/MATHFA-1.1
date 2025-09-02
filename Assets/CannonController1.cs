using UnityEngine;

public class CannonController1 : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float launchAcceleration = 10f;
    public float initialVelocity = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float time = 1f;
            Vector3 launchForce = (0.5f * launchAcceleration * time * time + initialVelocity * time) * projectileSpawnPoint.forward;

            Debug.Log("Launching the projectile with force: " + launchForce);

            rb.AddForce(launchForce, ForceMode.Impulse);
        }
    }
}
