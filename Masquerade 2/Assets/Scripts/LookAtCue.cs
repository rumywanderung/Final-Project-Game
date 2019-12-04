using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCue : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera Cam;
    private GameObject Cue;

    private void Start()
    {
        Debug.Log("cue = " + Cue);
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(Cue);

        if (other.tag == "lookatcue")
        {
            Debug.Log(Cue);
            Debug.Log("lookatcue");
            Cue = GameObject.FindGameObjectWithTag("cue");
            Cam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
            Cam.m_LookAt = Cue.transform;
        }
    }
}
