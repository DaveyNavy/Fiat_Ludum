using UnityEngine;
using UnityEngine.UIElements;

public class SpringBug : PlayerBase
{
    [SerializeField] GameObject spring;
    GameObject springReal;
    [SerializeField] float offset;
    Vector3 playerHeight;

    new void Start()
    {
        base.Start();
        playerHeight = new Vector3(0, offset, 0);
    }
    
    public void OnInteract()
    {
        if (grounded)
        {
            MakeSpring();
        }
        else
        {
            Debug.Log("Player not grounded");
        }
    }

    void MakeSpring()
    {
        Debug.Log("Make a spring!");
        springReal = Instantiate(spring, this.transform.position - playerHeight, Quaternion.identity);
        springReal.tag = "Ground";
        DestroySelf();
    }
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded)
        {
            MakeSpring();
        }
    }
}
