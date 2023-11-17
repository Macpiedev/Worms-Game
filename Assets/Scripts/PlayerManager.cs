using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int teamSize;
    public GameObject playerObject;
    private GameObject currentPlayer;
    private int currentPlayerId;
    public int minPlayerSpawnPositionX;
    public int maxPlayerSpawnPositionX;
    private List<GameObject> team1Players = new List<GameObject>();
    private List<GameObject> team2Players = new List<GameObject>();
    private bool started = false;
    
    void Start() {
        

        for(int i=0; i < teamSize; i++) {
            team1Players.Add(spawn());
            team2Players.Add(spawn());
        }

        currentPlayer = team1Players[0];
        currentPlayerId = 0;
       
        started = true;
    }

    public bool playersExists() {
        return started;
    }

    GameObject spawn() {
        return Instantiate(playerObject, new Vector3(Random.Range(minPlayerSpawnPositionX, maxPlayerSpawnPositionX), 50, 0), Quaternion.Euler(0, 0, 0));
    }

    public Vector3 currentPlayerPosition() {
        return currentPlayer.transform.position;
    }

    float nfmod(float a,float b)
    {
        return a - b * Mathf.Floor(a / b);
    }

    public void changePlayer(int change) {
        currentPlayerId = (int)nfmod(currentPlayerId + change, teamSize);
        currentPlayer = team1Players[currentPlayerId];
    }

    public void move(Move movement) {
        if(started) {
           currentPlayer.GetComponent<PlayerMovement>().move(movement);
        }
    }
}
