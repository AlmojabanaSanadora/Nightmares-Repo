using UnityEngine;

public class ZonaHielo : MonoBehaviour
{
    public PhysicsMaterial friccionHielo; // Asigna esto desde el Inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider playerCollider = collision.gameObject.GetComponent<Collider>();
            if (playerCollider != null)
            {
                playerCollider.material = friccionHielo;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider playerCollider = collision.gameObject.GetComponent<Collider>();
            if (playerCollider != null)
            {
                // Restaurar la fricción normal (puedes cambiar estos valores si quieres)
                PhysicsMaterial friccionNormal = new PhysicsMaterial();
                friccionNormal.dynamicFriction = 0.6f;
                friccionNormal.staticFriction = 0.6f;
                friccionNormal.frictionCombine = PhysicsMaterialCombine.Average;

                playerCollider.material = friccionNormal;
            }
        }
    }
}
