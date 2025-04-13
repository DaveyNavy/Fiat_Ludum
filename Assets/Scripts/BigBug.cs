using UnityEngine;

public class BigBug : PlayerBase
{
    private GameObject breakableObject = null;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable")) {
            breakableObject = collision.gameObject;
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
        Debug.Log(breakableObject);

        if (breakableObject)
        {
            breakableObject.SetActive(false);
            DestroySelf();
        }
    }
}
