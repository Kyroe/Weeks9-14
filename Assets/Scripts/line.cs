using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class line : MonoBehaviour
{
    LineRenderer lineRen;
    Vector3 playerTrans;
    public float progress = 0;
    bool isMoving;
    Coroutine move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRen = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = playerTrans;
        //if (isMoving == false )
        //{
        //    StopCoroutine(Mover());
        //}
    }

    public void Looky(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        lineRen.positionCount = 2;
        lineRen.SetPosition(0, playerTrans);
        lineRen.SetPosition(1, worldMousePosition);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("TEst["+context.phase+"]");

        if(context.phase == InputActionPhase.Performed)
        {
            move = StartCoroutine(Mover());

        }
        
        //when lerp is in action, set bool true, when bool is false, stop coroutine
    }

    public IEnumerator Mover()
    {
        progress = 0;
        bool isMoving = true;
        float duration = 2;
        
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if(move  != null)
        {
            yield return move;
        }
        while (progress < duration)
        {

            progress += Time.deltaTime;
            playerTrans = Vector2.Lerp(playerTrans, worldMousePosition, progress / duration);
            yield return null;
        }

        

        //if (progress > Time.deltaTime)
        //{
        //    isMoving = false;
        //}


        //have one click start lerp 
    }
}
