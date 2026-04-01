using UnityEngine;

public class THEBIGCONTROLLER : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer mainPlayer = player.GetComponent<SpriteRenderer>();
        SpriteRenderer greenButton = button1.GetComponent<SpriteRenderer>();
        if (greenButton.bounds.Contains(mainPlayer.transform.position))
        {
            Debug.Log("this works");
        }
    }
}
