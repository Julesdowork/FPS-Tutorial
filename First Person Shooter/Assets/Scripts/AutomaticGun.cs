using UnityEngine;

[CreateAssetMenu(fileName = "Automatic Gun", menuName = "Guns/Automatic")]
public class AutomaticGun : Gun
{
    public float fireRate;
    float lastTimeFired;

    void OnEnable()
    {
        // Initialize variable when gun game object becomes enabled, otherwise lastTimeFired will be
        // 51 secs from the start
        lastTimeFired = 0;
    }

    public override void OnMouseHold(Transform cameraPos)
    {
        Debug.Log("Time: " + Time.time + ", Last Time Fired: " + lastTimeFired);
        Debug.Log("Time difference: " + (Time.time - lastTimeFired));
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
            Debug.Log("Shooting");
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
        else
        {
            Debug.Log("Can't fire yet");
        }
    }
}
