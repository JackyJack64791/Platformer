using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pause;

    private bool paused = false;

    private void Start()
    {
        pause.SetActive(false);
    }

    private void Update()
    {
        if (paused)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void PauseButton()
    {
        paused = true;
    }

    public void BackButton()
    {
        paused = false;
    }

    public void SettingsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Poshel nahui");
    }
}
