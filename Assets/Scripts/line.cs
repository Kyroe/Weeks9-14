using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class line : MonoBehaviour
{
    LineRenderer lineRen;
    Vector3 playerTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRen = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = playerTrans;
    }

    public void Looky(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        lineRen.positionCount = 2;
        lineRen.SetPosition(0, playerTrans);
        lineRen.SetPosition(1, worldMousePosition);
    }

    public void OnMove()
    {
        StartCoroutine(Mover());
        //when lerp is in action, set bool true, when bool is false, stop coroutine
    }

    public IEnumerator Mover()
    {
        float progress;
        bool isMoving = true;

        while(isMoving)
        {
            progress += Time.deltaTime;
        }
        //have one click start lerp 
    }
}
