using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;
using VIDE_Data;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC_Events : MonoBehaviour
{
    public GameObject Player;
    //destroyObject
    public GameManager manager;
    public GUIManager GUIManager1;
    GameObject grabableobject;
    //cameraEvent
    private Cinemachine.CinemachineVirtualCamera Cam1;
    private Cinemachine.CinemachineVirtualCamera Cam2;
    private Cinemachine.CinemachineVirtualCamera Cam3;
    public GameObject LookAts1;
    public GameObject LookAts2;
    public GameObject LookAts3;
    //public GameObject Cue1;
    public GameObject dollycart;
    public Cinemachine.CinemachineSmoothPath dollytrack1;
    public Cinemachine.CinemachineSmoothPath dollytrack2;
    public Cinemachine.CinemachineSmoothPath dollytrack3;
    private bool cmOn = false;
    private float times;
    public Cinemachine.CinemachineVirtualCamera playerCam;
    //FLAGS
    public bool handFull = false;
    public bool wineGiven = false;
    public bool picGiven = false;
    public bool boxGiven = false;
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
    public GameObject Satan; //icosphere
    public GameObject Satan2;
    public GameObject Guard;

    //CHAOS

    public float ChaosPoint;
    public string ChaosPointText;

    // clues

    public string Clue1 = null;
    public string Clue2 = null;
    public string Clue3 = null;
    public string Clue1Text;
    public string Clue2Text;
    public string Clue3Text;
    public bool clue1Found = false;
    public bool clue2Found = false;
    public bool clue3Found = false;

    public void Start()
    {
        manager = FindObjectOfType<GameManager>();
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;
        //clues
        Clue1Text = "Clue #1: " + Clue1;
        Clue2Text = "Clue #2: " + Clue2;
        Clue3Text = "Clue #3: " + Clue3;

        LookAts1.SetActive(false);
        LookAts2.SetActive(false);
        LookAts3.SetActive(false);
    }

    public void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), ChaosPointText.ToString());
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
        LookAts1.SetActive(true);
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam1 = Instantiate(Resources.Load("CM vcam1", typeof(CinemachineVirtualCamera))) as CinemachineVirtualCamera;
        CinemachineBrain.SoloCamera = Cam1;
        Cam1.m_Follow = dollycart.transform;
        Cam1.m_LookAt = LookAts1.transform;
        dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack1.GetComponent<CinemachineSmoothPath>();
        
    }
    //camera VAMPIRE
    public void CameraEventVampire()
    {
        cmOn = true;
        LookAts2.SetActive(true);
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam2 = Instantiate(Resources.Load("CM vcam1", typeof(CinemachineVirtualCamera))) as CinemachineVirtualCamera;
        CinemachineBrain.SoloCamera = Cam2;
        Cam2.m_Follow = dollycart.transform;
        Cam2.m_LookAt = LookAts2.transform;
        dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack2.GetComponent<CinemachineSmoothPath>();
       
    }
    //camera DRAGON
    public void CameraEventDragon()
    {
        cmOn = true;
        LookAts3.SetActive(true);
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam3 = Instantiate(Resources.Load("CM vcam1", typeof(CinemachineVirtualCamera))) as CinemachineVirtualCamera;
        CinemachineBrain.SoloCamera = Cam3;
        Cam3.m_Follow = dollycart.transform;
        Cam3.m_LookAt = LookAts3.transform;
        dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack3.GetComponent<CinemachineSmoothPath>();
        
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WIN");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("LOSE");
    }

    public void CheckInHand()
    {
        intrig = Player.GetComponent<VIDEDemoPlayer>().inTrigger.gameObject;

        if (grabableobject != null)
        {
            handFull = true;
            Debug.Log(handFull);
            Debug.Log(Player.GetComponent<Player_Grabbing>().target.gameObject);
            //targets = objet en main destiné 

            // WINE
            if (Player.GetComponent<Player_Grabbing>().target.gameObject == Werewolf)
            {
                //qui est le NPC ?
                Debug.Log("i have wine in my hand");

                // werewolf (wine)
                if (intrig == Werewolf)
                {
                        DestroyObject();
                        wineGiven = true;
                        VD.SetNode(25); 
                }
                // vampire
                else if (intrig == Vampire || intrig == Dragon || intrig == Unicorn || intrig == Ghost || intrig == Witch)
                {
                    VD.SetNode(22);
                }
                else if (intrig == null)
                {
                    //
                }
            }

            // PIC
            if (Player.GetComponent<Player_Grabbing>().target.gameObject == Vampire)
            {

                Debug.Log("i have a picture in my hand");
                // werewolf
                if (intrig == Werewolf || intrig == Dragon || intrig == Unicorn || intrig == Ghost || intrig == Witch)
                {
                    VD.SetNode(22);
                }
                // vampire (picture)
                else if (intrig == Vampire)
                {
                    DestroyObject();
                    picGiven = true;
                    VD.SetNode(21);
                }
                else if (intrig == null)
                {
                    //
                }
            }
            
            // TREASUREBOX
            if (Player.GetComponent<Player_Grabbing>().target.gameObject == Dragon)
                {

                    Debug.Log("i have a treasure box in my hand");

                    if (intrig == Werewolf || intrig == Vampire || intrig == Unicorn || intrig == Ghost || intrig == Witch)
                    {
                        VD.SetNode(22);
                    }
                    // dragon (box)
                    else if (intrig == Dragon)
                    {
                        DestroyObject();
                        boxGiven = true;
                        VD.SetNode(21);
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

        else if (grabableobject == null)
        {
            handFull = false;
            Debug.Log(handFull);
            
                if (intrig == Werewolf && wineGiven == true)
                {
                    VD.SetNode(21);
                }
                else if (intrig == Werewolf && wineGiven == false)
                {
                    VD.SetNode(24);
                }
            
                else if (intrig == Vampire && picGiven == true)
                {
                    VD.SetNode(25);
                }
                else if (intrig == Vampire && picGiven == false)
                {
                    Debug.Log("vaaaamp");
                    VD.SetNode(3);
                }
                if (intrig == Dragon && boxGiven == true)
                {
                    VD.SetNode(1);
                }
                else if (intrig == Dragon && boxGiven == false)
                {
                    VD.SetNode(22);
                }
        }
    }

    public void AddChaos()
    {
        ChaosPoint += 1;
    }

    public void Update()
    {
        //CHAOS (adding)
        ChaosPointText = "Chaos: " + ChaosPoint + "/3";
        //CLUES
        Clue1Text = "Clue #1: " + Clue1;
        Clue2Text = "Clue #2: " + Clue2;
        Clue3Text = "Clue #3: " + Clue3;
        //check inhand
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;
        //camera moving = true
        if (cmOn == true && intrig == Werewolf)
        {
            GUIManager1.talkPopup.SetActive(false);

            if (times < 8)
            {
                times += Time.deltaTime;

                Debug.Log(times);

                if (times >= 8 && Cam1 != null && dollycart != null)
                {
                    Debug.Log("timer ends");
                    CinemachineBrain.SoloCamera = playerCam;
                    Destroy(Cam1.gameObject);
                    Destroy(dollycart.gameObject);
                    cmOn = false;
                    GUIManager1.talkPopup.SetActive(true);
                    times = 0;
                }
            }
        }
        else if (cmOn == true && intrig == Vampire)
        {
            if (times < 8)
            {
                times += Time.deltaTime;

                Debug.Log(times);

                if (times >= 8 && Cam2 != null && dollycart != null)
                {
                    Debug.Log("timer ends");
                    CinemachineBrain.SoloCamera = playerCam;
                    Destroy(Cam2.gameObject);
                    Destroy(dollycart.gameObject);
                    cmOn = false;
                    times = 0;
                    //GUIManager1.talkPopup.SetActive(true);
                }
            }
        }
        else if (cmOn == true && intrig == Dragon)
        {
            if (times < 8)
            {
                times += Time.deltaTime;

                Debug.Log(times);

                if (times >= 8 && Cam3 != null && dollycart != null)
                {
                    Debug.Log("timer ends");
                    CinemachineBrain.SoloCamera = playerCam;
                    Destroy(Cam3.gameObject);
                    Destroy(dollycart.gameObject);
                    cmOn = false;
                    times = 0;
                    //GUIManager1.talkPopup.SetActive(true);
                }
            }
        }

        //////////////////////////////////////TRIGGERS AFTER CAMERA

        // Trigger Lookat1 --> TEXT SHOWS
        if (VIDEDemoPlayer.trigger_lookat1 == true)
        {
            clue1Found = true;
            CCues.Lookat1.SetActive(true);
            Clue1 = "Monster Hunter infiltrated the Guest's home.";
            //LookAts1 = null;
            return;
        }
        // Trigger Lookat1 --> TEXT disappears
        else if (VIDEDemoPlayer.trigger_lookat1 == false)
        {
            CCues.Lookat1.SetActive(false);
        }
        // Trigger Lookat2 --> TEXT SHOWS
        if (VIDEDemoPlayer.trigger_lookat2 == true)
        {
            clue2Found = true;
            CCues.Lookat2.SetActive(true);
            Clue2 = "Impersonated Guest is a zoomorphic creature.";
            //LookAts2 = null;
            return;
        }
        // Trigger Lookat2 --> TEXT disappears
        else if (VIDEDemoPlayer.trigger_lookat2 == false)
        {
            CCues.Lookat2.SetActive(false);
        }
        // Trigger Lookat3 --> TEXT SHOWS
        if (VIDEDemoPlayer.trigger_lookat3 == true)
        {
            clue3Found = true;
            CCues.Lookat3.SetActive(true);
            Clue3 = "Impersonated Guest is male.";
            //LookAts3 = null;
            return;
        }
        // Trigger Lookat3 --> TEXT disappears
        else if (VIDEDemoPlayer.trigger_lookat3 == false)
        {
            CCues.Lookat3.SetActive(false);
        }

        /////////////////////////////////////CHAOS POINTS
        if (ChaosPoint == 3)
        {
            SceneManager.LoadScene("LOSE");
        }

        ////////////////////////////////////end of the game
        if (clue1Found == true && clue2Found == true && clue3Found == true)
        {
           
            RuntimeAnimatorController arrival = Resources.Load("SATAN") as RuntimeAnimatorController;
            Satan2.GetComponent<Animator>().runtimeAnimatorController = arrival;
            AudioSource audio = Satan.GetComponent<AudioSource>();
            Debug.Log(audio.name);
            audio.Play();
        }
    }
}
