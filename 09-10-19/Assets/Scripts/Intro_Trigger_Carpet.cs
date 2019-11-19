using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Trigger_Carpet : MonoBehaviour
{
    public VIDEUIManager1 manager;

    public void Start()
    {
        manager = FindObjectOfType<VIDEUIManager1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
           manager.intro = Resources.Load("DEMO_UIManager intro") as DEMO_UIManager;
;
        }
    }
}
