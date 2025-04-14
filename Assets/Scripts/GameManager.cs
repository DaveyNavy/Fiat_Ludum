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
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(3.4f);
        SceneManager.LoadScene(sceneBuildIndex + 1);
    }
}
