using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Soul : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField] float speed = 3;
    [SerializeField] AudioClip enterEgg;
    [SerializeField] AudioClip spawnIn;
    Egg currentSelection = null;
    Animator animator;
    SpriteRenderer spriterenderer;
    bool moving = false;


    void Start()
    {
        moving = false;
        StartCoroutine(wait());
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        AudioSource.PlayClipAtPoint(spawnIn, transform.position, 1f);
        if (Camera.main.orthographicSize > 5 )
        {
            speed *= Camera.main.orthographicSize / 5;
            transform.localScale *= Camera.main.orthographicSize / 5;
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(1f);
        moving = true;
    }

    void Update()
    {
        if (moving) {
            Debug.Log("Soul Moving");
            rb.position += movement * speed * Time.deltaTime;
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movement = v;

        if (v.x == 0)
        {
            return;
        }
        else if (Mathf.Sign(v.x) > 0 && moving)
        {
            spriterenderer.flipX = false;
        }
        else if (Mathf.Sign(v.x) < 0 && moving)
        {
            spriterenderer.flipX = true;
        }
    }

    void OnInteract()
    {
        if (currentSelection != null)
        {
            StartCoroutine(SoulBugHatch());
        }
    }

    IEnumerator SoulBugHatch() {
        animator.Play("SoulBugHatch");
        moving = false;
        AudioSource.PlayClipAtPoint(enterEgg, transform.position, 1f);
        yield return new WaitForSeconds(1.8f);
        currentSelection.InstantiateBug();
        Destroy(gameObject);
    }
    void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentSelection = collision.GetComponent<Egg>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentSelection = null;
        }
    }
}
