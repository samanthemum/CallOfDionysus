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
    public float minDamage = 10;
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
        if (!gameManager.isPaused())
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                GameObject enemy;
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Transform ts = GetComponent<Transform>();
                    enemy = Instantiate(enemyObject, ts.position, ts.rotation) as GameObject;
                    // TODO- wanna make edits to enemy states
                    // based on level
                    enemy.GetComponent<EnemyScript>().setGameManger(gameManager);
                    enemy.GetComponent<EnemyScript>().damage = (Random.value * 10) + minDamage;
                }
                spawnTimer = rate;
            }
        }
    }
}
