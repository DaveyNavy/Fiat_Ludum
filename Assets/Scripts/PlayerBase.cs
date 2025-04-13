using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] GameObject soul;
    [SerializeField] public float speed;

    Vector2 movement = new Vector2(0, 0);
    Rigidbody2D rb;
    public bool grounded;
    public int facingRight = 1;
    SpriteRenderer spriterenderer;

    Animator animator;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (grounded)
        {
            rb.position += new Vector2(movement.x * speed * Time.deltaTime, 0);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movement = v;
        animator.SetBool("Walking", !Mathf.Approximately(v.x, 0));

        if (v.x == 0)
        {
            return;
        }
        else if (Mathf.Sign(v.x) > 0)
        {
            facingRight = 1;
            spriterenderer.flipX = false;
        }
        else
        {
            facingRight = -1;
            spriterenderer.flipX = true;
        }

    }
    void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(RevertGroundedCoroutine());
        }
    }

    public void DestroySelf()
    {
        Instantiate(soul, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator RevertGroundedCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        grounded = false;
    }
}
