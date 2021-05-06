using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public GameObject GameOverPanel;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0.5f;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainGameScene");
        Time.timeScale = 1f;
    }
}
