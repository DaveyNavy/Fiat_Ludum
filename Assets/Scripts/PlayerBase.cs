using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    PlayerInput input;
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
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        rb.position += new Vector2(movement.x * speed * Time.deltaTime, 0);
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
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log("grounded");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
            Debug.Log("weeee (ungrounded)");
        }
    }

    public void DestroySelf()
    {
        Debug.Log("destroy self");
        Instantiate(soul, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
