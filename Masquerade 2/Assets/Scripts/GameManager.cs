using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject NPC;
    public GameObject Player;

    private void Update()
    {
        if (Input.GetKeyUp("x"))
        {
            Application.Quit();
        }
    }
}
