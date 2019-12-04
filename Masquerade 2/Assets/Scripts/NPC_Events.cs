using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;

public class NPC_Events : MonoBehaviour
{
    //destroyObject
    public GameManager manager;
    GameObject grabableobject;
    //cameraEvent
    public Cinemachine.CinemachineVirtualCamera Cam;
    public GameObject LookAts;
    public GameObject Cue;
    public GameObject dollycart;
    public GameObject dollytrack;

    public void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void DestroyObject()
    {
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().inHand.gameObject;
        Destroy(grabableobject);
    }

    public void CameraEvent()
    {
        dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
        Cam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
        Cam.m_Follow = dollycart.transform;
        Cam.m_LookAt = LookAts.transform;

        dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack.GetComponent<CinemachineSmoothPath>();
        Debug.Log(Cam.Follow);
    }
}
