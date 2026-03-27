using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Knight : MonoBehaviour
{
    public AudioSource AudioSource;
    public float speed;
    float xMovement;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMovement, 0, 0) * speed * Time.deltaTime;
    }

    public void OnFootstep ()
    {
        AudioSource.Play();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //animator.SetBool("isRunning", true);
       Vector2 moveDirection = context.ReadValue<Vector2>();
        xMovement = moveDirection.x;

        bool isRunning = xMovement != 0; // set bool for check when it is running or not running, and animator parameter is mapped to that
        animator.SetBool("isRunning", isRunning);
    }
}
