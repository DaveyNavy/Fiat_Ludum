using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RectangleBug : PlayerBase
{
    [SerializeField] GameObject rectangle;
    [SerializeField] Material previewMaterialPrefab;
    [SerializeField] AudioClip createBridge;
    GameObject rectanglePreview;
    Material previewMaterialInstance;
    GameObject rectangleReal;
    Rectangle rectanglePreScript;

    float offsetX = 0;
    float offsetY = 0;
    Renderer rectangleRenderer;
    Renderer bugRenderer;
    Collider2D rectCollider;
    float oldSpeed;

    bool made = false;
    bool dying = false;

    Vector3 currLocation;

    // Get components, make materials, make rectangle preview, yay
    new void Start()
    {
        base.Start();
        previewMaterialInstance = new Material(previewMaterialPrefab);
        rectanglePreview = Instantiate(rectangle);
        Collider2D collider = rectanglePreview.GetComponent<Collider2D>();
        collider.isTrigger = true;

        rectanglePreScript = rectanglePreview.GetComponent<Rectangle>();
        rectangleRenderer = rectanglePreview.GetComponent<Renderer>();
        bugRenderer = GetComponent<Renderer>();
        rectangleRenderer.material = previewMaterialInstance;
        offsetX = (float)(Math.Ceiling(rectangleRenderer.bounds.size.x * 0.5));
        offsetY = (float)Math.Ceiling(rectangleRenderer.bounds.size.y * 0.5) + 0.2f;
        offsetY = offsetY - 0.1f;
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
        if (rectanglePreview && !dying)
        {
            rectanglePreview.transform.position = new Vector3(this.transform.position.x + (offsetX * facingRight), this.transform.position.y - offsetY + 0.6f, this.transform.position.z);

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
        made = true;
        Debug.Log("Make a rectangle!");
        dying = true;
        moving = false;
        animator.Play("RectangleBugDie");
        StartCoroutine(RectangleBugDies());
    }

    IEnumerator RectangleBugDies()
    {
        yield return new WaitForSeconds(0.6f);
        AudioSource.PlayClipAtPoint(createBridge, transform.position, 1f);
        rectangleReal = Instantiate(rectangle, rectanglePreview.transform.position, Quaternion.identity);
        rectangleReal.tag = "Ground";
        rectanglePreview.SetActive(false);
        DestroySelf();
    }

    // This should create a rectangle at the player location when player dies
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded && !made)
        {
            Makerectangle();
        }
    }
}
