using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameManager gameManager;
    private HeroScript hero;
    private int hp = 50;
    private int maxHP = 50;
    public float speed;

    public int getHP()
    {
        return hp;
    }

    public int getMaxHP()
    {
        return maxHP;
    }

    public void setHP(int newHp)
    {
        hp = newHp;
    }

    // used for spawners
    public void setGameManger(GameManager gameManager)
    {
        this.gameManager = gameManager;
        if(this.gameManager != null)
        {
            hero = gameManager.getHero();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gameManager = GetComponentInParent<GameManager>();
            if (this.gameManager != null)
            {
                hero = gameManager.getHero();
            }
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(hero != null)
        {
            Rigidbody2D heroRB = hero.GetComponent<Rigidbody2D>();
            float hero_x = heroRB.transform.position.x;
            float hero_y = heroRB.transform.position.y;

            Rigidbody2D enemyRB = GetComponent<Rigidbody2D>();
            float enemy_x = enemyRB.transform.position.x;
            float enemy_y = enemyRB.transform.position.y;

            float distance = Mathf.Sqrt(Mathf.Pow(hero_x - enemy_x, 2.0f) + Mathf.Pow(hero_y - enemy_y,  2.0f));
            float current_speed = speed;
            if(distance < 1)
            {
                current_speed *= 1.5f;
            } 

            Vector2 directionOfHero = (heroRB.transform.position - enemyRB.transform.position).normalized;
            Vector2 newPosition = new Vector2(enemy_x + (speed * directionOfHero.x), enemy_y + (speed * directionOfHero.y));
            enemyRB.MovePosition(newPosition);
        }
    }
}
