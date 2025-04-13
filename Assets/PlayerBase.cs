using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] Soul soul;
    [SerializeField] public float speed;

    Vector2 movement = new Vector2(0, 0);
    Rigidbody2D rb;
    public bool grounded;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        // input.DeactivateInput();
    }
    void FixedUpdate()
    {
        rb.position += new Vector2(movement.x * speed * Time.deltaTime, 0);
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movement = v;
    }

    public void SetEnabled()
    {
        input.ActivateInput();
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
        input.DeactivateInput() ;
        this.gameObject.SetActive(false);
        soul.ActivateSelf();
    }
}
