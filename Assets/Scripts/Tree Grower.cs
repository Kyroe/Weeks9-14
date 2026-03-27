using System;
using System.Collections;
using UnityEngine;


public class TreeGrower : MonoBehaviour
{
    public Transform branches;
    public float maxSpawnVariation; 

    public AnimationCurve growCurve;
    public float duration;
    public GameObject applePrefab;
    public float appleGrowDuration;

    private Coroutine TreeGrowCoroutine;
    private Coroutine appleCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            

    }
    
    private IEnumerator TreeGrowUpdate() //Coroutine allows us to pause and control the time
    {
        float progress = 0;

        while(progress < duration)
        {
            progress += Time.deltaTime;
            transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;

            yield return null; // relinquitesh contorl of unity so that evyerthing else can run for the rest of this frame 
            //normally the while would keep running, but with yield return null, it will run through the two lines once -> puase the while loop,
            //then resume once the next update starts 
        }

        appleCoroutine = StartCoroutine(AppleGrowUpdate());
        //yield return new WaitForSeconds(appleGrowDuration); 
        //relinquish control of unity until the apple has finished growing 

        yield return appleCoroutine; 
        //relinquish contorl until this apple coroutine has finished executing, thne you may proceed

        appleCoroutine = StartCoroutine(AppleGrowUpdate());
        //reuse the same variable
        yield return appleCoroutine; 

        StartCoroutine(AppleGrowUpdate()); 

    }

    private IEnumerator AppleGrowUpdate()
    {
        //uses random spawn pos trhough unit circle to grow them in random spots 
        Vector3 spawnPos = branches.position;
        spawnPos += (Vector3)UnityEngine.Random.insideUnitCircle * maxSpawnVariation;
        float progress = 0; 

        GameObject spawnedApple = Instantiate(applePrefab, spawnPos, Quaternion.identity);
        spawnedApple.transform.localScale = Vector3.zero;
        progress = 0;

        while (progress < appleGrowDuration)
        {
             progress += Time.deltaTime;
            spawnedApple.transform.localScale = growCurve.Evaluate(progress / appleGrowDuration) * Vector3.one;

            yield return null;
         }

        
    }

    public void OnGrowPress ()
    {
       TreeGrowCoroutine = StartCoroutine(TreeGrowUpdate()); //DO NOT MISS THIS SYNTAX    
        //created a variable to store this into so that we can refer to this specific instance of coroutine

    }

    public void OnStopPress()
    {
        if (TreeGrowCoroutine != null) //since tree coroutine doens't have any value initially, we need to null check so that things don't crash
        {
            StopCoroutine(TreeGrowCoroutine);
            //StopCoroutine(TreeGrowUpdate()); will not stop since we are refering to the og coroutine not that specific instance that is growing 
             
        }
        if(appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
            //same idea applies to the apple, since apple doesn't know that tree has stopped growing
        }
    }
}
