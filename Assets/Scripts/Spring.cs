using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] float tp;
    [SerializeField] AudioClip bounce;
    GameObject player;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player collided");
            player = collision.gameObject;
            player.GetComponent<PlayerBase>().Spring();
            AudioSource.PlayClipAtPoint(bounce, transform.position, 1f);
        }
    }
}
