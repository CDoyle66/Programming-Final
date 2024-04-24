using System.Collections;
using System.Collections.Generic;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class attacker : MonoBehaviour
{
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
            other.gameObject.GetComponent<Character>().health -= 10;
            Debug.Log("take damage");
        }
    }
}
