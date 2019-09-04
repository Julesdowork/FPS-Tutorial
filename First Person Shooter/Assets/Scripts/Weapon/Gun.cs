using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public string gunName;
    public GameObject pickup;

    [Header("Stats")]
    public float minDamage;
    public float maxDamage;
    public float maxRange;
    public float fireRate;      // shots per second (e.g.: 1 every sec)
    public AmmoType ammoType;

    protected float timeOfLastShot;

    Transform camTransform;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    protected void Fire()
    {
        if (AmmoManager.instance.ConsumeAmmo(ammoType))
        {
            RaycastHit hit;
            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, maxRange))
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    float distTravelled = hit.distance / maxRange;
                    if (distTravelled <= 1f)
                    {
                        damageable.DealDamage(Mathf.Lerp(maxDamage, minDamage, distTravelled));
                    }
                }
            }
        }
    }
}
