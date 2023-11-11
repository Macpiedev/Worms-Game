using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameManager gameManager;

    void Update() {
        if(Input.GetKey("d"))
        {
            gameManager.playerMove(Move.Right);
        }
        
        if(Input.GetKey("a"))
        {
            gameManager.playerMove(Move.Left);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            gameManager.playerMove(Move.Jump);
        }
    }
}
