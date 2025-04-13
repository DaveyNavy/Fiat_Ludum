using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player spiked");
            collision.GetComponent<PlayerBase>().DestroySelf();

        }
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Breakable")
        {
            Destroy(gameObject);
        }
    }
}
