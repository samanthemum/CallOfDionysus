using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public static float speed = .1f;
    public Rigidbody2D heroRB;
    private GameManager gameManager;
    int hp = 100;
    int sanity = 100;
    int maxHP = 100;
    const int maxSanity = 100;
    int attack = 20;
    private bool fight = false;
    public Animator animator;
    private float totalTime = 0;
    private float knockBackTimer = 0f;
    public AudioSource footsteps;
    public AudioSource attackSound;
    public AudioSource hitSound;

    public void hpBuff(float buff)
    {
        hp = (int)(hp + buff);
        maxHP = (int)(maxHP + buff);
    }

    public float getSpeed()
    {
        return speed;
    }
    public int getAttack()
    {
        return attack;
    }

    public void attackBuff(float buff)
    {
        attack = (int)(attack + buff);
    }

    public void speedBuff(float buff)
    {
        speed *= buff;
    }

    public void sanityCost(int cost)
    {
        sanity -= cost;
    }

    public int getHP()
    {
        return hp;
    }

    public int getSanity()
    {
        return sanity;
    }

    public int getMaxHP()
    {
        return maxHP;
    }

    public int getMaxSanity()
    {
        return maxSanity;
    }

    public void takeDamage(float damage)
    {
        hitSound.Play();
        hp = hp - (int)damage;
    }

    public void resetHP()
    {
        hp = maxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        heroRB = GetComponent<Rigidbody2D>();
        gameManager = GetComponentInParent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPaused = gameManager.isPaused();

        if (!isPaused)
        {
            float y_factor = (int)Input.GetAxis("Vertical");
            float x_factor = (int)Input.GetAxis("Horizontal");

            float current_y = heroRB.position.y;
            float current_x = heroRB.position.x;

            if (knockBackTimer <= 0)
            {
                if (sanity > 80)
                {
                    heroRB.MovePosition(new Vector2(current_x + (x_factor * speed), current_y + (y_factor * speed)));
                }
                else
                {
                    totalTime += Time.deltaTime;
                    heroRB.MovePosition(new Vector2(current_x + (x_factor * speed) + (y_factor * Mathf.Cos(10 * totalTime)) / 25f, current_y + (y_factor * speed) + (x_factor * Mathf.Cos(10 * totalTime)) / 25f));
                }
                animator.SetFloat("x", x_factor);
                animator.SetFloat("y", y_factor);
                bool horizontal = Mathf.Abs(x_factor) >= Mathf.Abs(y_factor) ? true : false;
                animator.SetBool("horizontal", horizontal);
                bool stopped = x_factor == 0 && y_factor == 0;
                animator.SetBool("stopped", stopped);


                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetTrigger("attack");
                    attackSound.Play();
                }

                if (knockBackTimer < 0)
                {
                    knockBackTimer = 0;
                }

                if((x_factor != 0 || y_factor != 0) && !footsteps.isPlaying)
                {
                    footsteps.Play();
                }

                if((x_factor == 0 && y_factor == 0) && footsteps.isPlaying)
                {
                    footsteps.Pause();
                }
            } else
            {
                knockBackTimer-= Time.deltaTime;
                if(footsteps.isPlaying)
                {
                    footsteps.Pause();
                }
            }
        }

        else
        {
            if(footsteps.isPlaying)
            {
                footsteps.Pause();
            }
            animator.SetBool("stopped", true);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy" && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("hero_attack_animation"))
        {
            knockBackTimer = .25f;
        }
    }
}
