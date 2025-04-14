using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
