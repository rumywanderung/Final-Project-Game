using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class Introduction : MonoBehaviour
{
    public VIDEDemoPlayer Player;
    public GameObject intro00;
    public GameObject intro01;
    public GameObject intro02;
    private bool inTrigger = false;
    private bool deletion0 = false;
    private bool deletion1 = false;
    private bool deletion2 = false;
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
            GameObject intro = Instantiate(Resources.Load("INTRO 01") as GameObject);
            intro01 = intro;
            inTrigger = false;
            deletion1 = true;
        }
        else if (this.name =="I: 02" && inTrigger == true)
        {
            GameObject intro = Instantiate(Resources.Load("INTRO 02") as GameObject);
            intro02 = intro;
            inTrigger = false;
            deletion2 = true;
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
                DestroyObjects(intro01);
                deletion1 = false;
            }
        }

        else if (deletion2 == true)
        {
            if (Input.GetKeyUp("e"))
            {
                DestroyObjects(intro02);
                deletion1 = false;
            }
        }
    }

    private void DestroyObjects(GameObject introToDestroy)
    {
        Destroy(introToDestroy);
    }
}
