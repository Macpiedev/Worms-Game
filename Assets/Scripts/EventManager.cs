using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public PlayerManager playerManager;

    void Update() {
        if(Input.GetKey("d"))
        {
            playerManager.move(Move.Right);
        }
        
        if(Input.GetKey("a"))
        {
            playerManager.move(Move.Left);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            playerManager.move(Move.Jump);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            playerManager.changePlayer(-1);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            playerManager.changePlayer(1);
        }
    }
}
