using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private int _upgradeLevel = 0;
    public Bullet[] WeaponUpgrades;

    public int UpgradeLevel
    {
        get { return _upgradeLevel; }

        set
        {
            _upgradeLevel = value;
            UpdateWeaponPrefab();
        }
    }
    
    private void UpdateWeaponPrefab()
    {
        Shooting shootingComp = gameObject.GetComponent<Shooting>();
        if (shootingComp != null)
        {
            shootingComp.bulletPrefab = WeaponUpgrades[_upgradeLevel - 1];
        }
    }
}
