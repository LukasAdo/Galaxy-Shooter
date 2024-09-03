using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject Enemy_Container;

    [SerializeField]
    private GameObject[] powerUps;

    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUp());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    IEnumerator SpawnPowerUp()
    {
        int spawnTime = Random.Range(7,11);
        while (stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9.41f, 9.46f), 7, 0);
            int randomrange = Random.Range(0, 3);
            Instantiate(powerUps[randomrange], spawnPos, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnTime);
        }

    }
    IEnumerator SpawnRoutine()
    {
        int spawnTime = 5;
        while (stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9.41f, 9.46f), 7, 0);
            GameObject newEnemy =  Instantiate(Enemy,spawnPos, Quaternion.identity);
            newEnemy.transform.parent = Enemy_Container.transform;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void OnDeath()
    {
        stopSpawning = true;
    }
}
