using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] enemyColumns;
    HeroScript hero;
    public GameManager gameManager;
    public float speed;
    public float damage;
    public GameObject beloved;
    void Start()
    {
        enemyColumns = GameObject.FindGameObjectsWithTag("enemy_column");
        hero = GameObject.FindGameObjectWithTag("hero").GetComponent<HeroScript>();

        for (int i = 0; i < enemyColumns.Length; i++) {
            Physics2D.IgnoreCollision(enemyColumns[i].GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        Physics2D.IgnoreCollision(beloved.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);
        Rigidbody2D heroRB = hero.GetComponent<Rigidbody2D>();
        Rigidbody2D thisRB = GetComponent<Rigidbody2D>();

        Vector2 heroToFireball = (heroRB.transform.position - thisRB.transform.position).normalized * speed;
        thisRB.MovePosition(new Vector2(thisRB.transform.position.x + heroToFireball.x, thisRB.transform.position.y + heroToFireball.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "hero" && !gameManager.getHero().animator.GetCurrentAnimatorStateInfo(0).IsName("hero_attack_animation"))
        {
            gameManager.takeDamage(damage);

            Rigidbody2D heroRB = hero.GetComponent<Rigidbody2D>();

            // apply knockback
            Vector2 heroToEnemy = (heroRB.transform.position - this.transform.position).normalized * damage * 20;
            hero.GetComponent<Rigidbody2D>().AddForce(heroToEnemy);
        }

       Destroy(this.gameObject);
    }
}
