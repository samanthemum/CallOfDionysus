using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColumnScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int hp = 200;
    private int maxHP = 200;
    public GameManager gameManager;
    public HeroScript hero;
    bool fight = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
        if(fight)
        {
            if (gameManager.getHero().animator.GetCurrentAnimatorStateInfo(0).IsName("hero_attack_animation"))
            {
                takeDamage();
                fight = false;
            }
        }
    }

    private void takeDamage()
    {
        hp -= hero.getAttack();
    }

    public int getHP()
    {
        return hp;
    }

    public int getMaxHP()
    {
        return maxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "hero")
        {
            fight = true;
            if (gameManager.getHero().animator.GetCurrentAnimatorStateInfo(0).IsName("hero_attack_animation"))
            {
                takeDamage();
                fight = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        fight = false;
    }
}
