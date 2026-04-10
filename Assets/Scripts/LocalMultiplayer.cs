using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayer : MonoBehaviour
{
    public Vector2 moveDirect;
    public float moveSpeed; 
    public LocalMultiplayerManager manager;
    public float health = 5;

    public bool isDead = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirect * moveSpeed * Time.deltaTime; 

        if(health <= 0 )
        {
            isDead = true;
        }

        if(isDead)
        {
            gameObject.SetActive(false);
        }


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirect = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && gameObject.activeInHierarchy) 
        {
            PlayerInput playerInput = gameObject.GetComponent<PlayerInput>();
            manager.TryAttack(playerInput);
        }
    }
}
