using UnityEngine;
using TMPro;

public class ScoreManager1 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI newHighScoreText;

    private float score = 0f;
    private bool isGameOver = false;
    private float highScore;

    void Start()
    {
        score = 0f;
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        newHighScoreText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(score);

            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetFloat("HighScore", highScore);
                PlayerPrefs.Save();
                newHighScoreText.gameObject.SetActive(true);
            }
            else if (score < highScore)
            {
                
                PlayerPrefs.SetFloat("HighScore", highScore);
                PlayerPrefs.Save();
                newHighScoreText.gameObject.SetActive(true);
            }

        }
    }

    public float GetScore()
    {
        return score;
    }

    // ����� ���� ����� �� �������
    public float GetHighScore()
    {
        return highScore;
    }


    public void GameOver()
    {
        isGameOver = true;

        // ������ ������� ��� ������ ������
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
            newHighScoreText.gameObject.SetActive(true);
        }
        else if (score < highScore)
        {
            
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
            newHighScoreText.gameObject.SetActive(true);
        }
    }
}