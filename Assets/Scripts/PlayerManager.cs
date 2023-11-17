using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int teamSize = 1;
    public GameObject playerObject;
    private GameObject currentPlayer;
    public int minPlayerSpawnPositionX;
    public int maxPlayerSpawnPositionX;
    
    void Start() {
        currentPlayer = Instantiate(playerObject, new Vector3(Random.Range(minPlayerSpawnPositionX, maxPlayerSpawnPositionX), 50, 0), Quaternion.Euler(0, 0, 0));
    }

    public Vector3 currentPlayerPosition() {
        return currentPlayer.transform.position;
    }

    public void move(Move movement) {
        currentPlayer.GetComponent<PlayerMovement>().move(movement);
    }
}
