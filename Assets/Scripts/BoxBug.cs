using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxBug : PlayerBase
{
    [SerializeField] GameObject box;
    [SerializeField] AudioClip transformBox;
    GameObject boxReal;
    bool made = false;

    // If the player is grounded, make a box when executing
    public void OnInteract()
    {
        if (grounded)
        {
            MakeBox();
        } else
        {
            Debug.Log("Player not grounded");
        }
    }

    // This instantiates a box at preview box location, sets tag to ground, and disables preview
    void MakeBox()
    {
        made = true;
        moving = false;
        animator.Play("BoxBugDie");
        StartCoroutine(BoxBugDies());
    }

    IEnumerator BoxBugDies() {
        AudioSource.PlayClipAtPoint(transformBox, transform.position, 1f);
        yield return new WaitForSeconds(2.15f);
        boxReal = Instantiate(box, this.transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
        boxReal.tag = "Ground";
        DestroySelf();
    }

    // This should create a box at the player location when player dies
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded && !made)
        {
            MakeBox();
        }
    }
}
