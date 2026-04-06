using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Vector2 move;
    public float speed = 5;
    public Buttons button1;
    public Buttons button2;
    public Buttons button3;
    public Buttons button4;
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
            button1.StopButton();
            button2.StopButton();
            button3.StopButton();
            button4.StopButton();



        }
    }
}
