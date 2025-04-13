using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        animator.Play("OpenDoor");
    }

    public void DestroyDoor()
    {
        OpenDoor();
        StartCoroutine(DestroyDoorCoroutine());
    }

    IEnumerator DestroyDoorCoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }
}
