using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject talkPopup = null;
    public CanvasCues CCues;

    private void Start()
    {
        //Talk [E]
        talkPopup = Instantiate(Resources.Load("CanvasTalk")) as GameObject;
        talkPopup.SetActive(false);
        talkPopup.transform.Find("Text").gameObject.SetActive(false);
        GameObject var = FindObjectOfType<GameObject>();
        if (var.name == "trig_LookAt1")
        {
           // lookats1 = var;
        }
        //CUES
        CCues.Lookat1.SetActive(false);
        CCues.Lookat2.SetActive(false);
        CCues.Lookat3.SetActive(false);
    }

    void Update()
    {
       if (Player.GetComponent<VIDEDemoPlayer>().inTrigger != null && talkPopup.activeInHierarchy == false)
        {
            talkPopup.SetActive(true);
            talkPopup.transform.Find("Text").gameObject.SetActive(true);
            Debug.Log(talkPopup);
            return;
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == null && talkPopup.activeInHierarchy == true)
        {
            talkPopup.SetActive(false);
            talkPopup.transform.Find("Text").gameObject.SetActive(false);
            Debug.Log("trigger empty");
            return;
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == null && talkPopup.activeInHierarchy == false)
        {
           /* talkPopup.SetActive(false);
            Debug.Log("both null");
            return;*/
        }
    }
}
