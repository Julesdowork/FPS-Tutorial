using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, ILootable
{
    [SerializeField] Gun gun;

    public void OnLook()
    {
        Debug.Log($"Started looking at {gun.gunName}");
    }

    public void OnInteract()
    {
        Debug.Log($"Trying to pick up {gun.gunName}");
    }

    public void OnLookAway()
    {
        Debug.Log($"Stopped looking at {gun.gunName}");
    }
}
