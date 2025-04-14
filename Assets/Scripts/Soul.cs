using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Soul : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField] float speed = 3;
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
        if (Camera.main.orthographicSize > 5 )
        {
            speed *= Camera.main.orthographicSize / 5;
            transform.localScale *= Camera.main.orthographicSize / 5;
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(1.4f);
        moving = true;
    }

    void Update()
    {
        if (moving) {
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

    void OnExecute()
    {
        if (currentSelection != null)
        {
            StartCoroutine(SoulBugHatch());
        }
    }

    IEnumerator SoulBugHatch() {
        animator.Play("SoulBugHatch");
        moving = false;
        yield return new WaitForSeconds(1.8f);
        currentSelection.InstantiateBug();
        Destroy(gameObject);
    }
    void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
