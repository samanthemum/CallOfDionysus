using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private HeroScript hero;
    private static int level = 1;
    private bool paused = false;
    public GameObject grave;
    static List<Vector3> deathPositions = new List<Vector3>();

    public HeroScript getHero()
    {
        return hero;
    }

    void Start()
    {
        hero = GetComponentInChildren<HeroScript>();
        foreach(Vector3 position in deathPositions)
        {
                Instantiate(grave, position, new Quaternion());
        }
    }

    public void takeDamage(float damage)
    {
        this.hero.takeDamage(damage);

        // we've lost
        if(this.hero.getHP() <= 0)
        {
            loseLevel();
        }
    }

    public void pause()
    {
        paused = true;
    }

    public void unpause()
    {
        paused = false;
    }

    public bool isPaused()
    {
        return paused;
    }

    public void winLevel()
    {
        level++;
        hero.resetHP();
        deathPositions.Clear();
        SceneManager.LoadScene("WinLevel");
    }

    public void loseLevel()
    {
        deathPositions.Add(hero.GetComponent<Rigidbody2D>().position);
        hero.resetHP();
        SceneManager.LoadScene("LossLevel");
    }

    public int getLevel()
    {
        return level;
    }

    public void hpBuff(int buff)
    {
        hero.hpBuff(buff);
    }

    public void sanityCost(int cost)
    {
        hero.sanityCost(cost);
    }

    public void attackBuff(float buff)
    {
        hero.attackBuff(buff);
    }

    public void speedBuff(float buff)
    {
        hero.speedBuff(buff);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
