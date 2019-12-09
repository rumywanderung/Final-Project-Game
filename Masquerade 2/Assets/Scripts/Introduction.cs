using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public GameObject Player;
    public GameObject intro00;
    public GameObject intro01;
    private bool inTrigger = false;
    private bool deletion0 = false;
    private bool deletion1 = false;
    public GameObject info;
    public GameObject particles;
    public AudioSource sfx;
    public AudioClip sfxClip;

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CubePlayer")
        {
            Destroy(info.gameObject);
            Destroy(particles.gameObject);
            sfx.Play();
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DestroyObjects(sfx.gameObject);
    }

    private void Update()
    {
        if (this.name == "I: 00" && inTrigger == true)
        {
            GameObject intro = Instantiate(Resources.Load("INTRO 00") as GameObject);
            intro00 = intro;
            inTrigger = false;
            deletion0 = true;
        }
        else if (this.name == "I: 01" && inTrigger == true)
        {
            GameObject intro = Instantiate(Resources.Load("INTRO 00") as GameObject);
            intro00 = intro;
            inTrigger = false;
            deletion1 = true;
        }
        //when to delete
        if (deletion0 == true)
        {
            if (Input.GetKeyUp("e"))
            {
                DestroyObjects(intro00);
                deletion0 = false;
            }
        }
        else if (deletion1 == true)
        {
            if (Input.GetKeyUp("e"))
            {
                DestroyObjects(intro00);
                deletion1 = false;
            }
        }
    }

    private void DestroyObjects(GameObject introToDestroy)
    {
        Destroy(introToDestroy);
    }
}
