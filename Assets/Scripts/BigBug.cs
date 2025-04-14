using UnityEngine;
using UnityEngine.Tilemaps;

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
            
            if (breakableObject.GetComponentInChildren<Tilemap>()) 
            {
                breakableObject.GetComponentInChildren<Tilemap>().ClearAllTiles();
            } else
            {
                breakableObject.SetActive(false);
            }
            DestroySelf();
        }
    }
}
