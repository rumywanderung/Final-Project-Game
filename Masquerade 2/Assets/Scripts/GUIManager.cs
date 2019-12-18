using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject talkPopup = null;
    public GameObject talkSatan = null;
    public CanvasCues CCues;
    public NPC_Events SatanNPC;
    public GameObject Satana; //empty gameobject to fill with npc_events object

    private void Start()
    {
        //Talk [E]
        talkPopup = Instantiate(Resources.Load("CanvasTalk")) as GameObject;
        talkPopup.SetActive(false);
        talkPopup.transform.Find("Text").gameObject.SetActive(false);
        GameObject var = FindObjectOfType<GameObject>();
        //SATAN
        talkSatan = Instantiate(Resources.Load("CanvasTalkSatan")) as GameObject;
        talkSatan.SetActive(false);
        talkSatan.transform.Find("Text").gameObject.SetActive(false);

        

        /*if (var.name == "trig_LookAt1")
        {
           // lookats1 = var;
        }*/
        //CUES
        CCues.Lookat1.SetActive(false);
        CCues.Lookat2.SetActive(false);
        CCues.Lookat3.SetActive(false);
    }

    void Update()
    {
        if (SatanNPC.Satan.gameObject != null)
        {
            Satana = (GameObject)SatanNPC.Satan.gameObject;
            Debug.Log("added satan!");
            Debug.Log(Satana);
        }

        if (Player.GetComponent<VIDEDemoPlayer>().inTrigger != null && (talkPopup.activeInHierarchy == false || talkSatan.activeInHierarchy == false))
        {
            if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == Satana)
            {
                talkSatan.SetActive(true);
                talkSatan.transform.Find("Text").gameObject.SetActive(true);
                Debug.Log(talkSatan);
                return;
            }
            else
            {
                talkPopup.SetActive(true);
                talkPopup.transform.Find("Text").gameObject.SetActive(true);
                Debug.Log(talkPopup);
                return;
            }
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == null && (talkPopup.activeInHierarchy == true || talkSatan.activeInHierarchy == true))
        {
            if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == Satana)
            {
                talkSatan.SetActive(false);
                talkSatan.transform.Find("Text").gameObject.SetActive(false);
                Debug.Log("trigger satan empty");
                return;
            }
            else
            {
                talkPopup.SetActive(false);
                talkPopup.transform.Find("Text").gameObject.SetActive(false);
                Debug.Log("trigger empty");
                return;
            }
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == null && talkPopup.activeInHierarchy == false)
        {
           /* talkPopup.SetActive(false);
            Debug.Log("both null");
            return;*/
        }
    }
}
