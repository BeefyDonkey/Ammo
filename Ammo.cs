using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
        public int ammoInMagazine;
    }

    public void ReloadGun(AmmoType ammoType, int ammoInMagazine)
    {
        var weapon = GetAmmoSlot(ammoType);

        if (weapon.ammoAmount < ammoInMagazine)
        {
            weapon.ammoInMagazine = weapon.ammoAmount;
            weapon.ammoAmount -= weapon.ammoAmount;
        }
        else
        {
            weapon.ammoAmount -= ammoInMagazine;
            weapon.ammoInMagazine = ammoInMagazine;
        }        
    }

    public void IncreaseAmmo(AmmoType ammoType, int increaseAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += increaseAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoInMagazine--;
    }

    public int GetAmmoInMagazine(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoInMagazine;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
