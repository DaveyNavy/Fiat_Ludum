using UnityEngine;
using UnityEngine.InputSystem;

public class Soul : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField] float speed = 3;
    PlayerBase currentSelection = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.position += movement * speed * Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movement = v;
    }

    void OnExecute()
    {
        Debug.Log(currentSelection);

        if (currentSelection != null)
        {
            currentSelection.SetEnabled();

            this.gameObject.SetActive(false);
        }
    }

    public void ActivateSelf()
    {
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentSelection = collision.GetComponent<PlayerBase>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentSelection = null;
    }
}
