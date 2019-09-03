using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] AmmoType type;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerMovement>() != null)
        {
            AmmoManager.instance.AddAmmo(amount, AmmoType.LIGHT);   // TODO change this to type
            AmmoManager.instance.AddAmmo(5, AmmoType.HEAVY);    // TODO delete this and make a unique prefab for different types of ammo
            Destroy(gameObject);
        }
    }
}
