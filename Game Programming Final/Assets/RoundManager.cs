using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int round;
    private GameObject roundUI;
    private TextMeshProUGUI roundUINum;

    public int zombiesKilled = 0;
    public int zombiesKilledRound; //The number of zombies the player needs to have killed for the round to end.
    private GameObject zombieUI;
    private TextMeshProUGUI zombieUINum;

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
        roundUI = GameObject.Find("Round num");
        roundUINum = roundUI.GetComponent<TextMeshProUGUI>();

        zombieUI = GameObject.Find("Zombie num");
        zombieUINum = zombieUI.GetComponent<TextMeshProUGUI>(); 
        zombiesKilled = 0;
        zombieUINum.text = zombiesKilled.ToString();

        round = 1;
        roundUINum.text = round.ToString();

        zomRoundNum = 12;
        zombiesKilledRound = 12;
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
        if (zombiesKilled == zombiesKilledRound) //If all the zombies are dead
        {
            round++; //increase round number
            roundUINum.text = round.ToString();
            zomRoundNum += 12; //increase the number of zombies in the next round by 12
            zombiesKilledRound += zomRoundNum; //set kill threshold for next round
            foreach (GameObject zombieSpawner in zombieSpawners)
            {
                zombieSpawner.GetComponent<ZombieSpawner>().spawnNumber = zomRoundNum / 4; //each of the four zombie spawners spawn an equal number of enemies
            }
            StartCoroutine(RoundDelay());
        }
    }

    public IEnumerator RoundDelay()
    {
        yield return new WaitForSeconds(4.0f); //give player a 4 second break between rounds
        foreach (GameObject zombieSpawner in zombieSpawners)
        {
            zombieSpawner.GetComponent<ZombieSpawner>().SpawnZombie(); //start spawning zombies
        }
    }
    
    public void UpdateZombieList()
    {
        zombieUINum.text = zombiesKilled.ToString();
    }
}
