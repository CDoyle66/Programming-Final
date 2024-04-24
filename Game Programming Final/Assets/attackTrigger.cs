using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    public GameObject zombie;
    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            zombie.GetComponent<Zombie>().Attack();
            StartCoroutine(AttackCoolDown());
        }
    }

    private IEnumerator AttackCoolDown() 
    {
        collider.enabled = false;
        yield return new WaitForSeconds(2.0f);
        collider.enabled = true;
    }
}
