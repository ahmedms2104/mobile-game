using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public ScoreManager1 scoreManager;

    private bool isGameStarted = false;

    void Start()
    {
        Time.timeScale = 0;
        startUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void StartGame()
    {
        isGameStarted = true;
        Time.timeScale = 1;
        startUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        float finalScore = scoreManager.GetScore();

        // الحصول على أعلى نتيجة من ScoreManager بدلاً من PlayerPrefs
        float highScore = scoreManager.GetHighScore();

        scoreText.text = "Score: " + Mathf.FloorToInt(finalScore);
        highScoreText.text = "High Score: " + Mathf.FloorToInt(highScore);

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}