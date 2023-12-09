using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public PlayerManager playerManager;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerInfo>().isCurrentPlayer) {
           if(!playerManager.changeWasCalled) {
                playerManager.changePlayer();
           }
        }
        other.gameObject.SetActive(false);
    }
}
