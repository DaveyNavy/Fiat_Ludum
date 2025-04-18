using System.Collections;
using UnityEngine;

public class KeyBug : PlayerBase
{
    GameManager gameManager;
    Collider2D doorCollider;
    new void Start()
    {
        base.Start();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Goal"))
        {
            (collider.GetComponent<Door>()).DestroyDoor();
            gameManager.DecrementGoalsNeeded();
            Renderer r = GetComponent<Renderer>();
            r.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            StartCoroutine(DestroySelfCoroutine());
        }
    }

    IEnumerator DestroySelfCoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        DestroySelf();
    }
}
