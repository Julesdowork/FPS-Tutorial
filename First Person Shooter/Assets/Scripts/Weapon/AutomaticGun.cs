using UnityEngine;

public class AutomaticGun : Gun
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - timeOfLastShot >= 1 / fireRate)
            {
                Fire();
                timeOfLastShot = Time.time;
            }
        }
    }
}
