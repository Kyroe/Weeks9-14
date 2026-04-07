using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Buttons : MonoBehaviour
{
    public GameObject player;
    public AnimationCurve mover;
    public Vector2 startPos;
    public Vector2 endPos;
    public float duration;
    public Coroutine button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //calls player move script and enables it when coroutine ends
    public void StopButton()
    {
        PlayerMove mPlayer = player.GetComponent<PlayerMove>();

        if (button != null)
        {
            StopCoroutine(button);
            mPlayer.enabled = true;
        }
    }

    //mapped to unity event
    //invoked when player triggers contains.bounds
    public void OnButton ()
    {
        button = StartCoroutine(MovePlayer());
    }

    //coroutine that moves player from one button to the other
    public IEnumerator MovePlayer()
    {
        float progress = 0;
        float timer = 0;
        PlayerMove mPlayer = player.GetComponent<PlayerMove>();

        //uses lerp to move player from one button to the other
        //disables the player move script so that players can move the duck while the lerp is ongoing
        while (timer < duration)
        {
            mPlayer.enabled = false;

            timer += Time.deltaTime;
            progress = mover.Evaluate(timer / duration);

            player.transform.position = Vector2.Lerp(startPos, endPos, progress);

            yield return null;
        }

        mPlayer.enabled = true;
        //reenables player move script once the lerp ends
    }
}
