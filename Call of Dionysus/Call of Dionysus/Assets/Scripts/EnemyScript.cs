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
    public float damage = 10;
    private bool fight = false;
    private float knockBackTimer = 0f;

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
            Debug.Log("Game manager has been set");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // DONT NOT OVERRIDE IF ALREADY SET OH MY LORD
            if (gameManager == null)
            {
                gameManager = GetComponentInParent<GameManager>();
            }
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
        bool isPaused = false;
        isPaused = gameManager.isPaused();
 

        if(hero != null && !isPaused && !fight)
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

            if (knockBackTimer <= 0)
            {
                enemyRB.MovePosition(newPosition);
                if (knockBackTimer < 0)
                {
                    knockBackTimer = 0;
                }
            } else
            {
                knockBackTimer-=Time.deltaTime;
            }
        }
    }

    // Do damage to the player if we hit them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "hero")
        {
            if (gameManager.getHero().animator.GetCurrentAnimatorStateInfo(0).IsName("hero_attack_animation")) 
            {
                int attack = gameManager.getHero().getAttack();

                Rigidbody2D enemyRB = GetComponent<Rigidbody2D>();
                Rigidbody2D heroRB = hero.GetComponent<Rigidbody2D>();
                float enemy_x = enemyRB.transform.position.x;
                float enemy_y = enemyRB.transform.position.y;

                // apply knockback
                Vector2 enemyToHero = (enemyRB.transform.position - heroRB.transform.position).normalized * hero.getAttack() * 10;

                Debug.Log("Knocking back!");
                enemyRB.AddForce(new Vector2(enemyToHero.x, enemyToHero.y));
                gameManager.takeDamage(damage);

                knockBackTimer = .5f;

                // do damage
                hp -= attack;

                if (hp <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else {
                Rigidbody2D enemyRB = GetComponent<Rigidbody2D>();
                Rigidbody2D heroRB = hero.GetComponent<Rigidbody2D>();
                float enemy_x = enemyRB.transform.position.x;
                float enemy_y = enemyRB.transform.position.y;

                // apply knockback
                Vector2 heroToEnemy = (heroRB.transform.position - enemyRB.transform.position).normalized * damage * 10;

                heroRB.AddForce(heroToEnemy);
            }
        }
    }
}
