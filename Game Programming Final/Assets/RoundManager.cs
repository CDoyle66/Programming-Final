using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int round;
    public int zombiesKilled;
    public GameObject[] zombieSpawners;
    public static RoundManager S;
    public List<GameObject> zombieList = new List<GameObject>();
    private int zomRoundNum; //the number of zombies to be spawned in the round

    private void Awake()
    {
        if (RoundManager.S)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        round = 1;
        zomRoundNum = 12;
        foreach (GameObject zombieSpawner in zombieSpawners)
        {
            zombieSpawner.GetComponent<ZombieSpawner>().spawnNumber = zomRoundNum / 4; //each of the four zombie spawners spawn an equal number of enemies
        }
        StartCoroutine(RoundDelay()); //Start first round
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundOver()
    {
        if (zombieList.Count == 0) //If all the zombies are dead
        {
            round++; //increase round number
        }
        zomRoundNum += 12; //increase the number of zombies in the next round by 12
        foreach (GameObject zombieSpawner in zombieSpawners)
        {
            zombieSpawner.GetComponent<ZombieSpawner>().spawnNumber = zomRoundNum / 4; //each of the four zombie spawners spawn an equal number of enemies
        }
        StartCoroutine(RoundDelay());
    }

    public IEnumerator RoundDelay()
    {
        yield return new WaitForSeconds(4.0f); //give player a 4 second break between rounds
        foreach (GameObject zombieSpawner in zombieSpawners)
        {
            zombieSpawner.GetComponent<ZombieSpawner>().SpawnZombie(); //start spawning zombies
        }
    }
}
