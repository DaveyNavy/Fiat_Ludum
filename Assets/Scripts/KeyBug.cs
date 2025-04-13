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
            DestroySelf();
            Destroy(collider.gameObject);
            gameManager.DecrementGoalsNeeded();
        }
    }
}
