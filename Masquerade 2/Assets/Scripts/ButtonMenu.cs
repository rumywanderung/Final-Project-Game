using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MAIN");
    }

    public void EndGame()
    {
          Application.Quit();
    }

    /*public void DisplaySliderValue(float value)
    {
        Debug.Log("Slider value: " + value.ToString());
    }*/
}
