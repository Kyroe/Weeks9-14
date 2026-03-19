using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public Vector2 move;
    public Vector3 look;
    public Vector2 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)move * speed * Time.deltaTime;
        //transform.eulerAngles = look;
        // look.z += target.x;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook (InputAction.CallbackContext context)
    {
        target = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
