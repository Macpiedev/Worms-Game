using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public PlayerManager playerManager;
    void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if(gameObject.tag != "Player") {
            return;
        }

        if(gameObject.GetComponent<PlayerInfo>().isCurrentPlayer) {
           if(!playerManager.changeWasCalled) {
                playerManager.changePlayer();
           }
        }
        
        gameObject.SetActive(false);
        playerManager.changeTeamSize(gameObject.GetComponent<PlayerInfo>().teamId);
    }
}
