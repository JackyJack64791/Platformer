using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject settingsPanel;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SettingsButton()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CreditsBack()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);      
    }

    public void SettingsBack()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);    
    }

}
