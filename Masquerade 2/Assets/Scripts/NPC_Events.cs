using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;
using VIDE_Data;

public class NPC_Events : MonoBehaviour
{
    public GameObject Player;
    //destroyObject
    public GameManager manager;
    GameObject grabableobject;
    //cameraEvent
    private Cinemachine.CinemachineVirtualCamera Cam;
    //public Cinemachine.CinemachineVirtualCamera Cam2;
    public GameObject LookAts;
    public GameObject Cue;
    public GameObject dollycart;
    public GameObject dollytrack;
    private bool cmOn = false;
    private float times;
    public Cinemachine.CinemachineVirtualCamera playerCam;
    //FLAGS
    public bool handFull = false;
    public bool wineGiven = false;
    //
    public GameObject intrig;

    public GameObject Werewolf;
    public GameObject Vampire;
    public GameObject Ghost;
    public GameObject Unicorn;
    public GameObject Dragon;
    public GameObject Witch;
    public GameObject Satan;
    public GameObject Guard;

    public void Start()
    {
        manager = FindObjectOfType<GameManager>();
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;
    }

    public void DestroyObject()
    {
        Debug.Log("DestroyObject()");
        Destroy(grabableobject.gameObject);
    }

    public void CameraEventWerewolf()
    {
        cmOn = true;
        //Player.SetActive(false);
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam = Instantiate(Resources.Load("CM vcam1", typeof(CinemachineVirtualCamera))) as CinemachineVirtualCamera;
        Cam.m_Follow = dollycart.transform;
        Cam.m_LookAt = LookAts.transform;

        dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack.GetComponent<CinemachineSmoothPath>();
        Debug.Log(Cam.Follow);
       
    }

    public void CameraEventVampire()
    {
        cmOn = true;
        //Player.SetActive(false);
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam = Instantiate(Resources.Load("CM vcam1", typeof(CinemachineVirtualCamera))) as CinemachineVirtualCamera;
        Cam.m_Follow = dollycart.transform;
        Cam.m_LookAt = LookAts.transform;

        dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack.GetComponent<CinemachineSmoothPath>();
        Debug.Log(Cam.Follow);

    }

    public void CheckInHand()
    {
        if (grabableobject != null)
        {
            handFull = true;
            Debug.Log(handFull);
            Debug.Log(Player.GetComponent<Player_Grabbing>().target.gameObject);
            //targets = objet en main destiné à qui ?
            intrig = Player.GetComponent<VIDEDemoPlayer>().inTrigger.gameObject;
            // wine
            if (Player.GetComponent<Player_Grabbing>().target.gameObject == Werewolf)
            {
                //qui est le NPC ?
                Debug.Log("i have wine in my hand");

                // werewolf (wine)
                if (intrig == Werewolf)
                {
                        Debug.Log("im talking to Werewolf");
                        DestroyObject();
                        wineGiven = true;
                        VD.SetNode(25); 
                }
                // vampire
                else if (intrig == Vampire)
                {
                    Debug.Log("im talking to Vampire");
                    VD.SetNode(22);
                }
                else if (intrig == null)
                {
                    //
                }
            }

               // picture
            if (Player.GetComponent<Player_Grabbing>().target.gameObject == Vampire)
            {

                Debug.Log("i have a picture in my hand");
                // werewolf
                if (intrig == Werewolf)
                {
                    Debug.Log("im talking to Werewolf");
                    VD.SetNode(22);
                }
                // vampire (picture)
                else if (intrig == Vampire)
                {
                    Debug.Log("im talking to Vampire");
                    DestroyObject();
                }
                else if (intrig == null)
                {
                    //
                }

            }

            else if (Player.GetComponent<Player_Grabbing>().target.gameObject == null)
            {
                Debug.Log("no object in hand");
            }
        }
        else
        {
            handFull = false;

            if (wineGiven == true)
            {
                VD.SetNode(21);
            }
            else if (wineGiven == false)
            {
                VD.SetNode(24);
            }
        }
    }

    public void Update()
    {
        /*if (Player.GetComponent<VIDEDemoPlayer>().inTrigger.gameObject == null) {

            //
        }
        else if (Player.GetComponent<VIDEDemoPlayer>().inTrigger.gameObject != null)
        {
           intrig = Player.GetComponent<VIDEDemoPlayer>().inTrigger.gameObject;
        }*/

        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;

        if (cmOn == true)
        {///// camera event
            if (times < 5)
            {
                times += Time.deltaTime;
                Debug.Log(times);

                if (times >= 5 && Cam != null && dollycart != null)
                {
                    Debug.Log("timer ends");
                    /*Destroy(dollycart.gameObject);
                    dollytrack = (GameObject)Instantiate(Resources.Load("DollyTrack2", typeof(GameObject)));*/
                    Destroy(Cam.gameObject);
                    Destroy(dollycart.gameObject);
                    //Player.SetActive(true);
                    CinemachineBrain.SoloCamera = playerCam;
                    cmOn = false;
}
            }
        }
    }
}
