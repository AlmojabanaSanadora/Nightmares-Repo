using UnityEngine;

public class Hachas : MonoBehaviour
{
    public float speed = 2f;
    public float angle = 45f;

    private Quaternion startRotation; 
    private float time;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        time += Time.deltaTime * speed;

        float pendulumAngle = Mathf.Sin(time) * angle;

        transform.rotation = startRotation * Quaternion.Euler(0, 0, pendulumAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player hit by Hachas!");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); 
            }
        }
    }
}