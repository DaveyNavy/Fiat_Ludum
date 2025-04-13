using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] GameObject bug;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateBug()
    {
        Instantiate(bug, this.transform.position, this.transform.rotation);
        this.gameObject.SetActive(false);   
    }
}