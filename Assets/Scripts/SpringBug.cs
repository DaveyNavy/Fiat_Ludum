using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SpringBug : PlayerBase
{
    [SerializeField] GameObject spring;
    GameObject springReal;
    [SerializeField] float offset;
    [SerializeField] AudioClip springTransform;
    Vector3 playerHeight;

    bool made = false;

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
        made = true;
        moving = false;
        Debug.Log("Make a spring!");
        animator.Play("SpringBugDie");
        StartCoroutine(SpringBugDie());
    }

    IEnumerator SpringBugDie() {
        AudioSource.PlayClipAtPoint(springTransform, transform.position, 1f);
        yield return new WaitForSeconds(1.15f);
        springReal = Instantiate(spring, this.transform.position, Quaternion.identity);
        //springReal.tag = "Ground";
        DestroySelf();
    }
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded && !made)
        {
            MakeSpring();
        }
    }

    // SpringBugDie 1.15
}
