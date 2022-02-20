using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public static float speed = .1f;
    public Rigidbody2D heroRB;
    private GameManager gameManager;
    static int hp = 100;
    static int sanity = 100;
    static int maxHP = 100;
    const int maxSanity = 100;
    static int attack = 20;

    public void hpBuff(float buff)
    {
        hp = (int)(hp + buff);
        maxHP = (int)(maxHP + buff);
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

            heroRB.MovePosition(new Vector2(current_x + (x_factor * speed), current_y + (y_factor * speed)));
        }
    }
}
