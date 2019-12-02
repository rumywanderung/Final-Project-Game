using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CloseDoor : MonoBehaviour
{
    private bool isOpen = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");

        if (!isOpen && collision.collider.tag == "door")

        {
            if (Input.GetKeyUp("o"))
            {
                isOpen = true;
                Transform door = collision.collider.GetComponentInParent<Transform>();
                Debug.Log(isOpen);
                door.transform.position =  new Vector3(0, -100, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
