using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    AudioManager audioManager;
    public int bestScore;
    public TextMeshProUGUI bestScoreText;
    public GameObject logic; //calls reference to character container

    [ContextMenu("Add Point")]
    public void AddPoint(int scoreToAdd){
        playerScore = playerScore + scoreToAdd;
        audioManager.PlaySFX(audioManager.point);
        Debug.Log("Points; " + playerScore);
        scoreText.text = playerScore.ToString();
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void gameOver(){
        if (playerScore > bestScore)
        {
            bestScore = playerScore;
            PlayerPrefs.SetInt("HighScore", bestScore);
            PlayerPrefs.Save();
        }
        //UpdateBestScore;
        gameOverScreen.SetActive(true);
    }
    
    public void UpdateBestScore()
    {
        if (bestScoreText != null)
        {
            bestScoreText.text = bestScore.ToString();
        }
    }

    private void Awake (){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
