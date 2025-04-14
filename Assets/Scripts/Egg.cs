using UnityEngine;
using UnityEngine.InputSystem;

public class Egg : MonoBehaviour
{
    [SerializeField] GameObject bug;

    public void InstantiateBug()
    {
        bug.transform.position = gameObject.transform.position;
        InputDevice[] devices = new InputDevice[] { Keyboard.current, Mouse.current };
        PlayerInput.Instantiate(bug, controlScheme: "Keyboard&Mouse", pairWithDevices: devices);
        
        gameObject.SetActive(false);   
    }
}