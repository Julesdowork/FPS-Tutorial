using UnityEngine;

[CreateAssetMenu(fileName = "Semi-Automatic Gun", menuName = "Guns/Semi-Automatic Gun")]
public class SemiAutoGun : Gun
{
    public override void OnLeftMouseDown(Transform cameraPos)
    {
        Fire(cameraPos);
    }
}
