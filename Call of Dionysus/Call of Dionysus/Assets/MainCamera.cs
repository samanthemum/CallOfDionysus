using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hero;
    private Rigidbody2D heroRB;
    private HeroScript heroScript;
    private float speedFactor = .5f;
    void Start()
    {
        heroRB = hero.GetComponent<Rigidbody2D>();
        heroScript = hero.GetComponent<HeroScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float y_factor = (int)Input.GetAxis("Vertical");
        float x_factor = (int)Input.GetAxis("Horizontal");

        if (heroScript.getSanity() > 80)
        {
            GetComponent<RectTransform>().position = new Vector3(heroRB.transform.position.x, heroRB.transform.position.y, -2.5f);
        } else if(heroScript.getSanity() <= 80)
        {
            GetComponent<RectTransform>().position = Vector3.Lerp(GetComponent<RectTransform>().position, new Vector3(heroRB.transform.position.x, heroRB.transform.position.y, -2.5f), Time.deltaTime*speedFactor);
        }
    }
}
