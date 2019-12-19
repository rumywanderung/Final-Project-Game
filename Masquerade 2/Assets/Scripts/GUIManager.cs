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
    public AudioSource cello;
    public AudioSource crowd;

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

        Satana = SatanNPC.Satan;

        //CUES
        CCues.Lookat1.SetActive(false);
        CCues.Lookat2.SetActive(false);
        CCues.Lookat3.SetActive(false);
    }

    void Update()
    {

        if (Player.GetComponent<VIDEDemoPlayer>().inTrigger != null && (talkPopup.activeInHierarchy == false || talkSatan.activeInHierarchy == false))
        {
            Debug.Log(Player.GetComponent<VIDEDemoPlayer>().inTrigger + " is in trigger");

            if (Player.GetComponent<VIDEDemoPlayer>().inTrigger.name == "Icosphere")
            {
                Player.GetComponent<VIDEDemoPlayer>().move = 0;
                Player.GetComponent<VIDEDemoPlayer>().movebis = 0;
                cello.Stop();
                crowd.Stop();
                Debug.Log("Satan is... " + Satana);
                talkPopup.SetActive(false);
                talkSatan.SetActive(true);
                talkSatan.transform.Find("Text").gameObject.SetActive(true);
                Debug.Log(talkSatan);
                return;
            }
            else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger.name != "Icosphere")
            {
                talkPopup.SetActive(true);
                talkPopup.transform.Find("Text").gameObject.SetActive(true);
                Debug.Log(talkPopup);
                return;
            }
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger == null && (talkPopup.activeInHierarchy == true || talkSatan.activeInHierarchy == true))
        {
            if (Player.GetComponent<VIDEDemoPlayer>().inTrigger.name == "Icosphere")
            {
                talkSatan.SetActive(false);
                talkSatan.transform.Find("Text").gameObject.SetActive(false);
                return;
            }

            else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger.name != "Icosphere")
            {
                talkPopup.SetActive(false);
                talkPopup.transform.Find("Text").gameObject.SetActive(false);
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
