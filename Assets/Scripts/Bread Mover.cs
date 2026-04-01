using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BreadMover : MonoBehaviour
{
    public AnimationCurve mover;
    public GameObject startPos; 
    public GameObject endPos;
    public Button THEbreadbutton;
    public float duration;

    private bool move = false;
    private Coroutine breadButton;
    public  float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BreadMoveUpdate()
    {
        
        float progress = 0;
        
        while (timer < duration)
        {
            THEbreadbutton.interactable = false;
            //move bread with aniCurve and lerp 
            
            timer += Time.deltaTime;
            progress = mover.Evaluate(timer / duration);

            transform.position = Vector2.Lerp(startPos.transform.position, endPos.transform.position, progress);

            yield return null;
        }

        //once reaches destination, make bool false 

        THEbreadbutton.interactable = true;

    }

    public void OnBreadButton()
    {
       
        breadButton = StartCoroutine(BreadMoveUpdate());

    }
}
