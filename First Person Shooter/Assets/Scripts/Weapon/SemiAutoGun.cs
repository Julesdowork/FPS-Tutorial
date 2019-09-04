using UnityEngine;

public class SemiAutoGun : Gun
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - timeOfLastShot >= 1 / fireRate)
            {
                Fire();
                timeOfLastShot = Time.time;
            }
        }
    }
}
