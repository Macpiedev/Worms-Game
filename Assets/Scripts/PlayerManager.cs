using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int teamSize;
    public GameObject playerObject;
    private GameObject currentPlayer;
    private int redPlayerTurnId;

    private int bluePlayerTurnId;
    public int minPlayerSpawnPositionX;
    public int maxPlayerSpawnPositionX;

    public int playerChangeTime = 2;
    private List<GameObject> team1Players = new List<GameObject>();
    private List<GameObject> team2Players = new List<GameObject>();
    private bool started = false;
    private bool team1 = true;
    public bool weaponAvailable = true;
    public bool changeWasCalled = false;

    private int team1Size;
    private int team2Size;

    void Start()
    {   
        team1Size = teamSize;
        team2Size = teamSize;
        Debug.Log(team1Size);
        for (int i = 0; i < teamSize; i++)
        {
            team1Players.Add(setPlayerColor(spawn(), Color.red, 1));
            team2Players.Add(setPlayerColor(spawn(), Color.blue, 2));
        }

        currentPlayer = team1Players[0];
        redPlayerTurnId = 0;
        bluePlayerTurnId = 0;
        currentPlayer.GetComponentInChildren<WeaponManager>().setTurn(true);
        currentPlayer.GetComponent<PlayerInfo>().isCurrentPlayer = true;

        started = true;
    }

    public void changeTeamSize(int teamId) {
        if(teamId == 1) {
            team1Size -= 1;
        } else {
            team2Size -= 1;
        }
    }

    public int getTeam1Size() {
        return team1Size;
    }

    public int getTeam2Size() {
        return team2Size;
    }

    GameObject setPlayerColor(GameObject player, Color color, int teamId)
    {
        player.GetComponent<PlayerInfo>().teamId = teamId;
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
        changeWasCalled = false;
        weaponAvailable = true;
        currentPlayer.GetComponentInChildren<WeaponManager>().setTurn(false);
        currentPlayer.GetComponent<PlayerInfo>().isCurrentPlayer = false;
        currentPlayer.GetComponent<PlayerMovement>().resetMoveCounter();

        setNextPlayer();
    }

    public void setNextPlayer()
    {
        if (team1)
        {
            setNextPlayer(ref redPlayerTurnId, ref team1Players);
        }
        else
        {
            setNextPlayer(ref bluePlayerTurnId, ref team2Players);
        }

    }

    private void setNextPlayer(ref int playerId, ref List<GameObject> team)
    {
        playerId = ++playerId % team.Count;
        currentPlayer = team[playerId];

        int i = 0;
        while (!currentPlayer.activeSelf)
        {
            playerId = ++playerId % team.Count;
            currentPlayer = team[playerId];
            i++;
        }

        currentPlayer.GetComponent<PlayerInfo>().isCurrentPlayer = true;
        WeaponManager shootingComponent = currentPlayer.GetComponentInChildren<WeaponManager>();
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
        if(weaponAvailable) {
            currentPlayer.GetComponentInChildren<WeaponManager>().shoot(playerChangeTime - 3);
            team1 = !team1;
            changeWasCalled = true;
            weaponAvailable = false;
            Invoke("changePlayer", playerChangeTime);
        }
    }

    public float currentPlayerMoveCounter()
    {

        return currentPlayer.GetComponent<PlayerMovement>().getMoveCounter();
    }

    public float getMoveLimit()
    {
        return currentPlayer.GetComponent<PlayerMovement>().getMoveLimit();
    }

    public void changeWeapon(int weaponId) {
        if(weaponAvailable) {
            WeaponManager weaponManager = currentPlayer.GetComponentInChildren<WeaponManager>();
            weaponManager.changeWeapon(weaponId);
        }
    }
}
