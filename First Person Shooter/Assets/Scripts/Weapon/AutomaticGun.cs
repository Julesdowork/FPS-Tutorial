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

    public override void OnLeftMouseHold(Transform cameraPos)
    {
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
            Fire(cameraPos);
        }
    }
}
