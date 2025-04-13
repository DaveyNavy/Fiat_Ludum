using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Soul : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField] float speed = 3;
    Egg currentSelection = null;

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
        if (currentSelection != null)
        {
            currentSelection.InstantiateBug();
            Destroy(gameObject);
        }
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
