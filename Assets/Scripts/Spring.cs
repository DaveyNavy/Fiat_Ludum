using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] float tp;
    float thrust = 17;
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player collided");
            player = collision.gameObject;
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<Rigidbody2D>().AddForce(player.transform.up * thrust, ForceMode2D.Impulse);
            StartCoroutine(waitForJump());
        }
    }

    IEnumerator waitForJump() {
        yield return new WaitForSeconds(0.7f);
        player.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
