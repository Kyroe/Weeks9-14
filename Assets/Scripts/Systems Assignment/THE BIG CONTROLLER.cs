using UnityEngine;
using UnityEngine.Events;

public class THEBIGCONTROLLER : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject player;

    public UnityEvent EventA;
    public UnityEvent EventB;
    public UnityEvent EventC;
    public UnityEvent EventD;

    //The big controller controls unity events
    //tracks if the player is on the button and invokes the unity event 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //grabs the sprite renderers for the buttons 
        
        SpriteRenderer mainPlayer = player.GetComponent<SpriteRenderer>();
        SpriteRenderer greenButton = button1.GetComponent<SpriteRenderer>();
        SpriteRenderer yellowButton = button2.GetComponent<SpriteRenderer>();
        SpriteRenderer blueButton = button3.GetComponent<SpriteRenderer>();
        SpriteRenderer redButton = button4.GetComponent<SpriteRenderer>();
        
        //depending on the colour of the button, a different unity event will be invoked
        //will invoke if the player is within bounds and the button is active
        if (greenButton.bounds.Contains(mainPlayer.transform.position) && button1.activeInHierarchy)
        {
            EventA.Invoke();

        }

        if (yellowButton.bounds.Contains(mainPlayer.transform.position) && button2.activeInHierarchy)
        {
            EventB.Invoke();
        }

        if (blueButton.bounds.Contains(mainPlayer.transform.position) && button3.activeInHierarchy)
        {
            EventC.Invoke();
        }

        if (redButton.bounds.Contains(mainPlayer.transform.position) && button4.activeInHierarchy)
        {
            EventD.Invoke();
        }
    }

    //a different method activated and deactivates the button game object 
    public void Green()
    {
        Debug.Log("Green");
        button2.SetActive(true);
        button4.SetActive(false);
    }

    public void Yellow()
    {
        Debug.Log("Yellow");
        button3.SetActive(true);
        button1.SetActive(false);
    }

    public void Blue()
    {
        Debug.Log("Blue");
        button4.SetActive(true);
        button2.SetActive(false);
    }
    public void Red()
    {
        Debug.Log("Red");
        button1.SetActive(true);
        button3.SetActive(false);
    }

}
