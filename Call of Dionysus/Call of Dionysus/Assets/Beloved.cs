using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beloved : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;
    public GameObject fireballObject;
    public Transform minimumY;
    private float rate = 5;
    private float spawnTimer = 0;
    private float speed = .15f;
    private float damage = 10;
    private int columns = 8;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getHero().transform.position.y > minimumY.position.y)
        {
            if (!gameManager.isPaused())
            {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0)
                {
                    GameObject fireball;
                    Transform ts = GetComponent<Transform>();
                    fireball = Instantiate(fireballObject, ts.position, ts.rotation) as GameObject;
                    fireball.GetComponent<Fireball>().gameManager = this.gameManager;
                    fireball.GetComponent<Fireball>().beloved = this.gameObject;
                    fireball.GetComponent<Fireball>().damage = damage;
                    fireball.GetComponent<Fireball>().speed = speed;
                    spawnTimer = rate;
                }
            }

            if (gameManager.numColumns < columns)
            {
                speed *= 1.5f;
                damage *= 1.5f;
                columns--;

                if (columns < 4)
                {
                    rate /= 2;
                }
            }
        }
    }
}
