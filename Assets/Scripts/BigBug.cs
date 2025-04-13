using UnityEngine;

public class BigBug : PlayerBase
{
    private GameObject breakableObject = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable")) {
            breakableObject = collision.gameObject;
            Debug.Log(breakableObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable"))
        {
            breakableObject = null;
        }
    }

    public void OnInteract()
    {
        if (breakableObject)
        {
            breakableObject.SetActive(false);
            DestroySelf();
        }
    }
}
