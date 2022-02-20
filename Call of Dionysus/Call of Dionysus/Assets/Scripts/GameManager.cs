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

    public HeroScript getHero()
    {
        return hero;
    }

    void Start()
    {
        hero = GetComponentInChildren<HeroScript>();
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
        SceneManager.LoadScene("WinLevel");
    }

    public void loseLevel()
    {
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
