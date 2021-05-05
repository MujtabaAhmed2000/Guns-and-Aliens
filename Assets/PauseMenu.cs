using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;
    public GameObject pauseButtonPanel;
    public GameObject optionsMenu;

    // public GameObject PauseButtonPanel { get => pauseButtonPanel; set => pauseButtonPanel = value; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          //  Debug.Log("Pause not working");
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

    public void flipControls()
    {

    }

    public void muteAudio()
    {

    }

    public void exit()
    {
        Debug.Log("Exit not working");
        Application.Quit();
    }
   
}