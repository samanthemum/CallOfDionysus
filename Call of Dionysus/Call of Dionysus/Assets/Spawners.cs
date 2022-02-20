using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    public GameObject enemyObject;
    public int numberToSpawn;
    // might want to add a limit later
    public float rate;
    float spawnTimer;
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        spawnTimer = rate;

        if(gameManager == null)
        {
            Debug.Log("Manager set FAILED");
        } else
        {
            Debug.Log("Manager set successful");
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            for(int i = 0; i < numberToSpawn; i++)
            {
                Transform ts = GetComponent<Transform>();
                GameObject enemy = Instantiate(enemyObject, ts.position, ts.rotation);
                // TODO- wanna make edits to enemy states
                // based on level
                EnemyScript es = enemy.GetComponent<EnemyScript>();
                es.setGameManger(gameManager);
            }
            spawnTimer = rate;
        }
    }
}