using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePart : MonoBehaviour
{
    private Mesh mesh;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<Mesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rifle bullet")
        {
            zombie.GetComponent<Zombie>().TakeRifleDamage();
            Destroy(collision.gameObject); //destroy bullet upon contact
        }
        else if (collision.gameObject.tag == "Pistol bullet")
        {
            zombie.GetComponent<Zombie>().TakePistolDamage();
            Destroy(collision.gameObject); //destroy bullet upon contact
        }
    }
}
