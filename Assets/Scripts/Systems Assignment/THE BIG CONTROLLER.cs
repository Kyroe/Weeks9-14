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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer mainPlayer = player.GetComponent<SpriteRenderer>();
        SpriteRenderer greenButton = button1.GetComponent<SpriteRenderer>();
        SpriteRenderer yellowButton = button2.GetComponent<SpriteRenderer>();
        SpriteRenderer blueButton = button3.GetComponent<SpriteRenderer>();
        SpriteRenderer redButton = button4.GetComponent<SpriteRenderer>();
        PlayerMove mPlayer = player.GetComponent<PlayerMove>();

        if (greenButton.bounds.Contains(mainPlayer.transform.position) && button1.activeInHierarchy)
        {
            EventA.Invoke();
           // mPlayer.enabled = false;

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
