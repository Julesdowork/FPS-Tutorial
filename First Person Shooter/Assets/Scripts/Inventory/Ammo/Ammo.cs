using UnityEngine;

public class Ammo : MonoBehaviour, ILootable
{
    [SerializeField] int amount;
    [SerializeField] AmmoType type;

    public void OnLook()
    {
        Debug.Log($"Started looking at {type}");
    }

    public void OnInteract()
    {
        Debug.Log($"Picked up {amount} rounds of {type} ammo!");
    }

    public void OnLookAway()
    {
        Debug.Log($"Stopped looking at {type}");
    }
}
