using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BigBug : PlayerBase
{
    [SerializeField] AudioClip breakRock;
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
            StartCoroutine(BigBugDies());
        }
    }

    IEnumerator BigBugDies() {
        
        animator.Play("BigBoyDie");
        AudioSource.PlayClipAtPoint(breakRock, transform.position, 1f);
        yield return new WaitForSeconds(2.15f);
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
