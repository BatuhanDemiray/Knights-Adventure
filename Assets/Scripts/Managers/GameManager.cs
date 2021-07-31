using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    Player player;
    public Slider healthBar;
    bool isGamePaused = false;

    public GameObject pauseGame;
    public GameObject endingGame;

    void Start()
    {
        player = FindObjectOfType<Player>();
        healthBar.maxValue = player.maxPlayerHealth;
    }
   
    void Update()
    {
        if (player.isDead)
        {
            Invoke("RestartGame", 0.4f);
        }
        UpdateUI();
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
    }

    void UpdateUI()
    {
        healthBar.value = player.currentPlayerHealth;
        if (player.currentPlayerHealth <= 0)
            healthBar.minValue = 0;
    }

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused == true)
        {
            Time.timeScale = 0.0f;
            pauseGame.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseGame.SetActive(false);
        }     
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Scenes/OpeningScene");
        Time.timeScale = 1.0f;
    }
}
