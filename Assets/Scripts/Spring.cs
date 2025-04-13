using UnityEngine;

public class Spring : MonoBehaviour
{
    Vector3 playerPosition;
    [SerializeField] float tp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player collided");
            playerPosition = collision.gameObject.transform.position;
            collision.gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y + tp, playerPosition.z);
        }
    }
}
