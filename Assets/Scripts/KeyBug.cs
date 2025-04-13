using System.Collections;
using UnityEngine;

public class KeyBug : PlayerBase
{
    GameManager gameManager;
    new void Start()
    {
        base.Start();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Goal"))
        {
            collider.gameObject.GetComponent<Door>().OpenDoor();
            Destroy(gameObject);
            wait(collider);
        }
    }

    IEnumerator wait(Collider2D collider)
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("help");
        Destroy(collider.gameObject);
        gameManager.DecrementGoalsNeeded();
    }
}
