using UnityEngine;

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
            Debug.Log("Level Finished");
        }
    }
}
