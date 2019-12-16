using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;
using VIDE_Data;
using UnityEngine.UI;

public class NPC_Events : MonoBehaviour
{
    public GameObject Player;
    //destroyObject
    public GameManager manager;
    public GUIManager GUIManager1;
    GameObject grabableobject;
    //cameraEvent
    private Cinemachine.CinemachineVirtualCamera Cam;
    //public Cinemachine.CinemachineVirtualCamera Cam2;
    public GameObject LookAts1;
    //public GameObject Cue1;
    public GameObject dollycart;
    public Cinemachine.CinemachineSmoothPath dollytrack;
    private bool cmOn = false;
    private float times;
    public Cinemachine.CinemachineVirtualCamera playerCam;
    //FLAGS
    public bool handFull = false;
    public bool wineGiven = false;
    //
    public GameObject intrig;
    //
    public CanvasCues CCues;

    public GameObject Werewolf;
    public GameObject Vampire;
    public GameObject Ghost;
    public GameObject Unicorn;
    public GameObject Dragon;
    public GameObject Witch;
    public GameObject Satan;
    public GameObject Guard;

    //CHAOS

    public float ChaosPoint;
    public string ChaosPointText;

    // clues

    public string Clue1 = "";
    public string Clue2 = "";
    public string Clue3 = "";
    public string Clue1Text;
    public string Clue2Text;
    public string Clue3Text;

    public void Start()
    {
        manager = FindObjectOfType<GameManager>();
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;
        //clues
        Clue1Text = "Clue #1: " + Clue1;
        Clue2Text = "Clue #2: " + Clue2;
        Clue3Text = "Clue #3: " + Clue3;
    }

    public void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), ChaosPointText.ToString());
        //GUI.Box(new Rect(10, 10, 100, 20), ChaosPointText.ToString());
        //GUI.Box(new Rect(10, 40, 100, 20), Clue1Text.ToString());
        GUI.TextArea(new Rect(10, 40, 500, 20), Clue1Text.ToString());
        GUI.TextArea(new Rect(10, 70, 500, 20), Clue2Text.ToString());
        GUI.TextArea(new Rect(10, 100, 500, 20), Clue3Text.ToString());
    }

    public void DestroyObject()
    {
        Debug.Log("DestroyObject()");
        Destroy(grabableobject.gameObject);
    }

    //CAMERAS

    //camera WEREWOLF
    public void CameraEventWerewolf()
    {
        cmOn = true;
        //Player.SetActive(false);
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam = Instantiate(Resources.Load("CM vcam1", typeof(CinemachineVirtualCamera))) as CinemachineVirtualCamera;
        Cam.m_Follow = dollycart.transform;
        Cam.m_LookAt = LookAts1.transform;
        dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack.GetComponent<CinemachineSmoothPath>();
        Debug.Log(Cam.Follow);
    }
    //camera VAMPIRE
    public void CameraEventVampire()
    {
        cmOn = true;
        //Player.SetActive(false);
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam = Instantiate(Resources.Load("CM vcam1", typeof(CinemachineVirtualCamera))) as CinemachineVirtualCamera;
        Cam.m_Follow = dollycart.transform;
        Cam.m_LookAt = LookAts1.transform;

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

    public void AddChaos()
    {
        ChaosPoint += 1;
    }

    public void Update()
    {
        //CHAOS
        ChaosPointText = "Chaos: " + ChaosPoint;
        //CLUES
        Clue1Text = "Clue #1: " + Clue1;
        Clue2Text = "Clue #2: " + Clue2;
        Clue3Text = "Clue #3: " + Clue3;
        //check inhand
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;
        //camera moving = true
        if (cmOn == true)
        {
            GUIManager1.talkPopup.SetActive(false);

            if (times < 9)
            {
                times += Time.deltaTime;
                
                Debug.Log(times);

                if (times >= 9 && Cam != null && dollycart != null)
                {
                    Debug.Log("timer ends");
                    /*Destroy(dollycart.gameObject);
                    dollytrack = (GameObject)Instantiate(Resources.Load("DollyTrack2", typeof(GameObject)));*/
                    Destroy(Cam.gameObject);
                    Destroy(dollycart.gameObject);
                    //Player.SetActive(true);
                    CinemachineBrain.SoloCamera = playerCam;
                    cmOn = false;
                    GUIManager1.talkPopup.SetActive(true);
                }                   
            }
        }

        //////////////////////////////////////TRIGGERS AFTER CAMERA

        // Trigger Lookat1 --> TEXT SHOWS
        if (VIDEDemoPlayer.trigger_lookat1 == true)
        {
            CCues.Lookat1.SetActive(true);
            Clue1 = "Monster Hunter infiltrated the Guest's home.";
            return;
        }
        // Trigger Lookat1 --> TEXT disappears
        else if (VIDEDemoPlayer.trigger_lookat1 == false)
        {
            CCues.Lookat1.SetActive(false);
        }

        if (ChaosPoint == 3)
        {
            Debug.Log("GAME OVER");
        }
    }
}
