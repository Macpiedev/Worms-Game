using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;

    public void playerMove(Move move) {
        if(move != Move.Shoot) {
            playerManager.move(move);
        }

    }
}
