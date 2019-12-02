using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;
using UnityEditor;

public class MoveToPoint : MonoBehaviour
{

    public GameObject Player;
   // public Cinemachine.CinemachineVirtualCamera Cam;
    public GameObject Point;
    public GameObject Cue;
    public GameObject dollycart;
    public GameObject dollytrack;
    public Camera maincam;
    //public Cinemachine.CinemachineVirtualCamera MainCam;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");

        if (Player.tag == "player")
        {
           
            dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
            //Cam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
            //Cam.m_Follow = dollycart.transform;
            //Cam.m_LookAt = Point.transform;

            
            //dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack.GetComponent<CinemachineSmoothPath>();
           // Debug.Log(Cam.Follow);
        }

    }
}
