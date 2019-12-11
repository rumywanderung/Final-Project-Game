using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Grabbing : MonoBehaviour
{
    public bool grabbed = false;
    public bool closeEnough = false;
    public GameObject inHand;
    [HideInInspector]
    public Transform inHandCheck;
    public Transform grabbedObject = null;
    //public Transform playerCam;
    public GameObject handright;
    public GameManager manager;
    public GameObject target = null;


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

            if (dist <= 99999999999999999999999999999999999999F)
            {
                if (Input.GetKeyUp("g"))
                {
                    if (closeEnough == true && grabbedObject.gameObject.name == "wine")
                    {
                        //WEREWOLF = target
                        target = manager.NPC.GetComponent<NPCchildren>().Werewolf.gameObject;
                        Debug.Log("Target = " + target);
                        //
                        //Debug.Log("grabbed = " + grabbedObject);

                        grabbed = true;
                        grabbedObject.transform.parent = handright.transform;

                        inHand = grabbedObject.gameObject;
                        inHandCheck = grabbedObject.gameObject.transform;
                       // Debug.Log("in hand = " + inHand);
                       // Debug.Log("in hand position = " + inHandCheck);
                        inHand.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        inHand.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        float posx = handright.transform.position.x - 0.5F;
                        float posy = handright.transform.position.y;
                        float posz = handright.transform.position.z - 0.5F;
                        grabbedObject.position = new Vector3(posx, posy, posz);
                        // replacement
                        if (manager.NPC.gameObject.name == "Werewolf")
                        {
                           // Debug.Log(manager.NPC.gameObject);
                            Destroy(manager.NPC.gameObject);
                            GameObject Guest = Resources.Load("GUEST A (1)") as GameObject;
                            Instantiate(Guest, new Vector3(-7.579987F, 0.8F, -7.86F), Quaternion.identity);
                        }
                    }

                    else if (closeEnough == true && grabbedObject.gameObject.name == "picture")
                    {

                        //VAMPIRE = target
                        target = manager.NPC.GetComponent<NPCchildren>().Vampire.gameObject;
                        Debug.Log(target + " player_grabbing");
                        //
                       // Debug.Log("grabbed = " + grabbedObject);
                        grabbed = true;
                        grabbedObject.transform.parent = handright.transform;

                        inHand = grabbedObject.gameObject;
                        inHandCheck = grabbedObject.gameObject.transform;
                       // Debug.Log("in hand = " + inHand);
                       // Debug.Log("in hand position = " + inHandCheck);
                        inHand.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        inHand.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        float posx = handright.transform.position.x;
                        float posy = handright.transform.position.y;
                        float posz = handright.transform.position.z;
                        grabbedObject.position = new Vector3(posx, posy, posz);
                        // replacement

                        
                        
                    }

                    /*if (target == npcChild.Werewolf.gameObject)
                    {
                        //
                    }
                    else if (target == npcChild.Vampire.gameObject)
                    {
                        //
                    }*/
                }
                /*if (Input.GetKeyUp("x"))
                {
                    grabbed = false;
                    grabbedObject.transform.parent = null;
                    grabbedObject = null;
                    inHand = null;

                }*/
            }

            else
            {
                grabbed = false;
            }
        }
    }
}
