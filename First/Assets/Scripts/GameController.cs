using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pause;
    private AudioSource background;

    private bool paused = false;

    private void Start()
    {
        pause.SetActive(false);
        background = GetComponent<AudioSource>();
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
        background.Pause();
    }

    public void BackButton()
    {
        paused = false;
        background.UnPause();
    }

    public void SettingsButton()
    {

    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Poshel nahui");
    }
}
