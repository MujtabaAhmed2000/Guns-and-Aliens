using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    public Text lastScore;


    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            PlayerInfo info = gameObject.GetComponent<PlayerInfo>();
            lastScore.text = info.getScore().ToString();
            gameObject.SetActive(false);
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
