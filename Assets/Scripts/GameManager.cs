using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject soul;
    [SerializeField] int numGoals = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(soul);
    }

    public void DecrementGoalsNeeded()
    {
        numGoals--;
        if (numGoals == 0)
        {
            StartCoroutine(SwitchScenesCoroutine());
        }
    }

    IEnumerator SwitchScenesCoroutine()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int currLevel = Int32.Parse(sceneName.Split(" ")[1]);
        yield return new WaitForSeconds(3.4f);
        SceneManager.LoadScene("Level " + (currLevel + 1));
    }
}
