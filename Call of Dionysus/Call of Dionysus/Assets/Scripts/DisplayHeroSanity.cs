using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHeroSanity : MonoBehaviour
{
    // Start is called before the first frame update
    public HeroScript hero;
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Sanity: " + hero.getSanity().ToString() + "/" + hero.getMaxSanity().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Sanity: " + hero.getSanity().ToString() + "/" + hero.getMaxSanity().ToString();
    }
}
