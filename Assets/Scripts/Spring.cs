using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] float tp;
    [SerializeField] AudioClip bounce;
    float thrust = 17;
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
            //player.GetComponent<Rigidbody2D>().AddForce(player.transform.up * thrust, ForceMode2D.Impulse);
            //StartCoroutine(waitForJump());
        }
    }

    IEnumerator waitForJump() {
        yield return new WaitForSeconds(gameManager.numSpringSecs);
        player.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
