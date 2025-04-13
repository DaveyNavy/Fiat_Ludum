using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RectangleBug : PlayerBase
{
    [SerializeField] GameObject rectangle;
    [SerializeField] Material previewMaterialPrefab;
    GameObject rectanglePreview;
    Material previewMaterialInstance;
    GameObject rectangleReal;
    Rectangle rectanglePreScript;

    float offsetX = 0;
    float offsetY = 0;    
    Renderer rectangleRenderer;
    float oldSpeed;

    // Get components, make materials, make rectangle preview, yay
    new void Start()
    {
        base.Start();
        Debug.Log("start?");
        previewMaterialInstance = new Material(previewMaterialPrefab);
        rectanglePreview = Instantiate(rectangle);
        rectanglePreScript = rectanglePreview.GetComponent<Rectangle>();
        rectangleRenderer = rectanglePreview.GetComponent<Renderer>();
        rectangleRenderer.material = previewMaterialInstance;
        offsetX = (float) Math.Ceiling(rectangleRenderer.bounds.size.x * 0.5);
        offsetY = (float)Math.Ceiling(rectangleRenderer.bounds.size.y * 0.5);
        oldSpeed = speed;
    }

    // if rectanglePreview exists, move position
    // if not grounded, make red, else make white
    void Update()
    {
        /*
        if (rectanglePreScript.wall)
        {
            speed = 0;
        }
        else if (!rectanglePreScript.wall)
        {
            speed = oldSpeed;
        }
        */

        if (rectanglePreview)
        {
            rectanglePreview.transform.position = new Vector3(this.transform.position.x + (offsetX * facingRight), this.transform.position.y - offsetY, this.transform.position.z);

            if (!rectanglePreScript.grounded || !grounded)
            {
                rectangleRenderer.material.color = new Color(Color.red.r, Color.red.g, Color.red.b, previewMaterialInstance.color.a);
            }
            else if (rectanglePreScript.grounded & grounded)
            {
                rectangleRenderer.material = previewMaterialInstance;
            }
        }
    }

    // If the player is grounded, make a rectangle when executing
    public void OnInteract()
    {
        if ((grounded && rectanglePreview) && rectanglePreScript.grounded)
        {
            Makerectangle();
        }
        if (!grounded)
        {
            Debug.Log("Player not grounded");
        }
        if (!rectanglePreScript.grounded)
        {
            Debug.Log("rectangle location bad :(");
        }
    }

    // This instantiates a rectangle at preview rectangle location, sets tag to ground, and disables preview
    void Makerectangle()
    {
        Debug.Log("Make a rectangle!");
        rectangleReal = Instantiate(rectangle, rectanglePreview.transform.position, Quaternion.identity);
        rectangleReal.tag = "Ground";
        rectanglePreview.SetActive(false);
    }

    // This should create a rectangle at the player location when player dies
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded)
        {
            rectanglePreview.transform.position = this.transform.position;
            Makerectangle();
        }
    }
}
