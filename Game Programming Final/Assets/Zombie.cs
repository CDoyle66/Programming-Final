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
    public int health;
    private Collider[] colliders;

    public int rifleDamage;
    public int pistolDamage;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(UpdateTarget());
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.speed);
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
            animator.SetTrigger("Death");
            agent.enabled = false;
            StartCoroutine(DeathFade());
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
            animator.SetTrigger("Death"); //death anim trigger
            agent.enabled = false; //stop movement
            StartCoroutine(DeathFade()); //start death fade
        }
    }

    public void Attack()
    {
        agent.speed = 0.2f;
        animator.SetTrigger("Attack");
    }

    public void ResetArm()
    {
        agent.speed = 1.5f;
    }

    private IEnumerator DeathFade()
    {
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        gameObject.layer = 7; //stop collisions
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
