using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    private Animator animator;
    private Collider[] colliders;

    private AudioSource audioSource;
    public AudioClip footsteps;

    public int health; //Health of the zombie

    //Damage done to the zombie by weapons
    public int rifleDamage; 
    public int pistolDamage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(UpdateTarget());
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.speed); //Update the animator to tell it how fast the zombie is moving
    }

    private IEnumerator UpdateTarget()
    {
        while (true) {
            audioSource.PlayOneShot(footsteps);
            agent.destination = player.position;
            yield return new WaitForSeconds(1.0f);
        }
    }

    //Damage
    public void TakeRifleDamage()
    {
        if (health > rifleDamage) { // if the enemy has more health than the bullet does damage
            health -= rifleDamage; //take health damage
            Debug.Log(health);
        }
        else
        {
            Death();
        }
    }
    public void TakeRifleHeadshotDamage()
    {
        if (health > rifleDamage*2)
        { 
            health -= rifleDamage*2; //Headshots do double damage
            Debug.Log(health);
        }
        else
        {
            Death();
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
            Death();
        }
    }
    public void TakePistolHeadshotDamage()
    {
        if (health > pistolDamage*2)
        { // if the enemy has more health than the bullet does damage
            health -= pistolDamage*2; //take health damage
            Debug.Log(health);
        }
        else
        {
            Death();
        }
    }



    public void Attack() //Zombie attacks the player
    {
        agent.speed = 0.2f; //Make the zombie move slower during its attack anim
        animator.SetTrigger("Attack");
    }

    public void ResetArm() 
    {
        agent.speed = 1.5f; //Return zombie to normal movement speed after attacking
    }

    private void Death()
    {
        //enemy dies
        Debug.Log("enemy dies");
        RoundManager.S.zombiesKilled++; //increase player killcount
        RoundManager.S.UpdateZombieList();

        animator.SetTrigger("Death"); //death anim trigger
        agent.enabled = false; //stop movement
        RoundManager.S.zombieList.Remove(this.gameObject); //remove this zombie from the list of active zombies in the scene
        RoundManager.S.RoundOver(); //Check to see if this is the last zombie in the round to die, therefore triggering the next round
        StartCoroutine(DeathFade()); //start death fade
    }
    private IEnumerator DeathFade() //Remove dead zombie model after a few seconds of being killed
    {
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false; //stop collisions with zombie model
        }
        gameObject.layer = 7; //stop collisions with zombie model
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
