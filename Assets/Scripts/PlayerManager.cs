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

    public int playerChangeTime = 2;
    private List<GameObject> team1Players = new List<GameObject>();
    private List<GameObject> team2Players = new List<GameObject>();
    private bool started = false;
    private bool team1 = true;

    void Start()
    {
        for (int i = 0; i < teamSize; i++)
        {
            team1Players.Add(setPlayerColor(spawn(), Color.red));
            team2Players.Add(setPlayerColor(spawn(), Color.blue));
        }

        currentPlayer = team1Players[0];
        currentPlayerId = 0;
        currentPlayer.GetComponentInChildren<Shooting>().setTurn(true);

        started = true;
    }

    GameObject setPlayerColor(GameObject player, Color color)
    {
        player.GetComponent<Renderer>().material.SetColor("_Color", color);
        return player;
    }

    public bool playersExists()
    {
        return started;
    }

    GameObject spawn()
    {
        return Instantiate(playerObject, new Vector3(Random.Range(minPlayerSpawnPositionX, maxPlayerSpawnPositionX), 50, 0), Quaternion.Euler(0, 0, 0));
    }

    public Vector3 currentPlayerPosition()
    {
        return currentPlayer.transform.position;
    }

    public void changePlayer()
    {
        currentPlayer.GetComponentInChildren<Shooting>().setTurn(false);
        currentPlayer.GetComponent<PlayerMovement>().resetMoveCounter();
        if (team1)
        {
            currentPlayerId = ++currentPlayerId % teamSize;
            currentPlayer = team1Players[currentPlayerId];
        }
        else
        {
            currentPlayer = team2Players[currentPlayerId];
        }

        Shooting shootingComponent = currentPlayer.GetComponentInChildren<Shooting>();
        shootingComponent.setTurn(true);
    }

    public void move(PlayerMove movement)
    {
        if (started)
        {
            currentPlayer.GetComponent<PlayerMovement>().move(movement);
        }
    }

    public void shoot()
    {
        currentPlayer.GetComponentInChildren<Shooting>().shoot(playerChangeTime);
        team1 = !team1;
        Invoke("changePlayer", playerChangeTime);
    }

    public float currentPlayerMoveCounter()
    {
        return currentPlayer.GetComponent<PlayerMovement>().getMoveCounter();
    }

    public float getMoveLimit()
    {
        return currentPlayer.GetComponent<PlayerMovement>().getMoveLimit();
    }
}
