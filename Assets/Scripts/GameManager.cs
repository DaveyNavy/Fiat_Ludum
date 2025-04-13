using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject soul;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(soul);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
