using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayer : MonoBehaviour
{
    public Vector2 moveDirect;
    public float moveSpeed; 
    public LocalMultiplayerManager manager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirect * moveSpeed * Time.deltaTime; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirect = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerInput playerInput = gameObject.GetComponent<PlayerInput>();
            manager.TryAttack(playerInput);
        }
    }
}
