using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button howToPlayButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.onClick.AddListener(Play);
        howToPlayButton.onClick.AddListener(HowToPlay);
    }

    void Play()
    {
        SceneManager.LoadScene("Level 0");
    }

    void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }
}
