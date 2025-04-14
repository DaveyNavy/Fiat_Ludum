using UnityEngine;

public class Box : MonoBehaviour
{
    public bool grounded = true;
    public bool wall = false;
    protected void Start()
    {
        if (Camera.main.orthographicSize > 5)
        {
            transform.localScale *= 1 + ((Camera.main.orthographicSize / 5) - 1) / 2;
        }
    }


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
