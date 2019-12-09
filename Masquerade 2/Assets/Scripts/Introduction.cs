using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{

    private GameObject intro00;
    private bool inTrigger = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "CubePlayer")
        {
            Debug.Log("Player is in trigger");
            inTrigger = true;
            Debug.Log(inTrigger);
        }
    }

    private void Update()
    {
        if (inTrigger)
        {
            Debug.Log("trigger dans update");
            if (Input.GetKeyUp("e"))
            {
                Debug.Log("pressed E");
                intro00 = Resources.Load("Intro 00") as GameObject;
                Instantiate(intro00, new Vector3(0,0,0), Quaternion.identity);
            }
        }
    }
}
