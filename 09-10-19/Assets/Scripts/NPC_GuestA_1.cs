using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_GuestA_1 : MonoBehaviour
{
    public GameManager manager;
    GameObject grabableobject;

    public void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
           
            player = collision.gameObject;

            if (player.GetComponent<Player_Grabbing>().grabbedObject.name == "wine")
            {
                grabableobject = player.GetComponent<Player_Grabbing>().grabbedObject.gameObject;
                DestroyObject(grabableobject);
                
            }

        }
    }*/

    public void DestroyObject()
    {
        grabableobject = manager.Player.GetComponent<Player_Grabbing>().grabbedObject.gameObject;
        Destroy(grabableobject);
    }
}
