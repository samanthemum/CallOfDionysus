using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private HeroScript hero;
    private static int level = 1;

    public HeroScript getHero()
    {
        return hero;
    }

    void Start()
    {
        hero = GetComponentInChildren<HeroScript>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
