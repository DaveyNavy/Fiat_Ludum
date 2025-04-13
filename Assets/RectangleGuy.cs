using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RectangleGuy : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] GameObject rectangle;
    [SerializeField] Material previewMaterialPrefab;
    GameObject rectanglePreview;
    Material previewMaterialInstance;
    GameObject rectangleReal;
    PlayerBase pb;
    Rectangle rectanglePreScript;

    float offset = 2;
    int facingRight = 1;
    Vector2 v;
    bool previewGrounded;
    Renderer rectangleRenderer;
    float oldSpeed;
    bool rectangleMade = false;

    // Get components, make materials, make rectangle preview, yay
    void Start()
    {
        input = GetComponent<PlayerInput>();
        pb = GetComponent<PlayerBase>();
        previewMaterialInstance = new Material(previewMaterialPrefab);
        rectanglePreview = Instantiate(rectangle);
        rectanglePreScript = rectanglePreview.GetComponent<Rectangle>();
        rectangleRenderer = rectanglePreview.GetComponent<Renderer>();
        rectangleRenderer.material = previewMaterialInstance;
        oldSpeed = pb.speed;
    }

    // if rectanglePreview exists, move position
    // if not grounded, make red, else make white
    void Update()
    {

        if (rectanglePreview)
        {
            if (rectanglePreScript.wall)
            {
                pb.speed = 0;
            }
            else if (!rectanglePreScript.wall)
            {
                pb.speed = oldSpeed;
            }

            rectanglePreview.transform.position = new Vector3(this.transform.position.x + (offset * facingRight), this.transform.position.y, this.transform.position.z);

            if (!rectanglePreScript.grounded || !pb.grounded)
            {
                rectangleRenderer.material.color = new Color(Color.red.r, Color.red.g, Color.red.b, previewMaterialInstance.color.a);
            }
            else if (rectanglePreScript.grounded & pb.grounded)
            {
                rectangleRenderer.material = previewMaterialInstance;
            }
        }
    }

    // For getting direction, if facingRight = 1, then you are facing right
    // Also makes sure it remembers what direction it was facing in
    void OnMove(InputValue value)
    {
        v = value.Get<Vector2>();
        if (v.x == 0)
        {
            return;
        }
        else if (Mathf.Sign(v.x) > 0)
        {
            facingRight = 1;
        }
        else
        {
            facingRight = -1;
        }
    }

    // If the player is grounded, make a rectangle when executing
    void OnExecute()
    {
        if (rectanglePreview)
        {
            if (pb.grounded && rectanglePreScript.grounded)
            {
                Makerectangle();
            }
            if (!pb.grounded)
            {
                Debug.Log("Player not grounded");
            }
            if (!rectanglePreScript.grounded)
            {
                Debug.Log("rectangle location bad :(");
            }
        }
    }

    // This instantiates a rectangle at preview rectangle location, sets tag to ground, and disables preview
    void Makerectangle()
    {
        Debug.Log("Make a rectangle!");
        rectangleMade = true;
        rectangleReal = Instantiate(rectangle, rectanglePreview.transform.position, Quaternion.identity);
        rectangleReal.tag = "Wall";
        rectanglePreview.SetActive(false);
        pb.DestroySelf();
    }

    // This should create a rectangle at the player location when player dies
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded && !rectangleMade)
        {
            rectanglePreview.transform.position = this.transform.position;
            Makerectangle();
        }
    }
}
