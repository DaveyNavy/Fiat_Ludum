using UnityEngine;

public class Rectangle : MonoBehaviour
{
    public bool grounded = true;
    public bool wall = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        else if (collision.gameObject.tag == "Wall")
        {
            wall = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
        else if (collision.gameObject.tag == "Wall")
        {
            wall = false;
            Debug.Log("Lemme out");
        }
    }
}
