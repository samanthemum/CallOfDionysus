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
    private float defaultFOV = 5;
    private Camera camera;
    private AudioListener audioListener;
    private float rateOfZoom = 5;
    private float rateOfMirror = 5;
    private float rateOfAudio = 10;
    private bool zooming = false;
    private bool muted = false;
    void Start()
    {
        heroRB = hero.GetComponent<Rigidbody2D>();
        heroScript = hero.GetComponent<HeroScript>();
        camera = this.GetComponent<Camera>();
        audioListener = this.GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        float y_factor = (int)Input.GetAxis("Vertical");
        float x_factor = (int)Input.GetAxis("Horizontal");
        speedFactor = heroScript.getSpeed() * 5;

        if (heroScript.getSanity() > 60)
        {
            GetComponent<RectTransform>().position = new Vector3(heroRB.transform.position.x, heroRB.transform.position.y, -2.5f);
        } else if(heroScript.getSanity() <= 60)
        {
            GetComponent<RectTransform>().position = Vector3.Lerp(GetComponent<RectTransform>().position, new Vector3(heroRB.transform.position.x, heroRB.transform.position.y, -2.5f), Time.deltaTime*speedFactor*(heroScript.getSpeed()/.1f));
        }

        // do camera zoom stuff
        if(heroScript.getSanity() <= 40)
        {
            rateOfZoom -= Time.deltaTime;
            if (rateOfZoom <= 0)
            {
                rateOfZoom = 5;
                Debug.Log("Here 1");
                float doZoom = Random.Range(1, 10);
                zooming = true;
               
                if(doZoom <= 5)
                {
                    zooming = true;
                } else
                {
                    zooming = false;
                    camera.orthographicSize = defaultFOV;
                }
            }

            if(zooming)
            {
                if (camera.orthographicSize >= 2.5f)
                {
                    camera.orthographicSize -= Time.deltaTime;
                }
            }
        }

        // do camera flip stuff
        if (heroScript.getSanity() <= 20)
        {
            rateOfMirror -= Time.deltaTime;
            if (rateOfMirror <= 0)
            {
                rateOfMirror = 5;
                float doMirror = Random.Range(1, 10);

                if (doMirror <= 5)
                {
                    camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
                }
                else
                {
                    camera.ResetProjectionMatrix();
                }
            }
        }

        // do audio stuff
        if (heroScript.getSanity() <= 10)
        {
            rateOfAudio -= Time.deltaTime;
            if (rateOfAudio <= 0)
            {
                rateOfAudio = 10;
                float doAudioCut = Random.Range(1, 10);

                if (doAudioCut <= 5)
                {
                    audioListener.enabled = false;
                }
                else
                {
                    camera.ResetProjectionMatrix();
                    audioListener.enabled = true;
                }
            }
        }
    }
}
