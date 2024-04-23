using System.Collections;
using System.Collections.Generic;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class RifleAmmoPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isRifleAmmo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Weapon[] weapons = other.gameObject.GetComponentsInChildren<Weapon>();
            foreach(Weapon weapon in weapons)
            {
                if(weapon.IsAutomatic() && isRifleAmmo)
                {
                    weapon.AddReserveAmmunition();
                }
                else if (!weapon.IsAutomatic() && !isRifleAmmo)
                {
                    weapon.AddReserveAmmunition();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
