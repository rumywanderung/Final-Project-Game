using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;
using VIDE_Data;

public class NPC_Events : MonoBehaviour
{
    //destroyObject
    public GameManager manager;
    GameObject grabableobject;
    //cameraEvent
    public Cinemachine.CinemachineVirtualCamera Cam;
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

    public void Start()
    {
        manager = FindObjectOfType<GameManager>();
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;
    }

    public void DestroyObject()
    {
        Destroy(grabableobject);
    }

    public void CameraEvent()
    {
        cmOn = true;
       
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
            Debug.Log(handFull); ///////////////////goes into False but still plays dialogue: we need to stop it!!!!
        }
        else
        {
            handFull = false;
            Debug.Log(handFull);
            VD.nodeData.pausedAction = true;
        }
    }

    public void Update()
    {
        if (cmOn == true)
        {
            if (times < 15)
            {
                times += Time.deltaTime;
                Debug.Log(times);

                if (times >= 15 && Cam != null && dollycart != null)
                {
                    Debug.Log("timer ends");
                    /*Destroy(dollycart.gameObject);
                    dollytrack = (GameObject)Instantiate(Resources.Load("DollyTrack2", typeof(GameObject)));*/
                    Destroy(Cam.gameObject);
                    CinemachineBrain.SoloCamera = playerCam;
}
            }
        }
    }
}
