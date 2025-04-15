using UnityEngine;

public class walkingSound : MonoBehaviour
{
    public AudioSource walking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walking = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
