using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpForce;

    public GameObject loseScreenUI;

    public int score, hiScore;
    public Text scoreUI, hiScoreUI;
    string HISCORE = "HISCORE";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {         
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }

     void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlaySound(0);
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }
    void PlayerLose()
    {
        AudioManager.singleton.PlaySound(1);
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt(HISCORE, hiScore);
        }
        hiScoreUI.text = "HiScore: " + hiScore.ToString();
        loseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void addScore()
    {
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            PlayerLose();
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score"))
        {
            addScore();
        }
    }

}
