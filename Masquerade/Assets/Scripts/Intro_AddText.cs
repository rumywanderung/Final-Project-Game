using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_AddText : MonoBehaviour
{
    public Canvas canva;
    public Canvas canva2;

    void Start()
    {
        //canva = Resources.Load("Canvas0") as Canvas;
        canva = FindObjectOfType<Canvas>();
        this.GetComponent<DEMO_UIManager>().NPC_text = Resources.Load("Text") as UnityEngine.UI.Text;
        canva2 = Resources.Load("Canvas1") as Canvas;
        /*GameObject narr = Resources.Load("NARR") as GameObject;
        narr.transform.parent = canva.transform;
        Debug.Log(narr);*/

    }


}
