using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.AI;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private GameManager gameManager;
    private HeroScript hero;
    private int hp = 50;
    private int maxHP = 50;
    public float speed = 5f;
    public float acceleration = 24f;
    public float damage = 10;
    private bool fight = false;
    private float knockBackTimer = 0f;
    public Animator animator;
    private bool pausedLastFrame = false;
    NavMeshAgent agent;
    public AudioSource groan;

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

        agent = GetComponent<NavMeshAgent>();
        agent.acceleration = acceleration;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isPaused = false;
        isPaused = gameManager.isPaused();

        agent.SetDestination(hero.gameObject.transform.position);
        if (hero != null && !isPaused)
        {
            if(pausedLastFrame)
            {
                agent.isStopped = false;
            }
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
            //Vector2 newPosition = new Vector2(enemy_x + (speed * directionOfHero.x), enemy_y + (speed * directionOfHero.y));

            // Setup animator stuff
            if(Mathf.Abs(directionOfHero.x) > Mathf.Abs(directionOfHero.y))
            {
                animator.SetBool("horizontal", true);
            } else
            {
                animator.SetBool("horizontal", false);
            }
            animator.SetFloat("x", directionOfHero.x);
            animator.SetFloat ("y", directionOfHero.y);

            if (knockBackTimer <= 0)
            {
                agent.speed = current_speed;
                if (fight && gameManager.getHero().animator.GetCurrentAnimatorStateInfo(0).IsName("hero_attack_animation"))
                {
                    takeDamage();
                }
                if (knockBackTimer < 0)
                {
                    knockBackTimer = 0;
                    agent.isStopped = false;
                }
            } 
            
            else
            {
                knockBackTimer-=Time.deltaTime;
            }
        } else if(isPaused)
        {
            agent.isStopped = true;
        }

        pausedLastFrame = isPaused;
    }

    private void takeDamage()
    {
        groan.Play();
        int attack = gameManager.getHero().getAttack();

        Rigidbody2D enemyRB = GetComponent<Rigidbody2D>();
        Rigidbody2D heroRB = hero.GetComponent<Rigidbody2D>();

        // apply knockback
        Vector2 enemyToHero = (enemyRB.transform.position - heroRB.transform.position).normalized * hero.getAttack() * 10;
        enemyRB.AddForce(new Vector2(enemyToHero.x, enemyToHero.y));
        agent.isStopped = true;


        knockBackTimer = .5f;

        // do damage
        hp -= attack;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Do damage to the player if we hit them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "hero")
        {
            fight = true;
            if (gameManager.getHero().animator.GetCurrentAnimatorStateInfo(0).IsName("hero_attack_animation")) 
            {
                takeDamage();
            }
            else {
                Rigidbody2D enemyRB = GetComponent<Rigidbody2D>();
                Rigidbody2D heroRB = hero.GetComponent<Rigidbody2D>();

                // apply knockback
                Vector2 heroToEnemy = (heroRB.transform.position - enemyRB.transform.position).normalized * damage * 20;
                gameManager.takeDamage(damage);

                // have enemy stagger back a little
                enemyRB.AddForce(-1 * heroToEnemy / 2);
                knockBackTimer = .5f;

                hero.GetComponent<Rigidbody2D>().AddForce(heroToEnemy);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        fight = false;
    }
}
