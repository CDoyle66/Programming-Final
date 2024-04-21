using System.Collections;
using System.Collections.Generic;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class RifleAmmoPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rifle;
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
            rifle.GetComponent<Weapon>().AddReserveAmmunition();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);
    }
}
