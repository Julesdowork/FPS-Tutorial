﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] List<Gun> guns = new List<Gun>();
    Gun currentGun;
    GameObject currentGunPrefab;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        currentGunPrefab = Instantiate(guns[0].prefab, transform);
        currentGun = guns[0];
    }

    // Update is called once per frame
    void Update()
    {
        CheckForShooting();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[0].prefab, transform);
            currentGun = guns[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[1].prefab, transform);
            currentGun = guns[1];
        }
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, transform.forward, out hit, currentGun.maxRange))
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.DealDamage(currentGun.maxDamage);
                }
            }
        }
    }
}