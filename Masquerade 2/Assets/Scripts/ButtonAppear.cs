using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonAppear : MonoBehaviour
{
    private Button buttonStart;
    private Button buttonExit;
    private GameObject CanvasButtons;

    public ButtonMenu Canvas;
    public float i = 0;

    void Start()
    {
        CanvasButtons = (GameObject)Resources.Load("CanvasButtons");
    }
    
    void Update()
    {
        if (i < 8)
        {
            i += Time.deltaTime;
        }
        else if (i >= 8)
        {
            Instantiate(CanvasButtons);
            if (CanvasButtons.GetComponentInChildren<Button>().name == "ButtonStart")
            {
                buttonStart = CanvasButtons.GetComponentInChildren<Button>();
            }
            else if (CanvasButtons.GetComponentInChildren<Button>().name == "ButtonExit")
            {
                buttonExit = CanvasButtons.GetComponentInChildren<Button>();
            }
            
            Destroy(this.gameObject);
        }
    }
}
