using System.Collections;
using System.Collections.Generic;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class RifleAmmoPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isRifleAmmo;
    private MeshRenderer renderer;
    private BoxCollider collider;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WeaponBehaviour[] weapons = other.gameObject.GetComponentInChildren<Inventory>().weapons;
            foreach(WeaponBehaviour weapon in weapons)
            {
                Weapon weaponStats = weapon.GetComponent<Weapon>();
                if(weaponStats.IsAutomatic() && isRifleAmmo)
                {
                    weaponStats.AddReserveAmmunition();
                }
                else if (!weapon.IsAutomatic() && !isRifleAmmo)
                {
                    weaponStats.AddReserveAmmunition();
                }
            }
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn() //Respawn ammo after set amount of seconds
    {
        //make pickup disappear
        renderer.enabled = false; 
        collider.enabled = false;
        yield return new WaitForSeconds(40.0f);
        //make pickup reappear
        renderer.enabled = true;
        collider.enabled = true;
    }
}
