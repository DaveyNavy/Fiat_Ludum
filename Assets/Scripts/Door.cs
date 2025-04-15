using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioClip enterDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        AudioSource.PlayClipAtPoint(enterDoor, transform.position, 1f);
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
