using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject infoGame;
    public GameObject langGame;
    public GameObject keyBindings;
    bool isInfoButtonOn = false;
    bool isLangButtonOn = false;
    bool isKeyButtonOn = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/GameScene");
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Button Worked");
        Application.Quit();
    }

    public void InfoGame()
    {
        isInfoButtonOn = !isInfoButtonOn;
        if (isInfoButtonOn)
            infoGame.SetActive(true);
        isInfoButtonOn = !isInfoButtonOn;
    }

    public void LanguageGame()
    {
        isLangButtonOn = !isLangButtonOn;
        if (isLangButtonOn)
            langGame.SetActive(true);
        isLangButtonOn = !isLangButtonOn;
    }

    public void OkayButton(GameObject obj)
    {
        obj.SetActive(false);   
    }

    public void KeyBindings()
    {
        isKeyButtonOn = !isKeyButtonOn;
        if (isKeyButtonOn)
            keyBindings.SetActive(true);
        isKeyButtonOn = !isKeyButtonOn;
    }

    public void SocialButton()
    {
        Application.OpenURL("https://github.com/batuhandemiray"); 
    }
}
