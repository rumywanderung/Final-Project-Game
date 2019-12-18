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

    public void Credits()
    {
        SceneManager.LoadScene("CREDITS");
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("START");
    }

    /*public void DisplaySliderValue(float value)
    {
        Debug.Log("Slider value: " + value.ToString());
    }*/
}
