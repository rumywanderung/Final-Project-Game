using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Grabbing : MonoBehaviour
{
    public bool grabbed = false;
    public bool closeEnough = false;
    private Transform grabbedObject = null;
    public Transform playerCam;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "objectToGrab")
        {
            closeEnough = true;
            grabbedObject = collision.collider.GetComponent<Transform>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "objectToGrab")
        {
            closeEnough = false;
        }
    }

    void Update()
    {
        if (grabbedObject != null)
        {
            float dist = Vector3.Distance(grabbedObject.gameObject.transform.position, this.transform.position);

            if (dist <= 2.5F)
            {
                if (Input.GetKeyUp("g"))
                {
                    if (closeEnough == true)
                    {
                        Debug.Log("grabbed");
                        grabbed = true;
                        GetComponent<Rigidbody>().isKinematic = true;
                        grabbedObject.transform.parent = playerCam;
                    }
                }
            }

            else
            {
                grabbed = false;
            }
        }
    }
}
