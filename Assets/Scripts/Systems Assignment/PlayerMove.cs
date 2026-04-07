using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //grabs the button scripts
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
        //makes player move 
        transform.position += (Vector3)move * speed * Time.deltaTime; 
    }

    //mapped to input system -> move
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    //calls the coroutine stop method from the buttons script
    //mapped to the interaction input system
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
