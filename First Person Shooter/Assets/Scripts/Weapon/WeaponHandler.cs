using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler instance;

    Gun currentGun;
    GameObject currentGunPrefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void PickUpGun(Gun gun)
    {
        if (currentGun != null)
        {
            Instantiate(currentGun.pickup, transform.position + transform.forward, Quaternion.identity);
            Destroy(currentGunPrefab);
        }
        currentGun = gun;
        currentGunPrefab = Instantiate(gun.gameObject, transform);

        AmmoManager.instance.ammoUI.UpdateAmmoType(currentGun);
    }
}
