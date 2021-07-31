using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (collider.tag == "Player" && scene.name == "GameScene")
        {
            SceneManager.LoadScene("Scenes/GameScene-2");
            Time.timeScale = 1.0f;
        }
        else if (collider.tag == "Player" && scene.name == "GameScene-2")
        {
            gameManager.endingGame.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}