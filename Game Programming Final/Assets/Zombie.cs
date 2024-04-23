using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public int maxHealth;
    public int health;

    public int rifleDamage;
    public int pistolDamage;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdateTarget());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator UpdateTarget()
    {
        while (true)
        {
            agent.destination = player.position;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void TakeRifleDamage()
    {
        if (health > rifleDamage) { // if the enemy has more health than the bullet does damage
            health -= rifleDamage; //take health damage
            Debug.Log(health);
        }
        else
        {
            //enemy dies
            Debug.Log("enemy dies");
        }
    }
    public void TakePistolDamage()
    {
        if (health > pistolDamage)
        { // if the enemy has more health than the bullet does damage
            health -= pistolDamage; //take health damage
            Debug.Log(health);
        }
        else
        {
            //enemy dies
            Debug.Log("enemy dies");
        }
    }
}
