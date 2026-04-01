using System.Collections;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject player;
    public AnimationCurve mover;
    public Vector2 startPos;
    public Vector2 endPos;
    public float duration;
    private Coroutine button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGreen ()
    {
        if (button != null)
        {
            StopCoroutine(button);
        }

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

            transform.position = Vector2.Lerp(startPos, endPos, progress);

            yield return null;
        }

        mPlayer.enabled = true;
    }
}
