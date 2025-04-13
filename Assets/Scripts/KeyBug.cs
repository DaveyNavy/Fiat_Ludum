using UnityEngine;

public class KeyBug : PlayerBase
{
    [SerializeField] GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Goal"))
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
            gameManager.DecrementGoalsNeeded();
        }
    }
}
