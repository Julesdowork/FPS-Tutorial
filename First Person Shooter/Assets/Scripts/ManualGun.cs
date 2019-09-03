using UnityEngine;

[CreateAssetMenu(fileName = "Manual Gun", menuName = "Guns/Manual Gun")]
public class ManualGun : Gun
{
    public override void OnMouseDown(Transform cameraPos)
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraPos.position, cameraPos.forward, out hit, base.maxRange))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                float distTravelled = hit.distance / base.maxRange;
                if (distTravelled <= 1f)
                {
                    damageable.DealDamage(Mathf.Lerp(base.maxDamage, base.minDamage, distTravelled));
                }
            }
        }
    }
}
