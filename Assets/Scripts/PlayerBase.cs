using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerBase : MonoBehaviour
{
    [SerializeField] GameObject soul;
    
    [SerializeField] AudioSource walking;
    [SerializeField] public float speed;

    Vector2 movement = new Vector2(0, 0);
    Rigidbody2D rb;
    public bool grounded;
    public int facingRight = 1;
    SpriteRenderer spriterenderer;

    public Animator animator;

    public bool moving = true;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        walking = GetComponent<AudioSource>();
        if (Camera.main.orthographicSize > 5)
        {
            transform.localScale *= 1 + ((Camera.main.orthographicSize / 5) - 1) / 2;
        }
    }
    void FixedUpdate()
    {
        if (grounded && moving)
        {
            rb.position += new Vector2(movement.x * speed * Time.deltaTime, 0);
        } 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            walking.enabled = true;
        } else {
            walking.enabled = false;
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
        else if (Mathf.Sign(v.x) > 0 && moving)
        {
            facingRight = 1;
            spriterenderer.flipX = false;
        }
        else if (Mathf.Sign(v.x) < 0 && moving)
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
        soul.transform.position = transform.position;
        InputDevice[] devices = new InputDevice[] { Keyboard.current, Mouse.current };
        PlayerInput.Instantiate(soul, controlScheme: "Keyboard&Mouse", pairWithDevices: devices);
        Destroy(gameObject);
    }

    IEnumerator RevertGroundedCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        grounded = false;
    }
}
