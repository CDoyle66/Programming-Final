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
