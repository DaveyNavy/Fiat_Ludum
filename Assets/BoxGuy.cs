using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxGuy : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] GameObject box;
    [SerializeField] Material previewMaterialPrefab;
    GameObject boxPreview; 
    Material previewMaterialInstance;
    GameObject boxReal;
    PlayerBase pb;
    Box boxPreScript;

    float offset = 2;
    int facingRight = 1;
    Vector2 v;
    bool previewGrounded;
    Renderer boxRenderer;
    float oldSpeed;

    // Get components, make materials, make box preview, yay
    void Start()
    {
        input = GetComponent<PlayerInput>();
        pb = GetComponent<PlayerBase>();
        previewMaterialInstance = new Material(previewMaterialPrefab);
        boxPreview = Instantiate(box);
        boxPreScript = boxPreview.GetComponent<Box>();
        boxRenderer = boxPreview.GetComponent<Renderer>();
        boxRenderer.material = previewMaterialInstance;
        oldSpeed = pb.speed;
    }

    // if boxPreview exists, move position
    // if not grounded, make red, else make white
    void Update()
    {

        if (boxPreScript.wall)
        {
            pb.speed = 0;
        } else if (!boxPreScript.wall)
        {
            pb.speed = oldSpeed;
        }
        
        if (boxPreview)
        {
            boxPreview.transform.position = new Vector3(this.transform.position.x + (offset * facingRight), this.transform.position.y, this.transform.position.z);

            if (!boxPreScript.grounded || !pb.grounded)
            {
                boxRenderer.material.color = new Color(Color.red.r, Color.red.g, Color.red.b, previewMaterialInstance.color.a);
            } 
            else if (boxPreScript.grounded & pb.grounded)
            {
                boxRenderer.material = previewMaterialInstance;
            }
        }
    }
    
    // For getting direction, if facingRight = 1, then you are facing right
    // Also makes sure it remembers what direction it was facing in
    void OnMove(InputValue value)
    { 
        v = value.Get<Vector2>();
        if (v.x == 0) {
            return;
        } else if (Mathf.Sign(v.x) > 0) {
            facingRight = 1;
        } else {
            facingRight = -1;
        }
    }

    // If the player is grounded, make a box when executing
    void OnExecute()
    {
        if ((pb.grounded && boxPreview) && boxPreScript.grounded)
        {
            MakeBox();
        } 
        if (!pb.grounded)
        {
            Debug.Log("Player not grounded");
        } 
        if (!boxPreScript.grounded)
        {
            Debug.Log("Box location bad :(");
        }
    }

    // This instantiates a box at preview box location, sets tag to ground, and disables preview
    void MakeBox()
    {
        Debug.Log("Make a box!");
        boxReal = Instantiate(box, boxPreview.transform.position, Quaternion.identity);
        boxReal.tag = "Ground";
        boxPreview.SetActive(false);
    }

    // This should create a box at the player location when player dies
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded)
        {
            boxPreview.transform.position = this.transform.position;
            MakeBox();
        }
    }
}
