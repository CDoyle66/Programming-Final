using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int spawnNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnZombie()
    {
        StartCoroutine(ZombieSpawnDelay());
    }

    public IEnumerator ZombieSpawnDelay()
    {
        for (int i = 0; i < spawnNumber; i++) 
        {
            GameObject zombieClone = Instantiate(zombiePrefab);
            RoundManager.S.zombieList.Add(zombieClone); //add this zombie clone to the list of zombies in the scene
            yield return new WaitForSeconds(5.0f); //spawn a new zombie every x seconds
        }
    }
}
