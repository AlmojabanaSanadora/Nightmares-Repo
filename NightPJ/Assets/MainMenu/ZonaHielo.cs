using UnityEngine;

public class ZonaHielo : MonoBehaviour
{
    public PhysicsMaterial friccionHielo; // Assign this in the Inspector
    public PhysicsMaterial friccionNormal; // Assign the normal friction material in the Inspector

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Collider playerCollider = other.GetComponent<Collider>();
        if (playerCollider != null)
        {
            playerCollider.material = friccionHielo;
            Debug.Log("Applied Ice Friction");
        }
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Collider playerCollider = other.GetComponent<Collider>();
        if (playerCollider != null)
        {
            playerCollider.material = friccionNormal;
            Debug.Log("Restored Normal Friction");
        }
    }
}
}