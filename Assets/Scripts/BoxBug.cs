using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxBug : PlayerBase
{
    [SerializeField] GameObject box;
    [SerializeField] Material previewMaterialPrefab;
    GameObject boxReal;

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
        Debug.Log("Make a box!");
        boxReal = Instantiate(box, this.transform.position, Quaternion.identity);
        boxReal.tag = "Ground";
    }

    // This should create a box at the player location when player dies
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded)
        {
            MakeBox();
        }
    }
}
