using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerInput : MonoBehaviour
{
    public Vector3 look;
    public Vector2 target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.ScreenToWorldPoint(target);
        transform.eulerAngles = look;
        look.z = target.x;
        Debug.Log(target);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        target = context.ReadValue<Vector2>();
    }
}
