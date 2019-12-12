using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject talkPopup = null;

    private void Start()
    {
        //talkPopup = Resources.Load("CanvasTalk") as GameObject;
       // Instantiate(talkPopup, new Vector3(0, 0, 0), Quaternion.identity);
       // talkPopup.SetActive(false);
       // Debug.Log(talkPopup.activeInHierarchy);
    }

    void Update()
    {
       /* if (Player.GetComponent<VIDEDemoPlayer>().inTrigger != null && talkPopup.activeInHierarchy == false)
        {
            talkPopup.SetActive(true);
            Debug.Log(talkPopup);
            return;
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == null && talkPopup.activeInHierarchy == true)
        {
            talkPopup.SetActive(false);
            Debug.Log("trigger empty");
            return;
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == null && talkPopup.activeInHierarchy == false)
        {
            talkPopup.SetActive(false);
            Debug.Log("both null");
            return;
        }
        /*else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger != null && talkPopup != null)
        {
            Debug.Log("I'm having a convo");
            return;
        }*/
    }
}
