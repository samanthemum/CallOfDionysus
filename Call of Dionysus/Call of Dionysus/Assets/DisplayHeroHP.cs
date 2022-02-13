using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHeroHP : MonoBehaviour
{
    // Start is called before the first frame update
    public HeroScript hero;
   
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "HP: " + hero.getHP().ToString() + "/" + hero.getMaxHP().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "HP: " + hero.getHP().ToString() + "/" + hero.getMaxHP().ToString();
    }
}
