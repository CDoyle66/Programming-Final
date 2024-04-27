using System.Collections;
using System.Collections.Generic;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class attacker : MonoBehaviour
{
    public int attackDamage;

    public AudioSource audioSource; //audio source of the zombie
    public AudioClip damage; //sound of zombie hitting player
    // Start is called before the first frame update
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
            audioSource.PlayOneShot(damage);
            other.gameObject.GetComponent<Character>().health -= attackDamage;
            other.gameObject.GetComponent<Character>().UpdateHealth(); //update player health
        }
    }
}
