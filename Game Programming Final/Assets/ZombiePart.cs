using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePart : MonoBehaviour
{
    private Mesh mesh;
    public GameObject zombie;
    public bool isHead;
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
            if (isHead)
            {
                zombie.GetComponent<Zombie>().TakeRifleHeadshotDamage();
                Destroy(collision.gameObject); //destroy bullet upon contact
            }
            else
            {
                zombie.GetComponent<Zombie>().TakeRifleDamage();
                Destroy(collision.gameObject); //destroy bullet upon contact
            }
        }
        else if (collision.gameObject.tag == "Pistol bullet")
        {
            if (isHead)
            {
                zombie.GetComponent<Zombie>().TakePistolHeadshotDamage();
                Destroy(collision.gameObject); //destroy bullet upon contact
            }
            else
            {
                zombie.GetComponent<Zombie>().TakePistolDamage();
                Destroy(collision.gameObject); //destroy bullet upon contact
            }
        }
    }
}
