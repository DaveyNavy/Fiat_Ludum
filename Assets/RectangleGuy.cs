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

    float offset = 2;
    bool idek = false;
    int facingRight = 1;
    Vector2 v;

    // Get components, make materials, make rectangle preview, yay
    void Start()
    {
        input = GetComponent<PlayerInput>();
        pb = GetComponent<PlayerBase>();
        previewMaterialInstance = new Material(previewMaterialPrefab);
        rectanglePreview = Instantiate(rectangle);
        Renderer renderer = rectanglePreview.GetComponent<Renderer>();
        renderer.material = previewMaterialInstance;
    }

    // Set rectangle location with proper offset and direction
    void Update()
    {
        if (!idek && rectanglePreview)
        {
            rectanglePreview.transform.position = new Vector3(this.transform.position.x + (offset * facingRight), this.transform.position.y, this.transform.position.z);
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
        if (pb.grounded)
        {
            MakeRectangle();
        }
    }

    // This instantiates a rectangle at preview rectangle location, sets tag to ground, and disables preview
    void MakeRectangle()
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
            MakeRectangle();
        }
    }
}
