using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;

public class MoveToPoint : MonoBehaviour
{

    public GameObject Player;
    public Cinemachine.CinemachineVirtualCamera Cam;
    public GameObject Point;
    public GameObject Cue;
    public GameObject dollycart;
    public GameObject dollytrack;
    public Camera maincam;
    public Cinemachine.CinemachineVirtualCamera MainCam;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");

        if (Player.tag == "player")
        {
            /*this.Cam.Follow = Point.transform;
            this.Cam.LookAt = Point.transform;*/

            //float length = dollytrack.GetComponent<CinemachinePath>().PathLength;
            //length = 1;
            //Cam = Instantiate(Resources.Load("CM vcam1", typeof(Cinemachine.CinemachineVirtualCamera))) as Cinemachine.CinemachineVirtualCamera;
          
            dollycart = Instantiate(Resources.Load("DollyCart1", typeof(GameObject))) as GameObject;
            Cam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
            Cam.m_Follow = dollycart.transform;
            Cam.m_LookAt = Point.transform;


            //dollytrack = Instantiate(Resources.Load("DollyTrack1", typeof(GameObject))) as GameObject;
            //dollytrack.GetComponent<CinemachineSmoothPath>().m_Waypoints[1].position.x = 5.529957F;
            //dollytrack.GetComponent<CinemachineSmoothPath>().m_Waypoints[1].position.y = 27.78951F;
            //dollytrack.GetComponent<CinemachineSmoothPath>().m_Waypoints[1].position.z = -3.959243F;
            dollycart.GetComponent<CinemachineDollyCart>().m_Path = dollytrack.GetComponent<CinemachineSmoothPath>();
            Debug.Log(Cam.Follow);
        }
    
    }
}
