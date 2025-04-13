using UnityEngine;

public class KeyBug : PlayerBase
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Level Finished");
        }
    }
}
