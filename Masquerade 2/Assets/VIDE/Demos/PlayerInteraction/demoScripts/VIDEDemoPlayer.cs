using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VIDE_Data;

public class VIDEDemoPlayer : MonoBehaviour
{
    //This script handles player movement and interaction with other NPC game objects

    public string playerName = "VIDE User";

    //Reference to our diagUI script for quick access
    public VIDEUIManager1 diagUI;
   // public QuestChartDemo questUI;

    //camera things
    public Camera cams;
    public float speedH = 2.0F;
    public float speedV = 2.0F;
    public float yaw = 0.0f;
    public float pitch = 0.0f;

    //jump things
    /*private bool canJump = false;
    public float ForceConst;
    private Rigidbody rb;
    */
    //public Animator blue;

    //Stored current VA when inside a trigger
    public VIDE_Assign inTrigger;

    //DEMO variables for item inventory
    //Crazy cap NPC in the demo has items you can collect
    public List<string> demo_Items = new List<string>();
    public List<string> demo_ItemInventory = new List<string>();

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
            inTrigger = other.GetComponent<VIDE_Assign>();
    }

    void OnTriggerExit()
    {
        inTrigger = null;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        cams.transform.eulerAngles = new Vector3(0, yaw, 0.0f);
        this.transform.eulerAngles = new Vector3(0, yaw, 0.0f);

        //jump

        //rb.angularVelocity = new Vector3(0, 0, 0);

        if (Input.GetKeyUp("c"))
        {
            Debug.Log(" in update");
            //canJump = true;
        }

        //Only allow player to move and turn if there are no dialogs loaded
        if (!VD.isActive)
        {
            transform.Rotate(0 * Input.GetAxis("Mouse X"), 0,0);
            //transform.Rotate(0 * Input.GetAxis("Mouse Y"), -1, 0);
            float move = Input.GetAxisRaw("Vertical");
            float movebis = Input.GetAxisRaw("Horizontal");
            transform.position += transform.forward * 10 * move * Time.deltaTime;
            transform.position += transform.right * 10 * movebis * Time.deltaTime;
            //blue.SetFloat("speed", move);
        }

        //Interact with NPCs when pressing E
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        //Hide/Show cursor
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = !Cursor.visible;
            if (Cursor.visible)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    //Casts a ray to see if we hit an NPC and, if so, we interact
    void TryInteract()
    {
        /* Prioritize triggers */

        if (inTrigger)
        {
            diagUI.Interact(inTrigger);
            return;
        }

        /* If we are not in a trigger, try with raycasts */

        RaycastHit rHit;

        if (Physics.Raycast(transform.position, transform.forward, out rHit, 2))
        {
            //Lets grab the NPC's VIDE_Assign script, if there's any
            VIDE_Assign assigned;
            if (rHit.collider.GetComponent<VIDE_Assign>() != null)
                assigned = rHit.collider.GetComponent<VIDE_Assign>();
            else return;

            if (assigned.alias == "QuestUI")
            {
               // questUI.Interact(); //Begins interaction with Quest Chart
            } else
            {
                diagUI.Interact(assigned); //Begins interaction
            }
        }
    }

    /*private void FixedUpdate()
    {
        if (canJump)
        {
            Debug.Log(" in Fixedupdate");
            canJump = false;
            rb.AddForce(0, ForceConst, 0, ForceMode.Impulse);
        }
    }*/
    
}
