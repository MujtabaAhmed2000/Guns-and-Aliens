using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject options;

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene") ;
    }

    public void openOptions()
    {
        Menu.SetActive(false);
        options.SetActive(true);
    }

    public void back()
    {
        Menu.SetActive(true);
        options.SetActive(false);
    }

    public void exit()
    {
        Debug.Log("Exit not working");
        Application.Quit();
    }
}