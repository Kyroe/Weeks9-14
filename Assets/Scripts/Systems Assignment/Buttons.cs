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

    public void StopButton()
    {
        if (button != null)
        {
            StopCoroutine(button);
        }
    }

    public void OnButton ()
    {
        button = StartCoroutine(MovePlayer());
    }

    public IEnumerator MovePlayer()
    {
        float progress = 0;
        float timer = 0;
        PlayerMove mPlayer = player.GetComponent<PlayerMove>();

        while (timer < duration)
        {
            mPlayer.enabled = false;

            timer += Time.deltaTime;
            progress = mover.Evaluate(timer / duration);

            player.transform.position = Vector2.Lerp(startPos, endPos, progress);

            yield return null;
        }

        mPlayer.enabled = true;
    }
}
