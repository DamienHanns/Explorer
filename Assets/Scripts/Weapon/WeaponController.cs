using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    [SerializeField] Transform weaponPlacement;
    [SerializeField] Weapon startingWeapon;
    Weapon currentWeapon;

    private void Start()
    {
        if (startingWeapon != null) { EquipWeapon(startingWeapon); }
    }

    public void UseWeapon()
    {
        currentWeapon.UseWeapon();
    }

    void EquipWeapon(Weapon weaponToequip)
    {
        if (currentWeapon != null) { Destroy(currentWeapon.gameObject); }

        currentWeapon = Instantiate(weaponToequip, weaponPlacement.position, weaponPlacement.rotation);
        currentWeapon.transform.parent = weaponPlacement;
    }
}
