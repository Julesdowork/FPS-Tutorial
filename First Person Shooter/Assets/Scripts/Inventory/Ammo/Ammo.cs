using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] AmmoType type;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerMovement>() != null)
        {
            AmmoManager.instance.AddAmmo(amount, type);
            Destroy(gameObject);
        }
    }
}
