using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance;

    [SerializeField] int ammoCount;
    [SerializeField] Text ammoText;

    private void Awake()
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

    public bool ConsumeAmmo()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            UpdateAmmoUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateAmmoUI()
    {
        ammoText.text = "Ammo: " + ammoCount;
    }
}
