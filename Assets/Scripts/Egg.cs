using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] GameObject bug;

    public void InstantiateBug()
    {
        Instantiate(bug, this.transform.position, this.transform.rotation);
        this.gameObject.SetActive(false);   
    }
}