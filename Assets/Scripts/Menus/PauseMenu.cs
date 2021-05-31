using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    static bool GamePaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButtonPanel;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject GameSound;
    [SerializeField] GameObject MuteButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
                Resume();
            else
                Pause();
        }
        
    }

    public void Resume()
    {
        pauseButtonPanel.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseButtonPanel.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }


    public void muteAudio()
    {
        GameSound.SetActive(false);
        MuteButton.SetActive(false);
    }

    public void unmute()
    {
        GameSound.SetActive(true);
        MuteButton.SetActive(true);
    }

    public void back()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }
   
}
