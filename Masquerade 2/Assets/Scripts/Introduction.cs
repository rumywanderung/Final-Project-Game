using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{

    public GameObject intro01;
    private bool inTrigger = false;
    private bool deletion0 = false;
    public GameObject info;
    public GameObject particles;
    private AudioSource sfx;

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

    private void Update()
    {
        if (this.name == "I: 00" && inTrigger == true)
        {
            GameObject intro = Instantiate(Resources.Load("INTRO 00") as GameObject);
            intro01 = intro;
            inTrigger = false;
            deletion0 = true;
        }
        else if (this.name == "I: 01" && inTrigger == true)
        {

        }
        //when to delete
        if (deletion0 == true)
        {
            if (Input.GetKeyUp("e"))
            {
                DestroyObjects(intro01);
                deletion0 = false;
            }
        }
    }

    private void DestroyObjects(GameObject introToDestroy)
    {
        Destroy(introToDestroy);
    }
}
