using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public GameObject prefab;

    [Header("Stats")]
    public float minDamage;
    public float maxDamage;
    public float maxRange;

    public virtual void OnLeftMouseDown(Transform cameraPos) {}
    public virtual void OnLeftMouseHold(Transform cameraPos) {}
    public virtual void OnRightMouseDown() {}

    protected void Fire(Transform cameraPos)
    {
        if (AmmoManager.instance.ConsumeAmmo())
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraPos.position, cameraPos.forward, out hit, maxRange))
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
