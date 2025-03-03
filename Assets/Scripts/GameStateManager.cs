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
    public GameObject player;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateBestScore();
    }

    [ContextMenu("Add Point")]
    public void AddPoint(int scoreToAdd){
        if (player.GetComponent<CharacterController>().getBirdAlive()) {
            playerScore = playerScore + scoreToAdd;
            audioManager.PlaySFX(audioManager.point);
            Debug.Log("Points; " + playerScore);
            scoreText.text = playerScore.ToString();
        }
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 1;
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        if (playerScore > bestScore)
        {
            bestScore = playerScore;
            PlayerPrefs.SetInt("HighScore", bestScore);
            PlayerPrefs.Save();
            UpdateBestScore();
        }
    }
    
    public void UpdateBestScore()
    {
        if (bestScoreText != null)
        {
            bestScoreText.text = bestScore.ToString();
            //bestScoreText.text = "High Score: " + bestScore;
        }
    }

    private void Awake (){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
