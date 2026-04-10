using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Unity.Cinemachine; 

public class LocalMultiplayerManager : MonoBehaviour
{
    public List<Sprite> possiblePlayerVisuals;
    public List<PlayerInput> exsitingPlayers;

    public CinemachineImpulseSource shake; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoinded(PlayerInput player)
    {
        //assign visuals to new player 
        exsitingPlayers.Add(player);

        SpriteRenderer newPlayerRenderer = player.GetComponent<SpriteRenderer>();
       // GameObject newPlayerGameObject = player.GetComponent<GameObject>();

        newPlayerRenderer.sprite = possiblePlayerVisuals[exsitingPlayers.Count];

        LocalMultiplayer playerScript = player.GetComponent<LocalMultiplayer>();
        playerScript.manager = this; //syntax "this" refers to THIS script THE ON THAT WE ARE WORKING ON!!

    }

    public void TryAttack(PlayerInput attackingPlayer)
    {
        for (int i = 0; i < exsitingPlayers.Count; i++)
        {
            if (attackingPlayer == exsitingPlayers[i])
            {
                //go to the next interatuion of the log so it doens't attack itself
                continue;
            }

            float distanceToPlayer = Vector3.Distance(attackingPlayer.transform.position, exsitingPlayers[i].transform.position);
            LocalMultiplayer newPlayerGameObject = exsitingPlayers[i].GetComponent<LocalMultiplayer>();

            if (distanceToPlayer < 1.5)
            {
                shake.GenerateImpulse();
                newPlayerGameObject.health -= 1;
                Debug.Log("ATTACK");
            }
        }


    }

}
