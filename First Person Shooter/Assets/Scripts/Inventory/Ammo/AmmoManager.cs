using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance;

    [SerializeField] Text ammoText;
    Dictionary<AmmoType, int> ammoAmounts = new Dictionary<AmmoType, int>();

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

    void Start()
    {
        for (int i = 0; i < Enum.GetNames(typeof(AmmoType)).Length; i++)
        {
            ammoAmounts.Add((AmmoType)i, 0);
        }
    }

    public bool ConsumeAmmo(AmmoType aType)
    {
        if (ammoAmounts[aType] > 0)
        {
            ammoAmounts[aType]--;
            UpdateAmmoUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddAmmo(int value, AmmoType aType)
    {
        ammoAmounts[aType] += value;
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        //ammoText.text = "Ammo: " + ammoCount;
    }
}
