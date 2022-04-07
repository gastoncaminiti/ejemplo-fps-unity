using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        [SerializeField] private AmmoType ammoType;
        public AmmoType AmmoType { get { return ammoType; } set { ammoType = value; } }

        [SerializeField] private int ammoAmount = 10;
        public int AmmoAmount { get { return ammoAmount; } set { ammoAmount = value; } }
    }


    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.AmmoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).AmmoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).AmmoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).AmmoAmount++;
    }
}
