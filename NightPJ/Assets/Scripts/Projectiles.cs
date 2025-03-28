using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            Debug.Log($"Hit enemy: {other.name}");
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null && damage > 0)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject); 
        }
        else if (other.CompareTag("Player")) 
        {
            Debug.Log($"Hit player: {other.name}");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null && damage > 0)
            {
                playerHealth.TakeDamage(damage); 
            }

            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) 
        {
            Destroy(gameObject); 
        }
    }
}