using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject options;

    public void PlayGame()
    {
        SceneManager.LoadScene("Story") ;
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
        Application.Quit();
    }

    public void toGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}