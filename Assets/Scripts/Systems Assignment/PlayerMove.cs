using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Vector2 move;
    public float speed = 5;
    Buttons button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)move * speed * Time.deltaTime; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnE(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            button.StopButton();
            
        }
    }
}
