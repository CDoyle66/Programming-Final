using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
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
}
