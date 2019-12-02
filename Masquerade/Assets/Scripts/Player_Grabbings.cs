using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Grabbings : MonoBehaviour
{
    public bool grabbed = false;
    public bool closeEnough = false;
    public GameObject inHand;
    [HideInInspector]
    public GameObject inHandCheck;
    public Transform grabbedObject = null;
    public Transform playerCam;
    public GameManager manager;

    private void OnCollisionEnter(Collision collision)
    {
        //if object is grabable
        if (collision.gameObject.tag == "objectToGrab")
        {
            closeEnough = true;
            grabbedObject = collision.collider.GetComponent<Transform>();

            //wine (name)

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
                        inHand = grabbedObject.gameObject;

                        if (grabbedObject.gameObject.name == "wine")
                        {   //guestA (name) without wine is destroyed
                            Debug.Log("WINE");

                            Destroy(manager.NPC.gameObject.transform.GetChild(0).gameObject);
                            GameObject Guest = Resources.Load("GuestA-HasDrink") as GameObject;
                            Instantiate(Guest, new Vector3(-7.579987F, 0.8F, -7.86F), Quaternion.identity);
                        }
                    }
                }
                if (Input.GetKeyUp("x"))
                {
                    grabbed = false;
                    grabbedObject.transform.parent = null;
                    grabbedObject = null;
                    inHand = null;

                }
            }

            else
            {
                grabbed = false;
            }
        }
    }
}
