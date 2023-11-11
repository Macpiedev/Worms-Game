using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    //public Shooting shooter;

    public void playerMove(Move move) {
        if(move != Move.Shoot) {
            playerMovement.move(move);
        }

    }
}
