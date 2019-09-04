using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI typeText;
    [SerializeField] TextMeshProUGUI amountText;

    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void UpdateAmmoType(Gun gun)
    {
        if (gun == null)
        {
            canvasGroup.alpha = 0;
            return;
        }

        canvasGroup.alpha = 1;

        UpdateAmmoCount(AmmoManager.instance.GetAmmo(gun.ammoType));
        typeText.text = gun.ammoType.ToString();
    }

    public void UpdateAmmoCount(int amount)
    {
        amountText.text = amount.ToString();
    }
}
